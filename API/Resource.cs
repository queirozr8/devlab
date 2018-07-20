using Contract;
using Core;
using MassTransit;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using System;
using System.Threading.Tasks;

namespace API
{
    public class Resource : NancyModule
    {
        #region Public Constructors

        public Resource()
        {
            JsonSettings.MaxJsonLength = int.MaxValue;

            Post<FormularioSend, IFormularioReceive>("/");
        }

        #endregion Public Constructors

        #region Protected Methods

        new protected void Post<TRequest, TIResponse>(string route)
                            where TRequest : class
            where TIResponse : class
        {
            base.Post[route] = args => RequestClient<TRequest, TIResponse>();
        }

        #endregion Protected Methods

        #region Private Methods

        private dynamic RequestClient<TRequest, TIResponse>()
            where TRequest : class
            where TIResponse : class
        {
            var request = this.Bind<TRequest>();
            var status = string.Empty;

            TIResponse response = null;

            Task.Run(async () =>
            {
                var requestClient = BusHelper.Instance.CreatePublishRequestClient<TRequest, TIResponse>(new TimeSpan(0, 10, 0));
                response = await requestClient.Request(request);
            }).Wait();

            return Response.AsJson(response);
        }

        #endregion Private Methods
    }
}