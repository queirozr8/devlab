namespace Contract
{
    public interface IFormularioReceive
    {
        #region Public Properties

        Receive Receive { get; set; }

        #endregion Public Properties
    }

    public class FormularioReceive : IFormularioReceive
    {
        #region Public Properties

        public Receive Receive { get; set; }

        #endregion Public Properties
    }

    public class Receive
    {
        #region Private Properties

        public long Id { get; set; }

        public string Msgs { get; set; }

        public bool Status { get; set; }

        #endregion Private Properties
    }
}