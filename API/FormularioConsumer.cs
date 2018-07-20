using Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class FormularioConsumer : IConsumer<IFormularioSend>
    {
        public Task Consume(ConsumeContext<IFormularioSend> context)
        {
            var sb = new StringBuilder();

            var message = context.Message;
            if (message.Price <= 0)
                sb.AppendLine($"Invalid Price!  {message.Price}");

            if (message.Quantity <= 0)
                sb.AppendLine($"Invalid Quantity! {message.Quantity}");

            if (string.IsNullOrWhiteSpace(message.Side) || !(message.Side.Equals("buy") || message.Side.Equals("sell")))
                sb.AppendLine($"Invalid Side! {message.Side}");

            context.Respond<IFormularioReceive>(new FormularioReceive { Receive = new Receive { Id = message.Id, Status = (sb.Length == 0), Msgs = sb.ToString() } });

            return Task.FromResult(0);

        }
    }
}
