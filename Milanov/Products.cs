using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Milanov
{
    public class Products
    {

        

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
        

        
        public Products() { }

        // Constructor for products.
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