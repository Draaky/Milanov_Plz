using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // Get info out of database.
        #region GetData
        public IQueryable<Products> ListViewMessage_GetData()
        {
            var msgCRUD = new Products_CRUD();
            var msgs = msgCRUD.GetProducts();
            return msgs.AsQueryable<Products>();
        }
        #endregion

        // Update the info that has been changed.
        #region update query
        public void ListViewMessage_UpdateItem(Products product)
        {
            if (ModelState.IsValid)
            {
                new Products_CRUD().Update(product);
            }
        }
        #endregion

        //insert item fuction. & Foto Upload.
        #region Insert Query
        public void FormViewMessage_InsertItem()
        {
            FileUpload uploadcontrol = FormViewMessage.FindControl("ImageUpload") as FileUpload;


            if (uploadcontrol.HasFile)
            {
                string FileType = Path.GetExtension(uploadcontrol.PostedFile.FileName).ToLower().Trim();

                 // Getting the file name of the selected image
                string FileName = Path.GetFileNameWithoutExtension(uploadcontrol.PostedFile.FileName);

                // Getting the file extension of the selected image
                string FileExtension = Path.GetExtension(uploadcontrol.PostedFile.FileName);
                // Creating a complete relative path for storing the image.
                // And also attaching the datetime stamp with the image name.
                string path = "IMG/" + FileName +
                       DateTime.Now.ToString("yyyy-MM-dd HHmmtt") + FileExtension;

                string thumbPath = "IMG_SMALL/" + FileName +
                       DateTime.Now.ToString("yyyy-MM-dd HHmmtt") + FileExtension;

                string wateredPath = "IMG_WATER/" + FileName +
                       DateTime.Now.ToString("yyyy-MM-dd HHmmtt") + FileExtension;

                // Checking the format of the uploaded file.
                if (FileType != ".jpg" && FileType != ".png")
                {
                    string alert = "alert('File Format Not Supported. Only .jpg and .png,  file formats are allowed.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                }
                else
                {
                    // Saving the Image.
                    uploadcontrol.SaveAs(Server.MapPath(path));                    

                    // Draw/Create Thumbnail.
                    System.Drawing.Image image = System.Drawing.Image.FromFile((Server.MapPath(path)));

                    int newwidthimg = 160;
                    float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                    int newHeight = Convert.ToInt32(newwidthimg / AspectRatio);

                    Bitmap thumbnailBitmap = new Bitmap(newwidthimg, newHeight);
                    Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                    /*thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;*/
                    Rectangle imageRectangle = new Rectangle(0, 0, newwidthimg, newHeight);
                    thumbnailGraph.DrawImage(image, imageRectangle);

                    //Save img at myPath.
                    if (FileType == ".png")
                        thumbnailBitmap.Save(Server.MapPath(thumbPath), ImageFormat.Png);

                    if (FileType == ".jpg")
                        thumbnailBitmap.Save(Server.MapPath(thumbPath), ImageFormat.Jpeg);

                    //Remove temp files.
                    thumbnailGraph.Dispose();
                    thumbnailBitmap.Dispose();
                    image.Dispose();

                    // Create watermark img

                    System.Drawing.Image w_image = System.Drawing.Image.FromFile((Server.MapPath(path)));
                    // Resize img. to 900 px width.
                    int w_newwidthimg = 900;
                    float w_AspectRatio = (float)w_image.Size.Width / (float)w_image.Size.Height;
                    int w_newHeight = Convert.ToInt32(w_newwidthimg / w_AspectRatio);

                    Bitmap w_thumbnailBitmap = new Bitmap(w_newwidthimg, w_newHeight);
                    Graphics w_thumbnailGraph = Graphics.FromImage(w_thumbnailBitmap);
                    Rectangle w_imageRectangle = new Rectangle(0, 0, w_newwidthimg, w_newHeight);
                    w_thumbnailGraph.DrawImage(w_image, w_imageRectangle);

                    System.Drawing.Image watermarkImage = System.Drawing.Image.FromFile((Server.MapPath("watermark.png")));
                    // Addthe watermark. 
                    
                    using (Graphics imageGraphics = Graphics.FromImage(w_thumbnailBitmap))
                    using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
                    {
                        int x = (w_thumbnailBitmap.Width / 2- watermarkImage.Width / 2);      // Code to place img in the middle. (w_image.Width / 2 - watermarkImage.Width / 2);
                        int y = (w_thumbnailBitmap.Height / 2- watermarkImage.Height / 2);    //                                  (w_image.Height / 2 - watermarkImage.Height / 2);
                        watermarkBrush.TranslateTransform(x, y);
                        imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));

                        if (FileType == ".png")
                            w_thumbnailBitmap.Save(Server.MapPath(wateredPath), ImageFormat.Png);

                        if (FileType == ".jpg")
                            w_thumbnailBitmap.Save(Server.MapPath(wateredPath), ImageFormat.Jpeg);

                        // Delete tempfiles.
                        w_image.Dispose();
                        watermarkImage.Dispose();
                        imageGraphics.Dispose();
                        watermarkBrush.Dispose();

                        w_thumbnailGraph.Dispose();
                        w_thumbnailBitmap.Dispose();
                    
                    }


                    if (!String.IsNullOrEmpty(path))
                    {
                        // Showing a notification of success after uploading.
                        string alert = "alert('Image uploaded successfully');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);


                        Products product = new Products();
                        TryUpdateModel(product);
                        product.PRODUCT_URL = path;
                        product.PRODUCT_SMALL_URL = thumbPath;
                        product.PRODUCT_WATER_URL = wateredPath;

                        if (ModelState.IsValid)
                        {
                            new Products_CRUD().Insert(product);
                        }
                    }
                }    
            }
            else
            {
                string alert = "alert('No file uploaded!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
            }

            ListViewMessage.DataBind();            
        }
        #endregion

        // Delete where id is product_id
        #region delete query
        public void ListViewMessage_DeleteItem(int product_id)
        {
            new Products_CRUD().Delete(product_id);
        }
        #endregion

        
        
    }
}