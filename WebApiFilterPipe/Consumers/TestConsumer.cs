namespace WebApiFilterPipe.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class TestConsumer :
        IConsumer<EmptyTrashBin>
    {
        private readonly ILogger<TestConsumer> logger;

        public TestConsumer(ILogger<TestConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<EmptyTrashBin> context)
        {
            logger.LogInformation("Consumer: {message}", context.Message);
            await context.RespondAsync(new EmptyTrashBinResponse());
        }
    }
}