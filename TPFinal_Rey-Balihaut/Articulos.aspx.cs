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
    public partial class Altas1 : System.Web.UI.Page
    {
        protected bool existe(ListItem li, List<String> listaAsociados)
        {
            string liString = li.Text;
            for (int i = 0; i < listaAsociados.Count; i++)
            {
                if (listaAsociados[i] == liString)
                {
                    return true;
                }
            }
            return false;
        }
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


                codigo.MaxLength = 10;
                precio.CssClass = "form-control";


                if (!IsPostBack)
                {
                    BrandController marca_negocio = new BrandController();
                    ddlmarca.DataSource = marca_negocio.GetAll();
                    ddlmarca.DataValueField = "id";
                    ddlmarca.DataTextField = "description";
                    ddlmarca.DataBind();

                    CategoryController categoria_negocio = new CategoryController();
                    ddlcategoria.DataSource = categoria_negocio.GetAll();
                    ddlcategoria.DataValueField = "id";
                    ddlcategoria.DataTextField = "description";
                    ddlcategoria.DataBind();

                    SupplierController proveedor_negocio = new SupplierController();
                    //ddlproveedor.DataSource = proveedor_negocio.listar();
                    //ddlproveedor.DataValueField = "CUIT";
                    //ddlproveedor.DataTextField = "
                    //";
                    //ddlproveedor.DataBind();

                    btn_articulo.Text = "Agregar";

                    if (Request.QueryString["id"] != null)
                    {
                        stockactual.ReadOnly = true;
                        //stockminimo.ReadOnly = true;


                        btn_eliminar.Enabled = true;

                        codigo.ReadOnly = true;
                        string codigoURL = Request.QueryString["id"].ToString();
                        btn_articulo.Text = "Modificar";
                        ProductController negocio = new ProductController();
                        List<Product> lista = negocio.GetAll();
                        Product producto = lista.Find(x => x.code == codigoURL);

                        codigo.Text = producto.code;
                        nombre.Text = producto.name;
                        //(producto.Marca.IDMarca - 1).ToString();

                        //NO PRECARGA LOS DDL
                        ddlmarca.SelectedValue = (producto.brand.id).ToString();
                        ddlcategoria.SelectedValue = (producto.category.id).ToString();

                        PurchaseController negocio_compra = new PurchaseController();
                        if (negocio_compra.ExistProductInPurchase(producto.code))
                        {
                            //precio.Text = String.Format("{0:0.00}", producto.Precio);
                            precio.Text = producto.price.ToString();
                        }
                        else
                        {
                            precio.Text = "No hay Compras del articulo";
                        }

                        stockactual.Text = producto.currentStock.ToString();
                        stockminimo.Text = producto.minimumStock.ToString();
                        ganancia.Text = producto.percentageOfProfit.ToString();

                        //CheckBoxList.Visible = false;


                        CheckBoxList.DataSource = proveedor_negocio.GetAllNames();
                        CheckBoxList.DataBind();
                        List<String> listaAsociados = proveedor_negocio.GetAssociatedSuppliers(codigo.Text);

                        foreach (ListItem li in CheckBoxList.Items)
                        {
                            if (existe(li, listaAsociados))
                                li.Selected = true;
                        }
                    }
                    else
                    {
                        precio.Text = "0";
                        CheckBoxList.DataSource = proveedor_negocio.GetAllNames();
                        CheckBoxList.DataBind();
                        //btn_eliminar.Visible = false;
                        btn_eliminar.Enabled = false;
                        btn_eliminar.CssClass = "btn btn-danger btn-lg btnlogin";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void altaArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                //solo se puede agregar o modificar si:
                if (codigo.Text != "" && nombre.Text != "")
                {
                    ProductController producto_negocio = new ProductController();
                    Product aux = new Product();
                    aux.brand = new Brand();
                    aux.category = new Category();

                    SupplierController proveedor_negocio = new SupplierController();
                    List<Supplier> lista = proveedor_negocio.GetAll();

                    aux.code = codigo.Text;
                    aux.name = nombre.Text;
                    BrandController marca_negocio = new BrandController();

                    aux.brand.id = int.Parse(ddlmarca.SelectedValue);
                    aux.category.id = int.Parse(ddlcategoria.SelectedValue);


                    if (precio.Text == "No hay Compras del articulo")
                    { aux.price = 0; }
                    else
                    { aux.price = decimal.Parse(precio.Text); }

                    if (stockactual.Text == "")
                    { aux.currentStock = 0; }
                    else
                    { aux.currentStock = decimal.Parse(stockactual.Text); }

                    if (stockminimo.Text == "")
                    { aux.minimumStock = 0; }
                    else
                    { aux.minimumStock = decimal.Parse(stockminimo.Text); }

                    if (ganancia.Text == "")
                    { aux.percentageOfProfit = 0; }
                    else
                    { aux.percentageOfProfit = decimal.Parse(ganancia.Text); }



                    if (Request.QueryString["id"] != null) //se esta modificando un prod.
                    {
                        producto_negocio.ModifyFromStoredProcedure(aux);

                        ////Modificar proveedores_x_producto
                        //foreach (ListItem li in CheckBoxList.Items)
                        //{
                        //    if (li.Selected == false)
                        //    {
                        //        Supplier proveedor = lista.Find(x => x.name == li.Text);
                        //        proveedor_negocio.DeleteAssociatedSuppliers(proveedor.cuit, aux.code);
                        //    }
                        //    else
                        //    {
                        //        Supplier proveedor = lista.Find(x => x.name == li.Text);
                        //        producto_negocio.AddSuppliers(proveedor.cuit, aux.code);
                        //    }
                        //}
                    }

                    else //se esta agregando un producto
                    {
                        producto_negocio.Add(aux);

                        //Agregar proveedores_x_producto
                        foreach (ListItem li in CheckBoxList.Items)
                        {
                            if (li.Selected)
                            {
                                Supplier proveedor = lista.Find(x => x.name == li.Text);
                                producto_negocio.AddSuppliers(proveedor.cuit, aux.code);
                            }
                        }
                    }

                    Response.Redirect("ListadoArticulos.aspx",false);
                }


                //validar
                if (codigo.Text == "")
                {
                    //codigo.BackColor = System.Drawing.Color.IndianRed;
                    codigo.CssClass = "form-control is-invalid";
                }
                else
                {
                    //codigo.BorderColor = System.Drawing.Color.White;
                    codigo.CssClass = "form-control is-valid";
                }

                if (nombre.Text == "")
                {
                    //nombre.BackColor = System.Drawing.Color.IndianRed;
                    nombre.CssClass = "form-control is-invalid";
                }
                else
                {
                    //nombre.BackColor = System.Drawing.Color.White;
                    nombre.CssClass = "form-control is-valid";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductController producto_negocio = new ProductController();
                if (Request.QueryString["id"] != null)
                {
                    string codigoURL = Request.QueryString["id"].ToString();
                    producto_negocio.Delete(codigoURL);
                    Response.Redirect("ListadoArticulos.aspx",false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}