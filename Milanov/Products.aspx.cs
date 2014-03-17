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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FUP_Image.HasFile)
            {
                string FileType = Path.GetExtension(FUP_Image.PostedFile.FileName).ToLower().Trim();
                // Checking the format of the uploaded file.
                if (FileType != ".jpg" && FileType != ".png" && FileType != ".gif" && FileType != ".bmp")
                {
                    string alert = "alert('File Format Not Supported. Only .jpg, .png, .bmp and .gif file formats are allowed.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                }
                else
                {
                    // Getting the stream of the selected image and assign it to the Image Object.
                    System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FUP_Image.PostedFile.InputStream);

                }
            }
            // Getting the file name of the selected image
            string FileName = Path.GetFileNameWithoutExtension(FUP_Image.PostedFile.FileName);
            // Getting the file extension of the selected image
            string FileExtension = Path.GetExtension(FUP_Image.PostedFile.FileName);
            // Creating a complete relative path for storing the image.
            // And also attaching the datetime stamp with the image name.
            string path = "IMG/" + FileName +
                   DateTime.Now.ToString("yyyy-MM-dd HHmmtt") + FileExtension;

            // Saving the Image.
            FUP_Image.SaveAs(Server.MapPath(path));

            imgUploadedImage.ImageUrl = path;
            if (!String.IsNullOrEmpty(imgUploadedImage.ImageUrl))
            {
                // Showing a notification of success after uploading.
                string alert = "alert('Image uploaded successfully');";
                ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
            }
        }
    }
}