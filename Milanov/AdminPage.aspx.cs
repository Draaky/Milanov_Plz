using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov
{
    public partial class WebForm2 : System.Web.UI.Page
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewMessage_UpdateItem(Products product)
        {
            if (ModelState.IsValid)
            {
                new Products_CRUD().Update(product);
            }
        }

        public void FormViewMessage_InsertItem()
        {
            var product = new Products();
            TryUpdateModel(product);
            if (ModelState.IsValid)
            {
                new Products_CRUD().Insert(product);
            }
            ListViewMessage.DataBind();            
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewMessage_DeleteItem(int product_id)
        {
            new Products_CRUD().Delete(product_id);
        }
    }
}