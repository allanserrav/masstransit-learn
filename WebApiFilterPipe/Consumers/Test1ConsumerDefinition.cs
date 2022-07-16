namespace WebApiFilterPipe.Consumers
{
    using MassTransit;
    using WebApiFilterPipe.Contracts;
    using WebApiFilterPipe.Filters;

    public class Test1ConsumerDefinition :
        ConsumerDefinition<Test1Consumer>
    {
        private readonly ILogger<Test1ConsumerDefinition> logger;

        public Test1ConsumerDefinition(ILogger<Test1ConsumerDefinition> logger)
        {
            this.logger = logger;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<Test1Consumer> consumerConfigurator)
        {
            //endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
            //endpointConfigurator.UseFilter(new GeneralConsumeFilter());
            //consumerConfigurator.UseFilter(new PrimeiroConsumeWithConsumeFilter<TestConsumer>());
            //consumerConfigurator.ConsumerMessage<EmptyTrashBin>(m => m.UseFilter(new SegundoConsumeWithConsumeFilter<TestConsumer, EmptyTrashBin>()));
        }
    }
}