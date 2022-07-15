using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinal_Rey_Balihaut
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["error"] != null)
                {
                    lblError.Text = Session["error"].ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}