using GreenPipes;
using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using Unity;

namespace Core
{
    public class BusHelper
    {
        #region Public Constructors

        static BusHelper()
        {
            if (Instance == null)
                Instance = ConfigureBus();
        }

        #endregion Public Constructors

        #region Public Properties

        public static IBusControl Instance { get; private set; }

        public static string RabbitMQPassword => "guest";

        public static string RabbitMQUri => "rabbitmq://35.199.98.99:5672/";

        public static string RabbitMQUserName => "guest";

        #endregion Public Properties

        #region Public Methods

        public static IBusControl ConfigureBus(
                    Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMQUri), hst =>
                {
                    hst.Username(RabbitMQUserName);
                    hst.Password(RabbitMQPassword);
                    hst.Heartbeat(60);
                });

                if (registrationAction != null)
                    registrationAction.Invoke(cfg, host);
            });
        }

        public static IBusControl GetBusConfiguration(IUnityContainer container)
        {
            return ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, "rpc_queue", e => 
                {
                    e.PrefetchCount = 1;
                    e.UseConcurrencyLimit(1);

                    e.LoadFrom(container);
                });
            });
        }

        #endregion Public Methods
    }
}