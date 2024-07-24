using System.ComponentModel.DataAnnotations;

namespace PetAdoption.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public Pet Pet { get; set; }
        public byte[] MyImage { get; set; }
    }
}