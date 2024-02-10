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
    public partial class FacturaCompra : System.Web.UI.Page
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

                if (Request.QueryString["num"] != null)
                {
                    int buscado = int.Parse(Request.QueryString["num"]);
                    PurchaseController negocio = new PurchaseController();
                    Purchase aux = negocio.GetByNumber(buscado);

                    txtnum.Text = aux.number.ToString();
                    txtfecha.Text = aux.date.ToString();
                    txtobservaciones.Text = aux.observations;
                    txtproveedor.Text = aux.supplier.name;
                    txttotal.Text = String.Format("{0:0.00}", aux.total);
                    txtcondicion.Text = aux.paymentCondition;
                }

                PurchaseController compra_negocio = new PurchaseController();
                gvArticulos.DataSource = compra_negocio.GetProductsFromPurchaseDetail(int.Parse(txtnum.Text));
                gvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}