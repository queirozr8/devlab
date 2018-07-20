using Contract;
using Core;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front
{
    public partial class _Default : Page
    {
        #region Public Fields

        public static HttpClient client => new HttpClient();

        #endregion Public Fields

        #region Public Methods

        public static async Task<Uri> PostAsync(FormularioSend formularioSend)
        {
            using (var stringContent = new StringContent(
                JsonConvert.SerializeObject(formularioSend), Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync(@"http://localhost:81/", stringContent);

                return response.Headers.Location;
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected void enviar_Click(object sender, EventArgs e)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion Protected Methods

        #region Private Methods

        private async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:81");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var send = new FormularioSend
                {
                    Id = new Random().Next(),
                    Price = double.Parse(preco.Text),
                    Quantity = int.Parse(quantidade.Text),
                    Side = rbCompra.Checked ? "buy" : "sell",
                    Symbol = symbol.Text
                };

                var url = await PostAsync(send);

            } catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Private Methods
    }
}