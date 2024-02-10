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
    public partial class ListadoVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }

                if (!IsPostBack)
                {
                    SaleController negocio_venta = new SaleController();
                    gvVentas.DataSource = negocio_venta.GetAll();
                    gvVentas.DataBind();

                    CustomerController negocio_cliente = new CustomerController();
                    ddlclientes.DataSource = negocio_cliente.GetAll();
                    ddlclientes.DataTextField = "lastName";
                    ddlclientes.DataValueField = "id";
                    ddlclientes.DataBind();

                    total.Text = "$" + String.Format("{0:0.00}", negocio_venta.GetTotalSumSales());

                    promedio.Text = "$" + String.Format("{0:0.00}", negocio_venta.GetAverageOfTotalSales());

                    PurchaseController negocio_compra = new PurchaseController();
                    ganancia.Text = "$" + String.Format("{0:0.00}", negocio_venta.GetTotalSumSales() - negocio_compra.GetTotalSumPurchases());
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var numSelected = gvVentas.SelectedDataKey.Value.ToString();
                Response.Redirect("RegistroVenta.aspx?num=" + numSelected,false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvVentas.PageIndex = e.NewPageIndex;
                gvVentas.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaleController negocio_venta = new SaleController();
                gvVentas.DataSource = negocio_venta.GetByCustomer(ddlclientes.SelectedValue);
                gvVentas.DataBind();
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
                SaleController venta_negocio = new SaleController();

                if (tboxmin.Text != "" && tboxmax.Text != "")
                {
                    decimal min = decimal.Parse(tboxmin.Text);
                    decimal max = decimal.Parse(tboxmax.Text);
                    gvVentas.DataSource = venta_negocio.GetAllByTotalRange(min, max);
                }
                else if (tboxmin.Text != "" && tboxmax.Text == "")
                {
                    decimal min = decimal.Parse(tboxmin.Text);
                    gvVentas.DataSource = venta_negocio.GetByMinimumTotal(min);
                }
                else if (tboxmin.Text == "" && tboxmax.Text != "")
                {
                    decimal max = decimal.Parse(tboxmax.Text);
                    gvVentas.DataSource = venta_negocio.GetByMaximumTotal(max);
                }
                else
                {
                    gvVentas.DataSource = venta_negocio.GetAll();
                }
                gvVentas.DataBind();
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
                Response.AddHeader("content-disposition", "attachment;filename=Ventas.xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                gvVentas.RenderControl(htmlWrite);
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



