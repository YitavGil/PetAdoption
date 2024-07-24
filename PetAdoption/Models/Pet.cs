using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PetAdoption.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="שם החיה")]
        public string Name { get; set; }

        [Display(Name = "גיל")]
        public int Age { get; set; } = 0;

        [Display(Name = "סוג החיה")]
        public string PetType  { get; set; } = string.Empty;
        [Display(Name = "טלפון"), Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Display(Name = "מייל של החיה"), EmailAddress]
        public string Email { get; set; }

        public List<Image> Images { get; set; }

        //זה נועד כדי להעלות תמונה חדשה
        [Display(Name ="הוספת תמונה"), NotMapped]
        public IFormFile SetImage {
            get { return null; }
            
            set
            {
                if(value == null)
                {
                    return; 
                }
                UploadImage(value);
            }
        
        }

        public void UploadImage(IFormFile image)
        {
            //יצירת מקום בזיכרון המכיל קובץ
            MemoryStream stream = new MemoryStream();
            image.CopyTo(stream);
            // הפיכת המקום בזיכרון לבייטים
            SaveImage(stream.ToArray());
        }

        public void SaveImage(byte[] image)
        {
            Images.Add(new Image { MyImage = image, Pet = this });
        }

    }
}
