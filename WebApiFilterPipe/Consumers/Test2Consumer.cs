namespace WebApiFilterPipe.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class Test2Consumer :
        IConsumer<EmptyTrashBin>
    {
        private readonly ILogger<Test2Consumer> logger;

        public Test2Consumer(ILogger<Test2Consumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<EmptyTrashBin> context)
        {
            logger.LogInformation("Consumer 2 message id: {0}", context.MessageId);
            var payload = context.GetPayload<CustomPayload>();
            logger.LogInformation("Consumer 2 payload : {0}", payload);
            await context.RespondAsync(new EmptyTrashBinResponse());
        }
    }
}