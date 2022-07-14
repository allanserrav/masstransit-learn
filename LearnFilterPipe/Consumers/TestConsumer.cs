namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class LearnConsumerConsumer :
        IConsumer<LearnConsumer>
    {
        public Task Consume(ConsumeContext<LearnConsumer> context)
        {
            return Task.CompletedTask;
        }
    }
}