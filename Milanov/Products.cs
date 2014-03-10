using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Milanov
{
    public class Products
    {

        /*  Database info!
            [PRODUCT_ID]        INT            NOT NULL,
            [PRODUCT_NAME]      CHAR (20)      NULL,
            [PRODUCT_TEXT]      CHAR (500)     NULL,
            [PRODUCT_URL]       CHAR (50)      NULL,
            [PRODUCT_SMALL_URL] CHAR (50)      NULL,
            [PRODUCT_WATER_URL] CHAR (50)      NULL,
            [PRODUCT_PRICE]     DECIMAL (7, 2) NULL,
            PRIMARY KEY CLUSTERED ([PRODUCT_ID] ASC) 
         */

        // All value slots.
        [Key, ScaffoldColumn(false)]
        public int PRODUCT_ID { get; set; }
        [Required, MaxLength(50), Display(Name="Productnaam")]
        public string PRODUCT_NAME { get; set; }
        [Display(Name="Omschrijving")]
        public string PRODUCT_TEXT { get; set; }
        [Key, ScaffoldColumn(false)]//[Display(Name = "URL")]
        public string PRODUCT_URL { get; set; }
        [Key, ScaffoldColumn(false)]//[Display(Name = "THUMB")]
        public string PRODUCT_SMALL_URL { get; set; }
        [Key, ScaffoldColumn(false)]//[Display(Name = "WATERED")]
        public string PRODUCT_WATER_URL { get; set; }
        [Display(Name = "Prijs")]
        public decimal PRODUCT_PRICE { get; set; }
        

        //Empty plz!
        public Products() { }

        // Constructor plz fill all!
        public Products(int p_id, string p_name, string p_txt, string p_url, string p_small, string p_water, decimal p_price)
        {
            PRODUCT_ID          = p_id;
            PRODUCT_NAME        = p_name;
            PRODUCT_TEXT        = p_txt;
            PRODUCT_URL         = p_url;
            PRODUCT_SMALL_URL   = p_small;
            PRODUCT_WATER_URL   = p_water;
            PRODUCT_PRICE       = p_price;
        }
    }
}