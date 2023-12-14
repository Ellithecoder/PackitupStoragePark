using System.ComponentModel.DataAnnotations;

namespace PackitupStoragePark.Models
{
    public class StorageUnitVM
    {
        [Key]
        public int UnitId { get; set; }
        [Required]  
        public int UnitSize { get; set; }
        [Required]  
        public int UnitNumber { get; set; }
        [Required]  
        public float UniPrince { get; set; }
    }
}
