using System.ComponentModel.DataAnnotations;

namespace PackitupStoragePark.Data
{
    public class StorageUnit
    {
        [Key]
        public int UnitId { get; set; } 
        public int?  UnitSize { get; set; }
        public  int? UnitNumber { get; set; }                                                                                                         
        public  float? UniPrince { get; set; }                                                                                                         
    }
}
