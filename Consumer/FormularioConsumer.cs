using Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class FormularioConsumer : IConsumer<IFormularioSend>
    {
        public Task Consume(ConsumeContext<IFormularioSend> context)
        {
            return Task.FromResult(0);

        }
    }
}
