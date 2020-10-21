using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SliderManagerApp.Entity
{
    public class Slider
    {
        public int Id { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Onay Durumu")]
        public bool IsApproved { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime StartingDate { get; set; }
        [DisplayName("Bitiş Tarihi")]
        public DateTime FinishDate { get; set; }
        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [DisplayName("Resim")]
        public string ImageURL { get; set; }


    }
}
