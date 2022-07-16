namespace WebApiFilterPipe.Consumers
{
    using MassTransit;
    using WebApiFilterPipe.Filters;

    public class TestConsumerDefinition :
        ConsumerDefinition<TestConsumer>
    {
        private readonly ILogger<TestConsumerDefinition> logger;

        public TestConsumerDefinition(ILogger<TestConsumerDefinition> logger)
        {
            this.logger = logger;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TestConsumer> consumerConfigurator)
        {
            //endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
            endpointConfigurator.UseFilter(new ConsumeFilter());
            consumerConfigurator.UseFilter(new ConsumeWithConsumeFilter<TestConsumer>());
        }
    }
}