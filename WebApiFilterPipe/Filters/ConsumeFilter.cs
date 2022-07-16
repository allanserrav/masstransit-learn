using MassTransit;
using MassTransit.Metadata;
using System;
using WebApiFilterPipe.Contracts;

namespace WebApiFilterPipe.Filters;

public class LogAndHandleExceptionConsumeFilter<T> : IFilter<ConsumeContext<T>>
    where T : class
{
    private readonly ILogger<LogAndHandleExceptionConsumeFilter<T>> _logger;

    public LogAndHandleExceptionConsumeFilter(ILogger<LogAndHandleExceptionConsumeFilter<T>> logger)
    {
        _logger = logger;
    }

    public void Probe(ProbeContext context) { }

    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        try
        {
            _logger.LogInformation("Inicio logconsume message id: {0} content: {1}", context.MessageId, context.Message);
            await next.Send(context);
            _logger.LogInformation("Termino logconsume message id: {0}", context.MessageId);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error logconsume message id: {0}", context.MessageId);
        }
    }
}

public class PayloadConsumeFilter<T> : IFilter<ConsumeContext<T>>
    where T : class
{
    private readonly ILogger<PayloadConsumeFilter<T>> _logger;

    public PayloadConsumeFilter(ILogger<PayloadConsumeFilter<T>> logger)
    {
        _logger = logger;
    }

    public void Probe(ProbeContext context) {}

    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        _logger.LogInformation("Consume with consumer filter message id: {0}", context.MessageId);
        var organizacaoHeader = context.GetHeader<Guid>("organizacao", Guid.Empty);
        var payload = new CustomPayload
        {
            IdOrganizacao = Guid.Parse("821e719d-f0b7-4436-91fd-4919f13a4fc1"),
            IdUsuario = Guid.Parse("e8125997-433f-44b9-8b05-968c3534c3bb")
        };
        if(organizacaoHeader != null && !organizacaoHeader.Equals(Guid.Empty))
        {
            payload.IdOrganizacao = organizacaoHeader.Value;
        }
        context.GetOrAddPayload(() => payload);
        await next.Send(context);
    }
}

public class PrimeiroConsumeWithConsumeFilter<TConsumer> : IFilter<ConsumerConsumeContext<TConsumer>>
    where TConsumer : class
{
    public void Probe(ProbeContext context) {}

    public async Task Send(ConsumerConsumeContext<TConsumer> context, IPipe<ConsumerConsumeContext<TConsumer>> next)
    {
        //var service = context.GetPayload<IServiceProvider>();
        //var logger = service.GetService<ILogger<GeneralConsumeFilter>>();
        //logger.LogInformation("Primeiro consume with consumer filter message id: {0}", context.MessageId);
        await next.Send(context);
    }
}

public class SegundoConsumeWithConsumeFilter<TConsumer, TMessage> : IFilter<ConsumerConsumeContext<TConsumer, TMessage>>
    where TConsumer : class
    where TMessage : class
{
    public void Probe(ProbeContext context)
    {
        //Console.WriteLine("Probe context");
        context.CreateFilterScope("consumeWithConsumeFilter");
        context.Add("output", "console");
    }

    public async Task Send(ConsumerConsumeContext<TConsumer, TMessage> context, IPipe<ConsumerConsumeContext<TConsumer, TMessage>> next)
    {
        var service = context.GetPayload<IServiceProvider>();
        //context.GetOrAddPayload(() => new CustomPayload { Id = 10 });
        //var logger = service.GetService<ILogger<SegundoConsumeWithConsumeFilter<TConsumer, TMessage>>>();
        //logger.LogInformation("Segundo consume with consumer filter message id: {0} {1}", context.MessageId, TypeMetadataCache<TMessage>.ShortName);
        //service.GetService<IMessageValidator<TMessage>>();
        await next.Send(context);
    }
}