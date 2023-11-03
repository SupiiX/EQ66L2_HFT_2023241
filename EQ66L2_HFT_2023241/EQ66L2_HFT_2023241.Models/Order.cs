using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Models
{
    internal class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        //[Required]
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }


        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

       



    }
}
