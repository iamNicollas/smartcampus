using smartCampos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartCampos
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email é obrigatório para realizar login!');", true);
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Senha é obrigatório para realizar login!');", true);
                return;
            }

            methodUsuario met = new methodUsuario();
            var usuarios = met.BuscarTodosUsuario();

            var usuarioLogado = usuarios.Where(it => it.Email == txtEmail.Text && it.Senha == txtSenha.Text).FirstOrDefault();
            if(usuarioLogado != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login efetuado com sucesso!');", true);
                Response.Redirect("Home.aspx");
                return;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email ou Senha incorretas, tente novamente!');", true);
        }
    }
}