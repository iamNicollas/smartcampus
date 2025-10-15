<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="smartCampos.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../content/css/cadastro.css">

    <div id="container-cadastro">
        <h1>CADASTRO DE PRODUTOS</h1>
        <div id="container-label">
            <div id="left">
                <label for="txtNomeProduto">
                    Nome Produto
                    <asp:TextBox runat="server" ID="txtNomeProduto" placeholder="Escreva o nome" required="required"></asp:TextBox>
                </label>
                <label for="ddlCategoria">
                    Categoria
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="categoria" required="required"></asp:DropDownList>

                </label>
                <label for="txtObservacao">
                    Observação
                    <asp:TextBox runat="server" ID="txtObservacao" placeholder="Escreva uma observação" required="required"></asp:TextBox>
                </label>
            </div>
            <div id="right">
                <label for="txtValor">
                    Valor da Unidade
                    <asp:TextBox runat="server" ID="txtValor" placeholder="R$" required="required"></asp:TextBox>
                </label>
                <label for="txtDataValidade">
                    Data de Validade
                    <asp:TextBox runat="server" ID="txtDataValidade" placeholder="dd/mm/aaaa" required="required"></asp:TextBox>
                </label>
                <label for="txtQuantidade">
                    Quantidade
                    <asp:TextBox runat="server" ID="txtQuantidade" required="required"></asp:TextBox>
                </label>
            </div>
        </div>
        <style>
            .btn-cancelar {
                background-color: red;
                color: white;
                background-image: url('../Content/img/fotos/Close.png');
                background-repeat: no-repeat;
                background-position: 10px center;
                padding-left: 40px;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                padding-top: -25px;
                width: 130px;
            }

            .btn-cadastrar {
                background-color: rgb(36, 232, 36);
                color: white;
                background-image: url('../Content/img/fotos/Checkmark.png');
                background-repeat: no-repeat;
                background-position: 10px center;
                padding-left: 40px;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                width: 130px;
            }

            .btn-cancelar:hover {
                background-color: #850d0d;
            }

            .btn-cadastrar:hover {
                background-color: #17ae0d;
            }

            #container-btn {
                display: flex;
                gap: 10px;
            }
        </style>

        <div id="container-btn">
            <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn-cancelar" />
            <asp:Button ID="btnCadastro" OnClick="btnCadastro_Click" runat="server" Text="Cadastrar" CssClass="btn-cadastrar" />
        </div>
    </div>
</asp:Content>
