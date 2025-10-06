using HotChocolateIssues.DateTimeZone.GraphQl;
using HotChocolateIssues.TestBase;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Snapshooter.Xunit;

namespace HotChocolateIssues.DateTimeZone;

public class DateTimeZoneTests(
    WebApplicationFactory<Program> factory
) : TestHelper<Program>
{
    protected override WebApplicationFactory<Program> Factory { get; } = factory;

    [Fact]
    public async Task SchemaSnapshot()
    {
        Snapshot.Match(await GetSchema());
    }

    [Fact]
    // the issue is that date time values that are parsed from strings use the local zone as default zone.
    // for consistency, the utc zone should be used.
    // the issue is resolved by introducing the CustomDateTimeType and CustomDateTimeFilterInputType.
    // these will have parsing that would properly associate the date time values with the utc zone.
    // DateTime will always be UTC.
    // DateTimeOffset will default to UTC, but use the zone specified in the input if present.
    public async Task TestDateTime()
    {
        // output formatting will change datetime representation in the test output file.
        // if this is not disabled, it will be confusing the developer that looks at the output file to see what is being returned by GraphQl.
        var content = await RunQuery("TestDateTime", formatOutput: false);

        var settings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None,
        };
        var json = JsonConvert.DeserializeObject<JObject>(content, settings);
        Assert.NotNull(json);

        var dateTimes = json.SelectTokens("data.testDateTime.dateTimes[*]").ToList();
        var texts = json.SelectTokens("data.testDateTime.texts[*]").ToList();

        Assert.Equal(9, dateTimes.Count);
        Assert.Equal(9, texts.Count);

        // assert that the offset for datetime values is UTC
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[0].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[1].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[2].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[3].Value<string>());
        Assert.Equal("2024-05-20T13:00:00.000Z", dateTimes[4].Value<string>());
        Assert.Equal("2024-05-20T10:00:00.000Z", dateTimes[5].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[6].Value<string>());
        Assert.Equal("2024-05-20T13:00:00.000Z", dateTimes[7].Value<string>());
        Assert.Equal("2024-05-20T10:00:00.000Z", dateTimes[8].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000Z", texts[0].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000Z", texts[1].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000Z", texts[2].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000Z", texts[3].Value<string>());
        Assert.Equal("2024-05-20T13:00:00.0000000Z", texts[4].Value<string>());
        Assert.Equal("2024-05-20T10:00:00.0000000Z", texts[5].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000Z", texts[6].Value<string>());
        Assert.Equal("2024-05-20T13:00:00.0000000Z", texts[7].Value<string>());
        Assert.Equal("2024-05-20T10:00:00.0000000Z", texts[8].Value<string>());
    }

    [Fact]
    public async Task TestDateTimeOffset()
    {
        // output formatting will change datetime representation in the test output file.
        // if this is not disabled, it will be confusing the developer that looks at the output file to see what is being returned by GraphQl.
        var content = await RunQuery("TestDateTimeOffset", formatOutput: false);

        var settings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None,
        };
        var json = JsonConvert.DeserializeObject<JObject>(content, settings);
        Assert.NotNull(json);

        var dateTimes = json.SelectTokens("data.testDateTimeOffset.dateTimes[*]").ToList();
        var texts = json.SelectTokens("data.testDateTimeOffset.texts[*]").ToList();

        Assert.Equal(9, dateTimes.Count);
        Assert.Equal(9, texts.Count);

        // assert that the default offset for datetime values without offset is UTC
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[0].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[1].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[2].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[3].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000-01:00", dateTimes[4].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000+02:00", dateTimes[5].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000Z", dateTimes[6].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000-01:00", dateTimes[7].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.000+02:00", dateTimes[8].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000+00:00", texts[0].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000+00:00", texts[1].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000+00:00", texts[2].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000+00:00", texts[3].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000-01:00", texts[4].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000+02:00", texts[5].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000+00:00", texts[6].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000-01:00", texts[7].Value<string>());
        Assert.Equal("2024-05-20T12:00:00.0000000+02:00", texts[8].Value<string>());
    }

    [Theory]
    [InlineData("2024-05-20T12:00:00+00:00", "2024-05-20 12:00:00")]
    [InlineData("2024-05-20T12:00:00+00:00", "2024-05-20T12:00:00Z")]
    [InlineData("2024-05-20T12:00:00+00:00", "2024-05-20T12:00:00")]
    [InlineData("2024-05-20T12:00:00+00:00", "2024-05-20 12:00:00+00:00")]
    [InlineData("2024-05-20T12:00:00-01:00", "2024-05-20 12:00:00-01:00")]
    [InlineData("2024-05-20T12:00:00+02:00", "2024-05-20 12:00:00+02:00")]
    [InlineData("2024-05-20T12:00:00+00:00", "2024-05-20T12:00:00+00:00")]
    [InlineData("2024-05-20T12:00:00-01:00", "2024-05-20T12:00:00-01:00")]
    [InlineData("2024-05-20T12:00:00+02:00", "2024-05-20T12:00:00+02:00")]
    public void TestParsing(string expectedText, string text)
    {
        var expected = DateTimeOffset.Parse(expectedText);

        var value = CustomDateTimeType.TryParseDateTimeOffset(text);
        Assert.NotNull(value);
        Assert.Equal(value, expected);

        var formatted = CustomDateTimeType.FormatDateTimeOffset(value.Value);
        var expectedFormat = expectedText
            .Replace(":00:00", ":00:00.000")
            .Replace("+00:00", "Z");
        Assert.Equal(expectedFormat, formatted);
    }

    [Theory]
    [InlineData("2024-05-20T12:00:00Z")]
    public void TestJson(string expected)
    {
        var jsonString = """{"data":{"testDateTime":{"dateTimes":["{expected}"]}}}"""
            .Replace("{expected}", expected);

        var settings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None,
        };
        var json = JsonConvert.DeserializeObject<JObject>(jsonString, settings);
        Assert.NotNull(json);

        var dateTimes = json.SelectTokens("data.testDateTime.dateTimes[*]").ToList();

        var text = dateTimes[0].Value<string>();
        Assert.Equal(expected, text);
    }
}
