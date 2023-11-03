using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Models
{
    internal class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string ProductDescription { get; set; }

    }
}
