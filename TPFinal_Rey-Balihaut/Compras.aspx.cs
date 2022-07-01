using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinal_Rey_Balihaut
{
    public partial class Compras1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
            ddlproveedor.DataSource = proveedor_negocio.listar();
            ddlproveedor.DataValueField = "CUIT";
            ddlproveedor.DataTextField = "NOMBRE";
            ddlproveedor.DataBind();

            ProductoNegocio producto_negocio = new ProductoNegocio();
            ddlproducto.DataSource = producto_negocio.listar();
            ddlproducto.DataValueField = "CODIGO";
            ddlproducto.DataTextField = "NOMBRE";
            ddlproducto.DataBind();
        }
    }
}