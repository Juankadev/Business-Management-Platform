using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;


namespace TPFinal_Rey_Balihaut
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void altaMarca_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marca_negocio = new MarcaNegocio();
                _Marca marca = new _Marca();
                marca.DescripcionMarca = nombre.Text;
                marca_negocio.agregar(marca);
                nombre.Text = "";
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


