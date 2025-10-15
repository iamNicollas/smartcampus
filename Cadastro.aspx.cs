using System;
using System.Data;
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
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
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
                    preco = decimal.Parse(txtValor.Text.Replace(",", ".")),
                    descricao = txtObservacao.Text,
                    idCategoria = int.Parse(ddlCategoria.SelectedValue)
                };

                methodProduto met = new methodProduto();

                met.CadastroProduto(produto);

                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('Produto cadastrado com sucesso!');", true);

                LimparCampos();

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message.Replace("'", "").Replace("\n", " ");
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", $"alert('Erro ao cadastrar o produto: {mensagem}');", true);
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
    }
}
