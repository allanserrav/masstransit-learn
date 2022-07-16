using MassTransit;
using System;

namespace WebApiFilterPipe.Filters
{
    public class ConsumeFilter : IFilter<ConsumeContext>
    {
        public void Probe(ProbeContext context)
        {
            //logger.LogInformation("Probe context");
            context.CreateFilterScope("primeiroConsumeFilter");
            context.Add("output", "console");
        }

        public async Task Send(ConsumeContext context, IPipe<ConsumeContext> next)
        {
            Console.WriteLine("Consume filter message id: {0}", context.MessageId);
            await next.Send(context);
        }
    }
}

