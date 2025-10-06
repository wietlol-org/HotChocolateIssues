using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HotChocolateIssues.TestBase;

public abstract class TestHelper<TEntryPoint> : IClassFixture<WebApplicationFactory<TEntryPoint>>
    where TEntryPoint : class
{
    protected abstract WebApplicationFactory<TEntryPoint> Factory { get; }

    public async Task<string> GetSchema()
    {
        var client = Factory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, "/graphql?sdl=true");

        var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var schema = await response.Content.ReadAsStringAsync();

        Directory.CreateDirectory("../../../TestFiles");
        await File.WriteAllTextAsync("../../../TestFiles/Schema.graphql", schema
            .Replace("  ", "    "));

        return schema;
    }

    protected async Task<string> RunQuery(string name, bool formatOutput = true)
    {
        var client = Factory.CreateClient();

        var query = await File.ReadAllTextAsync($"../../../TestFiles/{name}.graphql");
        var variables = ReadVariables(name);

        var request = new HttpRequestMessage(HttpMethod.Post, "/graphql");

        var input = JsonConvert.SerializeObject(new
        {
            query,
            variables = "%variables%",
        }).Replace("\"%variables%\"", variables);
        request.Content = new StringContent(input, Encoding.UTF8, "application/json");

        var response = await client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();

        await File.WriteAllTextAsync($"../../../TestFiles/{name}.output.jsonl", formatOutput ? TryFormatJson(content) : content);
        response.EnsureSuccessStatusCode();

        return content;
    }

    private static string ReadVariables(string name)
    {
        var path = $"../../../TestFiles/{name}.variables.jsonl";

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return json;
        }

        return "{}";
    }

    private static string TryFormatJson(string json)
    {
        try
        {
            using var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream))
            {
                using var jw = new JsonTextWriter(writer);
                jw.Formatting = Formatting.Indented;
                jw.IndentChar = '\t';
                jw.Indentation = 1;

                var serializer = new JsonSerializer();
                if (json.StartsWith('['))
                    serializer.Serialize(jw, JArray.Parse(json));
                else
                    serializer.Serialize(jw, JObject.Parse(json));
            }

            return Encoding.UTF8.GetString(stream.ToArray()) + "\n";
        }
        catch
        {
            return json;
        }
    }
}
