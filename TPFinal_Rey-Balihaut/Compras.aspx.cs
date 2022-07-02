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
        public List<Agregados> lista_agregados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cantidad = 0;
                //contador = 1;
            }

            if (Session["agregados"] == null)
            {
                lista_agregados = new List<Agregados>();
                Session.Add("agregados", lista_agregados);
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



            gvAgregados.DataSource = Session["agregados"];
            gvAgregados.DataBind();


            //TOTAL SUMA
            lista_agregados = (List<Agregados>)Session["agregados"];
            if (lista_agregados.Count > 0)
            {
                decimal suma = 0;
                foreach (Dominio.Agregados aux in lista_agregados)
                {
                    suma += aux.Precio * aux.Cantidad;
                }
                txtsuma.Text = "$" + suma.ToString();
            }
            else
            {
                txtsuma.Text = "$0";
            }

            //if (Session["contador"] != null)
            //{
            //    contador = int.Parse(Session["contador"].ToString());
            //}

            if (ddlproveedor.Enabled==false)
            {
                ddlproveedor.SelectedItem.Text = elegido;
            }
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
            if(cantidades.Text != "" && precio.Text != "")
            {
                Agregados aux = new Agregados();
                aux.Codigo = ddlproductos.SelectedItem.Text;
                aux.Cantidad = int.Parse(cantidades.Text);
                aux.Precio = decimal.Parse(precio.Text);

                lista_agregados = (List<Agregados>)Session["agregados"];
                lista_agregados.Add(aux);
            }

            ddlproveedor.Enabled = false;

            elegido = ddlproveedor.SelectedItem.Text;
            cantidades.Text = "";
            precio.Text = "";

            Response.Redirect("Compras.aspx");
        }

        protected void gvSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvAgregados.SelectedDataKey.Value.ToString();

            lista_agregados = (List<Agregados>)Session["agregados"];
            Agregados aux = lista_agregados.Find(x => x.Codigo == codigoSelected);
            lista_agregados.Remove(aux);

            Response.Redirect("Compras.aspx");
        }


        protected void altaCompra_Click(object sender, EventArgs e)
        {
            //limpiar pantalla
            lista_agregados = new List<Agregados>();
            Session.Add("agregados", lista_agregados);
            Response.Redirect("Compras.aspx");
        }
    }
}