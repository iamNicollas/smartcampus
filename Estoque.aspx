<%@ Page Title="Estoque - SmartCampos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estoque.aspx.cs" Inherits="smartCampos.Estoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <link rel="stylesheet" href="https://cdn.datatables.net/2.3.4/css/dataTables.dataTables.css" />
    <link rel="stylesheet" href="../content/css/estoque.css">

    <div id="container-estoque">
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
            <td><%# Eval("id_produto") %></td>
            <td><%# Eval("int_quantidade") %></td>
            <td><%# Eval("categoriaNome") %></td>
            <td><%# ((DateTime)Eval("dt_validade")).ToString("dd/MM/yyyy") %></td>
            <td><%# Eval("dm_valor") %></td>
            <td class="img-opcoes">
                <img src="assets/img/icons/opcoes.png" alt="Opções" class="like-btn" data-modal="${modalId}" />
                <div class="reaction-modal" id="${modalId}">
                    <span class="editar" data-id="${produto.id}">
                      Editar
                      <img src="assets/img/icons/edit-3.png" alt="Editar">
                    </span>
                    <span class="excluir" data-id="${produto.id}">
                        Excluir
                        <img src="assets/img/icons/trash-2.png" alt="Excluir">
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

    <script src="https://cdn.datatables.net/2.3.4/js/dataTables.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                var printCounter = 0;

                $('#tabela-historico').DataTable({
                    "paging": true,
                    "ordering": true,
                    "info": false,
                    dom: 'Bfrtip',
                });
            });
        </script>
    <%--<script src="../content/js/tabelaEstoque.js" defer></script>
    <script src="../content/js/filtro.js" defer></script>
    <script src="../content/js/editar.js"></script>--%>
</asp:Content>
