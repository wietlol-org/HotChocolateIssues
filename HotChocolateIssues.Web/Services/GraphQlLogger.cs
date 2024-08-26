using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using HotChocolate.Resolvers;

namespace HotChocolateIssues.Web.Services;

public class GraphQlLogger : ExecutionDiagnosticEventListener
{
    private const string LogFile = "../../../TestFiles/Logs.jsonl";

    public GraphQlLogger()
    {
        File.Delete(LogFile);
    }

    public void GenericError(Exception exception)
    {
        File.AppendAllText(LogFile, $"[GenericError] {exception}\n");
    }

    public override void RequestError(IRequestContext context, Exception exception)
    {
        File.AppendAllText(LogFile, $"[RequestError] {exception}\n");
    }

    public override void SyntaxError(IRequestContext context, IError error)
    {
        File.AppendAllText(LogFile, $"[SyntaxError] {error.Exception}\n");
    }

    public override void ResolverError(IMiddlewareContext context, IError error)
    {
        File.AppendAllText(LogFile, $"[ResolverError] {error.Exception}\n");
    }

    public override void TaskError(IExecutionTask task, IError error)
    {
        File.AppendAllText(LogFile, $"[TaskError] {error.Exception}\n");
    }
}
