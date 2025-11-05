using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using smartCampos.Models;
using smartCampus.CrossCutting;

namespace smartCampos
{
    public partial class Usuario : System.Web.UI.Page
    {
        methodUsuario method = new methodUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarUsuario();
                btnEditar.Visible = false;
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
                objUsuario usuario = new objUsuario
                {
                    Nome = txtNome.Text,
                    CPF = txtCPF.Text,
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text,
                    Email = txtEmail.Text,
                    dta_Cadastro = DateTime.Now
                };

                methodUsuario met = new methodUsuario();

                met.CadastrarUsuario(usuario);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Usuario cadastrado com sucesso!');", true);

                LimparCampos();
                CarregarUsuario();

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message.Replace("'", "").Replace("\n", " ");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Erro ao cadastrar o usúario: {mensagem}');", true);
            }
        }

        public void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtLogin.Text = string.Empty;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
               


            }
            catch (Exception ex)
            {
                string mensagem = ex.Message.Replace("'", "").Replace("\n", " ");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Erro ao atualizar o produto: {mensagem}');", true);
            }
        }

        private void CarregarUsuario()
        {
            List<objUsuario> listaCliente = method.BuscarTodosUsuario();
            if (listaCliente != null && listaCliente.Count > 0)
            {
                grd.DataSource = listaCliente;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }

        protected void txtCPF_TextChanged(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();

            if (cpf.Length != 11)
            {
                Response.Write("<script>alert('CPF inválido!');</script>");
                return;
            }

            if (!ValidaCPF.ValidarCPF(cpf))
            {
                Response.Write("<script>alert('CPF inválido!');</script>");
            }
            else
            {
                Response.Write("<script>alert('CPF válido!');</script>");
            }
        }
    }
}
