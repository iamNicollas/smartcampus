<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="smartCampos.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../content/css/usuario.css">
    <script src="../content/js/MascaraCPF.js" defer></script>
    <div id="container-cadastro">
        <h1>CRIAR UMA CONTA NOVA</h1>
        <div id="container-label">
            <div id="left">
                <label for="txtNome">
                    Nome 
                    <asp:TextBox runat="server" ID="txtNome" placeholder="Escreva o seu nome" ></asp:TextBox>
                </label>
               
                <label for="txtCPF">
                    CPF
                    <asp:TextBox runat="server" ID="txtCPF" CssClass="cpf-input" OnTextChanged="txtCPF_TextChanged" placeholder="000.000.000-00" ></asp:TextBox>
                </label>
               
                <label for="txtSenha">
                    Senha
                    <asp:TextBox runat="server" TextMode="Password" ID="txtSenha" placeholder="Digite sua senha" ></asp:TextBox>
                </label>
            </div>
            <div id="right">
                <label for="txtEmail">
                    Email
                    <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" placeholder="Digite seu e-mail" ></asp:TextBox>
                </label>
                <label for="txtLogin">
                    Login
                    <asp:TextBox runat="server"  ID="txtLogin" placeholder="Digite seu login" ></asp:TextBox>
                </label>
                <div id="container-btn">
                    <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn-cancelar" />
                    <asp:Button ID="btnCadastro" OnClick="btnCadastro_Click" runat="server" Text="Cadastrar" CssClass="btn-cadastrar" />
                    <asp:Button ID="btnEditar" OnClick="btnEditar_Click" runat="server" Text="Editar" CssClass="btn-cadastrar" />
                </div>
            </div>
        </div>
        <div id="container-lista-usuario">
             <asp:Repeater runat="server" ID="grd">
                <HeaderTemplate>
                    <div id="tabela-historico-wrapper">
                        <table id="tabela-historico" class="table">
                            <thead>
                                <tr>
                                    <th>Nome</th>
                                    <th>Email</th>
                                    <th>Login</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="product-list">
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nome") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Login") %></td>
                        <td class="img-opcoes">
                            <img src="../content/img/icons/opcoes.png" alt="Opções" class="like-btn" />
                            <div class="reaction-modal">
                                <a class="editar" href='Cadastro.aspx?idProduto=<%# Eval("idUsuario") %>'>Editar
                                    <img src="../content/img/icons/edit-3.png" alt="Editar">
                                </a>
                                <span class="excluir" data-id="<%# Eval("idUsuario") %>">Excluir
                                    <img src="../content/img/icons/trash-2.png" alt="Excluir">
                                </span>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                            </tbody>
                        </table>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

    </div>
</asp:Content>
