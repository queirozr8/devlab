using System;

namespace Contract
{
    public interface IFormularioSend
    {
        #region Public Properties

        long Id { get; set; }

        double Price { get; set; }

        int Quantity { get; set; }

        string Side { get; set; }

        string Symbol { get; set; }

        #endregion Public Properties
    }

    public class FormularioSend : IFormularioSend
    {
        public long Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Side { get; set; }
        public string Symbol { get; set; }
    }
}