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

        protected async void btnLogin_Click(object sender, EventArgs e)
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
            var usuarios = await met.BuscarTodosUsuario();

            if(usuarios.Select(it => it.Nome).Where(nome => nome == txtEmail.Text.ToString()))
        }
    }
}