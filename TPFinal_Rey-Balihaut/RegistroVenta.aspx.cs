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
    public partial class RegistroVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }

                if (Request.QueryString["num"] != null)
                {
                    int buscado = int.Parse(Request.QueryString["num"]);
                    SaleController negocio = new SaleController();
                    Sale aux = negocio.GetByNumber(buscado);

                    txtnum.Text = aux.number.ToString();
                    txtfecha.Text = aux.date.ToString();
                    txtobservaciones.Text = aux.observations;
                    txtcliente.Text = aux.customer.name;
                    txttotal.Text = String.Format("{0:0.00}", aux.total);
                    txtcondicion.Text = aux.paymentCondition;
                }

                SaleController venta_negocio = new SaleController();
                gvArticulos.DataSource = venta_negocio.GetProductsFromPurchaseDetail(int.Parse(txtnum.Text));
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