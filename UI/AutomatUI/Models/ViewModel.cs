using Model;
using System.ComponentModel.DataAnnotations;

namespace AutomatUI.Models
{
    public class ViewModel
    {
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Sadece Sayı Girebilirsiniz!")]
        [Display(Name = "Ürün Adedi")] 
        public int Adet { get; set; }

        [Display(Name = "Ürün Adı")]
        public string UrunAdi { get; set; }

        public string OdemeYontemi { get; set; }

        [Display(Name = "Tutar")]
        public float Tutar { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Sadece Sayı Girebilirsiniz!")]
        [Display(Name = "Slot Numarası")]
        public int SlotId { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Sadece Sayı Girebilirsiniz!")]
        [Display(Name = "Kart Numarası")]
        public int OdemeYontemiNumara { get; set; }
        public List<Slot> slots { get; set; }
    }
}
