using System.ComponentModel.DataAnnotations;

namespace Schools2.Models
{
    public class County
    {
        public int ID { get; set; }
        [Display(Name = "County Name")]
        public string Name { get; set; }
        [Display(Name = "Must Visit")]
        public string MustVisit { get; set; } 

        public int? CountryID { get; set; }
        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }
    }
}
