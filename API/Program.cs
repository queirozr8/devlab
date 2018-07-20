using Core;
using MassTransit;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Unity;

namespace API
{
    internal class EventConsumerService : ServiceControl
    {

        #region Private Fields

        private NancyHost _host;
        private IBusControl _busControl;

        #endregion Private Fields

        #region Public Methods

        public bool Start(HostControl hostControl)
        {

            BusHelper.Instance.StartAsync();

            var uri = "http://localhost:81";

            using (var host = new NancyHost(new Uri(uri)))
            {
                var container = new UnityContainer();

                container.RegisterType<FormularioConsumer>();

                _busControl = BusHelper.GetBusConfiguration(container);

                container.RegisterInstance<IBusControl>(_busControl);
                container.RegisterInstance<IBus>(_busControl);

                _busControl.Start();

                host.Start();

                Console.WriteLine($"On {uri}");
                Console.ReadLine();
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }

        #endregion Public Methods

    }

    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(cfg =>
            {
                cfg.Service(x => new EventConsumerService());
            });

        }

    }
}
