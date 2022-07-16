namespace WebApiFilterPipe.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class Test1Consumer :
        IConsumer<EmptyTrashBin>
    {
        private readonly ILogger<Test1Consumer> logger;

        public Test1Consumer(ILogger<Test1Consumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<EmptyTrashBin> context)
        {
            logger.LogInformation("Consumer 1 message id: {0}", context.MessageId);
            var payload = context.GetPayload<CustomPayload>();
            logger.LogInformation("Consumer 1 payload : {0}", payload);
            await context.RespondAsync(new EmptyTrashBinResponse());
        }
    }
}