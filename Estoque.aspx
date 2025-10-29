<%@ Page Title="Estoque - SmartCampos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estoque.aspx.cs" Inherits="smartCampos.Estoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="../content/css/estoque.css">

    <div id="container-estoque">
        <!-- Filtro Estoque -->
        <div id="filtro-estoque">
            <div id="container-filtro">
                <label>
                    <input id="pesquisa-produto" placeholder="Escreva o nome do produto" />
                </label>
            </div>
        </div>

        <br />

        <asp:Repeater runat="server" ID="grd">
            <HeaderTemplate>
                <table id='tabela-historico' class="table">
                    <thead>
                        <tr>
                            <th>Produto</th>
                            <th>Quantidade</th>
                            <th>Categoria</th>
                            <th>Data Validade</th>
                            <th>Valor Unidade</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="product-list">
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("nomeProduto") %></td>
                    <td><%# Eval("quantidadeEstoque") %></td>
                    <td><%# Eval("nomeCategoria") %></td>
                    <td><%# ((DateTime)Eval("dta_validade")).ToString("dd/MM/yyyy") %></td>
                    <td><%# Eval("preco", "{0:C}") %></td>

                    <td class="img-opcoes">
                        <img src="../content/img/icons/opcoes.png" alt="Opções" class="like-btn" />
                        <div class="reaction-modal">
                            <a class="editar" href='Cadastro.aspx?idProduto=<%# Eval("idProduto") %>'>Editar
                                <img src="../content/img/icons/edit-3.png" alt="Editar">
                            </a>
                            <span class="excluir" data-id="<%# Eval("idProduto") %>">Excluir
                                <img src="../content/img/icons/trash-2.png" alt="Excluir">
                            </span>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <!-- Modal de Confirmação -->
    <div id="modal" class="modal">
        <div class="modal-content">
            <p>Tem certeza que deseja excluir esse produto?</p>

            <asp:HiddenField ID="hdnProdutoID" runat="server" />

            <asp:Button ID="btnExcluir" runat="server" Text="Sim" CssClass="btn-sim" OnClick="btnExcluir_Click" />
            <button type="button" id="confirmarNao">Não</button>
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
        const btnExcluirs = document.querySelectorAll(".excluir");
        const btnNao = document.getElementById("confirmarNao");

        btnExcluirs.forEach(btn => {
            btn.addEventListener("click", () => {
                const idProduto = btn.getAttribute("data-id");

                document.getElementById("<%= hdnProdutoID.ClientID %>").value = idProduto;

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
    <script src="../content/js/filtro.js" defer></script>
</asp:Content>
