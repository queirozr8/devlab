<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Front._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Formulário</h1>
        <form>
            <asp:RadioButton Text="Compra" GroupName="checks" ID="rbCompra" runat="server" Checked="true" />
            &nbsp
            <asp:RadioButton Text="Venda" GroupName="checks" ID="rbVenda" runat="server" Checked="false" />
            &nbsp
            <br />
            <br />
            Preço
            <asp:TextBox ID="preco" runat="server" />
            <br />
            <br />
            Quantidade
            <asp:TextBox ID="quantidade" runat="server" />
            <br />
            <br />
            Symbol
            <asp:TextBox ID="symbol" runat="server" />
            <br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviar_Click" /><br />
            <br />
            <table style="width: 100%">
                <tr>
                    <th>Operação</th>
                    <th>Preço</th>
                    <th>Quantidade</th>
                    <th>Falha</th>
                </tr>
            </table>
        </form>
    </div>

</asp:Content>
