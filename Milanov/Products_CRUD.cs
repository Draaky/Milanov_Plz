using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Milanov
{
    public class Products_CRUD
    {
        // Read query to get all data out of database.
        public List<Products> GetProducts()
        {
            
            var sqlStr = @"SELECT PRODUCT_ID, PRODUCT_NAME, PRODUCT_TEXT, PRODUCT_URL, PRODUCT_SMALL_URL, PRODUCT_WATER_URL, PRODUCT_PRICE FROM PRODUCTS";
            var connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;

            var result = new List<Products>();
            using (var conn = new SqlConnection(connStr))
            {
                using (var cmd = new SqlCommand(sqlStr, conn))
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

        // Create/Insert Query for products
        public bool Insert(Products product)
        {
            var sqlStr = @"INSERT INTO PRODUCTS (PRODUCT_NAME, PRODUCT_TEXT, PRODUCT_URL, PRODUCT_SMALL_URL, PRODUCT_WATER_URL, PRODUCT_PRICE) 
                VALUES (@NAME, @TEXT, @URL, @SMALL_URL, @WATER_URL, @PRICE)";
            var connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;

            
            using (var conn = new SqlConnection(connStr))
            {
                using (var cmd = new SqlCommand(sqlStr, conn))
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

        // Update info in database.
        public bool Update(Products product)
        {
            var sqlStr = @"UPDATE PRODUCTS 
                    SET PRODUCT_NAME = @NAME, PRODUCT_TEXT = @TEXT,  PRODUCT_PRICE = @PRICE WHERE PRODUCT_ID = @PRODUCT_ID";
            var connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;

            var result = new List<Products>();
            using (var conn = new SqlConnection(connStr))
            {
                using (var cmd = new SqlCommand(sqlStr, conn))
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
        // Query to delete a row of data out of database.
        public bool Delete(int PRODUCT_ID)
        {
            var sqlStr = @"DELETE FROM PRODUCTS WHERE PRODUCT_ID = @PRODUCT_ID";
            var connStr = ConfigurationManager.ConnectionStrings["Milanov_DB"]
                .ConnectionString;
            using (var conn = new SqlConnection(connStr))
            {
                using (var cmd = new SqlCommand(sqlStr, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_ID", PRODUCT_ID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() == 1; // Execute once
                }
            }
        }



    }
}