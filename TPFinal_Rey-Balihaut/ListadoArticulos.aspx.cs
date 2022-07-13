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
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else if (Session["tipo"].ToString() != "ADMIN")
            {
                Response.Redirect("Default.aspx", false);
            }


            ProductoNegocio producto_negocio = new ProductoNegocio();
            if(!IsPostBack)
            {
                gvArticulos.DataSource = producto_negocio.listarConSP();
                gvArticulos.DataBind();
            }

            List<_Producto> lista = producto_negocio.listar();
            for (int i = 0; i < gvArticulos.Rows.Count; i++)
            {
                if (lista[i].StockActual < lista[i].StockMinimo)
                {
                    gvArticulos.Rows[i].Cells[4].CssClass = "text-danger red";

                    //card articulo menor stock
                    nombreArt.Text = gvArticulos.Rows[i].Cells[0].Text;
                    stockArt.Text = "- Stock: " + gvArticulos.Rows[i].Cells[4].Text;
                }

            }
        }

        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvArticulos.SelectedDataKey.Value.ToString();
            //Session.Add("codigoSelected", codigoSelected);
            Response.Redirect("Articulos.aspx?id=" + codigoSelected);
        }

        protected void buscador_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            if(buscador.Text!="")
            {
                gvArticulos.DataSource = producto_negocio.listarxtexto(buscador.Text);
            }
            else
            {
                gvArticulos.DataSource = producto_negocio.listar();
            }
            gvArticulos.DataBind();
        }



        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Articulos.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            gvArticulos.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}