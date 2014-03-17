using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Milanov
{
    public partial class Products1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Products> ListViewMessage_GetData()
        {
            var msgCRUD = new Products_CRUD();
            var msgs = msgCRUD.GetProducts();
            return msgs.AsQueryable<Products>();
        }

       
    }
}