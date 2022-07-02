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
        public int cantidad { get; set; }
        //public int contador { get; set; }
        public string elegido { get; set; }
        public string val { get; set; }
        public List<Agregados> agregados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                cantidad = 0;
                //contador = 1;
                agregados = new List<Agregados>();
            }

            //AgregadoNegocio agregado_negocio = new AgregadoNegocio();

            ProveedorNegocio proveedores_negocio = new ProveedorNegocio();
            ddlproveedor.DataSource = proveedores_negocio.listar();
            ddlproveedor.DataValueField = "CUIT";
            ddlproveedor.DataTextField = "NOMBRE";
            ddlproveedor.DataBind();

            ProductoNegocio producto_negocio = new ProductoNegocio();
            ddlproductos.DataSource = producto_negocio.listar();
            ddlproductos.DataValueField = "CODIGO";
            ddlproductos.DataTextField = "NOMBRE";
            ddlproductos.DataBind();

            //ddlproveedor.SelectedValue = "115457845";

            
            gvAgregados.DataSource = agregados;
            gvAgregados.DataBind();

            //if (Session["contador"] != null)
            //{
            //    contador = int.Parse(Session["contador"].ToString());
            //}

            //if(ddlproveedor.Enabled==false)
            //{

            //}
        }

        protected void btncant_Click(object sender, EventArgs e)
        {
            //if(txtcant.Text!="")
            //{
            //    int ingresado = int.Parse(txtcant.Text);
            //    cantidad = ingresado;
            //}


            //cantidades.Text = "";
            //precio.Text = "";

            //contador += 1;
            //Session.Add("contador", contador);
            //Response.Redirect("Compras.aspx");
        }

        protected void btn_nuevo_producto_Click(object sender, EventArgs e)
        {
            //List<_Producto> lista = new List<_Producto>();
            //_Producto aux = new _Producto();

            ddlproveedor.Enabled = false;
            //elegido = ddlproveedor.SelectedItem.Value;
            cantidades.Text = "";
            precio.Text = "";
        }

        protected void gvSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvAgregados.SelectedDataKey.Value.ToString();
            
            Response.Redirect("Compras.aspx" + codigoSelected);
        }
    }
}