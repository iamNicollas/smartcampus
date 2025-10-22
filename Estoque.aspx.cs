using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using smartCampos.Models;

namespace smartCampos
{
    public partial class Estoque : System.Web.UI.Page
    {
        methodProduto method = new methodProduto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CarregarProdutos();
            }
        }

        private void CarregarProdutos()
        {
            List<objProduto> listaProdutos = method.ListarProduto();

            if (listaProdutos != null && listaProdutos.Count > 0)
            {
                grd.DataSource = listaProdutos;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
    }
}