using System.ComponentModel.DataAnnotations;

namespace FILFusion01.Models
{
    public class Totalviewmodel
    {

        [Required]
        public float totalquantity { get; set; }
        [Required]
        public float totalprice { get; set; }
       
    }
}
