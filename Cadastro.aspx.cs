using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using smartCampos.Models;

namespace smartCampos
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                methodProduto produto = new methodProduto();

                var carregar = produto.ListarCategorias();
                ddlCategoria.DataSource = carregar;
                ddlCategoria.DataTextField = "nomeCategoria";
                ddlCategoria.DataValueField = "idCategoria";
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem("Selecione", ""));

                int idCadastro = Convert.ToInt32(Request.QueryString["idProduto"]);

                if (idCadastro != 0)
                {
                    CarregarProduto(idCadastro);
                    btnCadastro.Visible = false;
                    btnEditar.Visible = true;
                }

                else
                {
                    btnCadastro.Visible = true;
                    btnEditar.Visible = false;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Response.Redirect("Cadastro.aspx");
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                objProduto produto = new objProduto
                {
                    nomeProduto = txtNomeProduto.Text,
                    quantidadeEstoque = int.Parse(txtQuantidade.Text),
                    dta_validade = DateTime.Parse(txtDataValidade.Text),
                    dta_cadastro = DateTime.Now,
                    preco = decimal.Parse(txtValor.Text),
                    descricao = txtObservacao.Text,
                    idCategoria = int.Parse(ddlCategoria.SelectedValue)
                };

                methodProduto met = new methodProduto();

                met.CadastroProduto(produto);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Produto cadastrado com sucesso!');", true);

                LimparCampos();
                Response.Redirect("Estoque.aspx");

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message.Replace("'", "").Replace("\n", " ");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Erro ao cadastrar o produto: {mensagem}');", true);
            }
        }

        public void LimparCampos()
        {
            txtNomeProduto.Text = "";
            txtValor.Text = "";
            ddlCategoria.SelectedIndex = 0;
            txtDataValidade.Text = "";
            txtValor.Text = "";
            txtObservacao.Text = "";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCadastro = Convert.ToInt32(Request.QueryString["idProduto"]);

                objProduto produto = new objProduto
                {
                    idProduto = idCadastro,
                    nomeProduto = txtNomeProduto.Text,
                    quantidadeEstoque = int.Parse(txtQuantidade.Text),
                    dta_validade = DateTime.Parse(txtDataValidade.Text),
                    dta_cadastro = DateTime.Now,
                    preco = decimal.Parse(txtValor.Text),
                    descricao = txtObservacao.Text,
                    idCategoria = int.Parse(ddlCategoria.SelectedValue)
                };

                methodProduto met = new methodProduto();

                met.AtualizarProduto(produto);

                string script = "alert('Produto atualizado com sucesso!'); window.location='Estoque.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertRedirect", script, true);


            }
            catch (Exception ex)
            {
                string mensagem = ex.Message.Replace("'", "").Replace("\n", " ");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Erro ao atualizar o produto: {mensagem}');", true);
            }
        }

        private void CarregarProduto(int id)
        {
            methodProduto methodProduto = new methodProduto();

            List<objProduto> listaProdutos = methodProduto.ListarProduto();
            objProduto produto = listaProdutos.Where(it => it.idProduto == id).FirstOrDefault();

            if (listaProdutos.Any())
            {
                txtNomeProduto.Text = produto.nomeProduto;
                txtQuantidade.Text = produto.quantidadeEstoque.ToString();
                txtDataValidade.Text = produto.dta_validade.ToString("dd/MM/yyyy");
                txtValor.Text = produto.preco.ToString();
                txtObservacao.Text = produto.descricao;
                ddlCategoria.SelectedIndex = produto?.idCategoria ?? default;
            }
        }
    }
}
