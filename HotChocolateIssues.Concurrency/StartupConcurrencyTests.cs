namespace HotChocolateIssues.Concurrency;

public class StartupConcurrencyTests
{
    [Fact]
    // this test ensures that the graphql configuration (models, queries, etc) are valid
    public void SingleGraphQlServersShouldStartUp()
    {
        var graphQl = GraphQlFacade.Create();
        graphQl.GetSchema();
    }

    [Fact]
    // the issue is that when multiple threads try to start up a graphql server, they might run into registration issues during startup.
    // this is very obvious in a large project with tons of tests that all want to do graphql queries for their test cases.
    // (assuming that the tests run in parallel when applicable)
    // but a single test can also demonstrate and reproduce the issue with relative good accuracy.
    // however, the test is flaky. running it 10 times would get a good result of if the issue exists or not.
    // the question is if HotChocolate has been started up or not when the second thread starts loading the schema.
    // the error that would occur is: (the key type can differ each run due to a race condition)
    // The given key 'Int32 customerId' was not present in the dictionary.
    //   (HotChocolate.Types.ObjectTypeExtension<HotChocolateIssues.Concurrency.GraphQl.TempServiceQueries>))
    //   at System.Threading.Tasks.TaskReplicator.Run[TState](ReplicatableUserAction`1 action, ParallelOptions options, Boolean stopOnFirstFailure)
    //   at System.Threading.Tasks.Parallel.ForWorker[TLocal,TInt](TInt fromInclusive, TInt toExclusive, ParallelOptions parallelOptions, Action`1 body, Action`2 bodyWithState, Func`4 bodyWithLocal, Func`1 localInit, Action`1 localFinally)
    //   --- End of stack trace from previous location ---
    //   at System.Threading.Tasks.Parallel.ForWorker[TLocal,TInt](TInt fromInclusive, TInt toExclusive, ParallelOptions parallelOptions, Action`1 body, Action`2 bodyWithState, Func`4 bodyWithLocal, Func`1 localInit, Action`1 localFinally)
    //   at System.Threading.Tasks.Parallel.For(Int32 fromInclusive, Int32 toExclusive, Action`1 body)
    //   at HotChocolateIssues.Concurrency.StartupConcurrencyTests.MultipleGraphQlServersShouldStartUp() in C:\RISK\Projects\Temp\HotChocolateIssues\HotChocolateIssues.Concurrency\StartupConcurrencyTests.cs:line 17
    //   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
    //   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
    public void MultipleGraphQlServersShouldStartUp()
    {
        const int count = 32;
        Parallel.For(0, count, _ =>
        {
            var graphQl = GraphQlFacade.Create();
            graphQl.GetSchema();
        });
    }
}
