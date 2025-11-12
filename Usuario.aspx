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
                                 <img src="../content/img/icons/edit-3.png" alt="Editar">
                                <asp:Button ID="btnEditarUsuario" runat="server" Text="Editar" CssClass="editarUsuario" Onclick="btnEditarUsuario_Click" CommandArgument='<%# Eval("idUsuario") %>' />
                                <span class="excluirUsuario" data-id="<%# Eval("idUsuario") %>">Excluir
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
        <!-- Modal de Confirmação -->
        <div id="modal" class="modal">
            <div class="modal-content">
                <p>Tem certeza que deseja excluir esse usúario?</p>

                <asp:HiddenField ID="hdnUsuarioID" runat="server" />

                <asp:Button ID="btnExcluir" runat="server" Text="Sim" CssClass="btn-sim" Onclick="btnExcluir_Click" />
                <button type="button" id="confirmarNao">Não</button>
            </div>
        </div>
    </div>
    <style>
    .modal {
        display: none;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
        justify-content: center;
        align-items: center;
        z-index: 999;
    }

    .modal-content {
        background-color: #fff;
        padding: 20px;
        border-radius: 8px;
        text-align: center;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
        width: 350px; 
    }

    .modal-content p {
        margin-bottom: 10px;
    }

    .btn-sim {
        background-color: #28a745;
        color: white;
        border: none;
        border-radius: 5px;
        padding: 10px 20px;
        cursor: pointer;
    }

        .btn-sim:hover {
            background-color: #218838;
        }

    #confirmarNao {
        background-color: #dc3545;
        color: white;
        border: none;
        border-radius: 5px;
        padding: 10px 20px;
        cursor: pointer;
    }

        #confirmarNao:hover {
            background-color: #c82333;
        }
</style>
     <script>
     const modal = document.getElementById("modal");
     const btnExcluirs = document.querySelectorAll(".excluirUsuario");
     const btnEditar = document.querySelectorAll(".editarUsuario");
     const btnNao = document.getElementById("confirmarNao");

     btnExcluirs.forEach(btn => {
         btn.addEventListener("click", () => {
             const idUsuario = btn.getAttribute("data-id");

             document.getElementById("<%= hdnUsuarioID.ClientID %>").value = idUsuario;

             modal.style.display = "flex";
         });
     });

     btnExcluirs.forEach(btn => {
         btn.addEventListener("click", () => {
             const idUsuario = btn.getAttribute("data-id");

             document.getElementById("<%= hdnUsuarioID.ClientID %>").value = idUsuario;

             modal.style.display = "flex";
         });
     });

     btnNao.addEventListener("click", () => {
         modal.style.display = "none";
     });

     window.addEventListener("click", (event) => {
         if (event.target === modal) {
             modal.style.display = "none";
         }
     });
     </script>
    <script src="../content/js/tabelaEstoque.js" defer></script>
</asp:Content>
