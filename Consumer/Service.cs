using Core;
using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Unity;

namespace Consumer
{
    public class Service : ServiceControl
    {
        private IBusControl _busControl;

        public bool Start(HostControl hostControl)
        {
            var container = new UnityContainer();

            _busControl = BusHelper.GetBusConfiguration(container);

            container.RegisterInstance<IBusControl>(_busControl);
            container.RegisterInstance<IBus>(_busControl);

            _busControl.Start();

            return true;
        }


        

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
