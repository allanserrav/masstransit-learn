using MassTransit;
using System;

namespace WebApiFilterPipe.Filters
{
    public class ConsumeWithConsumeFilter<TConsumer> : IFilter<ConsumerConsumeContext<TConsumer>>
        where TConsumer : class
    {
        public void Probe(ProbeContext context)
        {
            Console.WriteLine("Probe context");
            context.CreateFilterScope("consumeWithConsumeFilter");
            context.Add("output", "console");
        }

        public async Task Send(ConsumerConsumeContext<TConsumer> context, IPipe<ConsumerConsumeContext<TConsumer>> next)
        {
            Console.WriteLine("Consume with consumer filter message id: {0}", context.MessageId);
            await next.Send(context);
        }
    }
}

