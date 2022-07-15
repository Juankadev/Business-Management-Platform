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
    public partial class ListadoCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else if (Session["tipo"].ToString() != "ADMIN")
                {
                    Response.Redirect("Default.aspx", false);
                }


                CompraNegocio compra_negocio = new CompraNegocio();

                if (!IsPostBack)
                {
                    gvCompras.DataSource = compra_negocio.listar();
                    gvCompras.DataBind();

                    total.Text = "$" + String.Format("{0:0.00}", compra_negocio.total());

                    ProveedorNegocio negocio = new ProveedorNegocio();
                    ddlproveedores.DataSource = negocio.listar();
                    ddlproveedores.DataTextField = "Nombre";
                    ddlproveedores.DataValueField = "CUIT";
                    ddlproveedores.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var numSelected = gvCompras.SelectedDataKey.Value.ToString();
                Response.Redirect("RegistroCompra.aspx?num=" + numSelected,false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvCompras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCompras.PageIndex = e.NewPageIndex;
                gvCompras.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlproveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CompraNegocio compra_negocio = new CompraNegocio();
                gvCompras.DataSource = compra_negocio.listarxproveedor(ddlproveedores.SelectedValue);
                gvCompras.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnfiltro_Click(object sender, EventArgs e)
        {
            try
            {
                CompraNegocio compra_negocio = new CompraNegocio();

                if (tboxmin.Text != "" && tboxmax.Text != "")
                {
                    decimal min = decimal.Parse(tboxmin.Text);
                    decimal max = decimal.Parse(tboxmax.Text);
                    gvCompras.DataSource = compra_negocio.listarxrango(min, max);
                }
                else if (tboxmin.Text != "" && tboxmax.Text == "")
                {
                    decimal min = decimal.Parse(tboxmin.Text);
                    gvCompras.DataSource = compra_negocio.listarxmin(min);
                }
                else if (tboxmin.Text == "" && tboxmax.Text != "")
                {
                    decimal max = decimal.Parse(tboxmax.Text);
                    gvCompras.DataSource = compra_negocio.listarxmax(max);
                }
                else
                {
                    gvCompras.DataSource = compra_negocio.listar();
                }
                gvCompras.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=Compras.xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                gvCompras.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}





///MAX CHANGED
//CompraNegocio compra_negocio = new CompraNegocio();

//if (tboxmax.Text != "")
//{
//    decimal max = decimal.Parse(tboxmax.Text);

//    if (tboxmin.Text != "")
//    {
//        decimal min = decimal.Parse(tboxmin.Text);
//        gvCompras.DataSource = compra_negocio.listarxrango(min, max);
//    }
//    else
//    {
//        gvCompras.DataSource = compra_negocio.listarxmax(max);
//    }
//}

//else
//{
//    gvCompras.DataSource = compra_negocio.listar();
//}
//gvCompras.DataBind();



//TBOXMIN
//CompraNegocio compra_negocio = new CompraNegocio();

//if (tboxmin.Text!="")
//{
//    //haymin = true;
//    decimal min = decimal.Parse(tboxmin.Text);

//    if (tboxmax.Text!="")
//    {
//        decimal max = decimal.Parse(tboxmax.Text);
//        gvCompras.DataSource = compra_negocio.listarxrango(min,max);
//    }
//    else
//    {
//        gvCompras.DataSource = compra_negocio.listarxmin(min);
//    }
//}

//else
//{
//    //haymin = false;
//    gvCompras.DataSource = compra_negocio.listar();
//}

//gvCompras.DataBind();