using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        public int Warranty_year { get; set; }

        public int Price { get; set; }

        public int ManufacturerID { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

    }
}
