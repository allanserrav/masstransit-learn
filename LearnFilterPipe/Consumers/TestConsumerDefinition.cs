namespace Company.Consumers
{
    using MassTransit;

    public class LearnConsumerConsumerDefinition :
        ConsumerDefinition<LearnConsumerConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<LearnConsumerConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}