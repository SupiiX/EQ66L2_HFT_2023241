using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Models
{
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ManufacturerID { get; set; }

        [StringLength(150)]

        public string ManufacturerName { get; set;}

        [StringLength(150)]

        public string PlaceOf { get; set;}

        public virtual ICollection<Product> Products { get; set; }

    }
}
