using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Milanov
{
    public class Products_CRUD
    {
        // Read query to get all data out of database.
        #region Get Products
        public List<Products> GetProducts()
        {
            
            string sqlStr = @"SELECT PRODUCT_ID, PRODUCT_NAME, PRODUCT_TEXT, PRODUCT_URL, PRODUCT_SMALL_URL, PRODUCT_WATER_URL, PRODUCT_PRICE FROM PRODUCTS";
            string connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;

            List<Products> result = new List<Products>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            // add a database row into result.
                            result.Add(new Products(
                                Convert.ToInt32(rdr["PRODUCT_ID"]),
                                Convert.ToString(rdr["PRODUCT_NAME"]),
                                Convert.ToString(rdr["PRODUCT_TEXT"]),
                                Convert.ToString(rdr["PRODUCT_URL"]),
                                Convert.ToString(rdr["PRODUCT_SMALL_URL"]),
                                Convert.ToString(rdr["PRODUCT_WATER_URL"]),
                                Convert.ToDecimal(rdr["PRODUCT_PRICE"])
                            ));
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        // Create/Insert Query for products
        #region Insert into DB
        public bool Insert(Products product)
        {
            string sqlStr = @"INSERT INTO PRODUCTS (PRODUCT_NAME, PRODUCT_TEXT, PRODUCT_URL, PRODUCT_SMALL_URL, PRODUCT_WATER_URL, PRODUCT_PRICE) 
                VALUES (@NAME, @TEXT, @URL, @SMALL_URL, @WATER_URL, @PRICE)";
            string connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@NAME", product.PRODUCT_NAME);
                    cmd.Parameters.AddWithValue("@TEXT", product.PRODUCT_TEXT);//String.IsNullOrWhiteSpace(product.PRODUCT_TEXT) ? DBNull.Value : (object)product.PRODUCT_TEXT);
                    cmd.Parameters.AddWithValue("@URL", product.PRODUCT_URL);
                    cmd.Parameters.AddWithValue("@SMALL_URL", product.PRODUCT_SMALL_URL);
                    cmd.Parameters.AddWithValue("@WATER_URL", product.PRODUCT_WATER_URL);
                    cmd.Parameters.AddWithValue("@PRICE", product.PRODUCT_PRICE);

                    conn.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
#endregion

        // Update info in database.
        #region update row in DB
        public bool Update(Products product)
        {
            string sqlStr = @"UPDATE PRODUCTS 
                    SET PRODUCT_NAME = @NAME, PRODUCT_TEXT = @TEXT,  PRODUCT_PRICE = @PRICE WHERE PRODUCT_ID = @PRODUCT_ID";
            string connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;

            List<Products> result = new List<Products>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_ID", product.PRODUCT_ID);
                    cmd.Parameters.AddWithValue("@NAME", product.PRODUCT_NAME);

                    cmd.Parameters.AddWithValue("@TEXT", product.PRODUCT_TEXT);//string.IsNullOrWhiteSpace(product.PRODUCT_TEXT) ?
                        //DBNull.Value : (object)product.PRODUCT_TEXT);

                    cmd.Parameters.AddWithValue("@PRICE", product.PRODUCT_PRICE);


                    conn.Open();
                    return cmd.ExecuteNonQuery() == 1; // Makes sure it will only be executed once
                    // Ok, done :(
                }
            }
        }
        #endregion

        // Query to delete a row of data out of database.
        #region Delete row out of DB
        public bool Delete(int PRODUCT_ID)
        {
            // Delete img.
            string selectquery = @"SELECT  PRODUCT_URL, PRODUCT_SMALL_URL, PRODUCT_WATER_URL FROM PRODUCTS WHERE PRODUCT_ID = @PRODUCT_ID";
            string connString = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;

            using (SqlConnection connect = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(selectquery, connect))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_ID", PRODUCT_ID);
                    connect.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())  // Read info out of cmd.
                        {
                            string img_big;
                            string img_small;
                            string img_watered;
                            
                            // Get full path.
                            img_big = HttpContext.Current.Server.MapPath(Convert.ToString(rdr["PRODUCT_URL"]));
                            img_small = HttpContext.Current.Server.MapPath(Convert.ToString(rdr["PRODUCT_SMALL_URL"]));
                            img_watered = HttpContext.Current.Server.MapPath(Convert.ToString(rdr["PRODUCT_WATER_URL"]));

                            FileInfo big_img = new FileInfo(img_big);
                            FileInfo small_img = new FileInfo(img_small);
                            FileInfo watered_img = new FileInfo(img_watered);

                            // Delete if file is found.
                            if (big_img.Exists)
                            {
                                big_img.Delete();
                            }

                            if (small_img.Exists)
                            {
                                small_img.Delete();
                            }
                            if (watered_img.Exists)
                            {
                                watered_img.Delete();
                            }
                        }
                     }
                }
            }
            
           //After file is deleted, we delete row in database.


            // DELETE DB info.

            // Delete row where id = id.
            string sqlStr = @"DELETE FROM PRODUCTS WHERE PRODUCT_ID = @PRODUCT_ID";
            string connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_ID", PRODUCT_ID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() == 1; // Execute once
                }
            }
        }
        #endregion



    }
}