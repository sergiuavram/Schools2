using System.ComponentModel.DataAnnotations;

namespace Schools2.Models
{
    public class City
    {
        public int ID { get; set; }
        [Display(Name = "City Name")]
        public string Name { get; set; }
        public int Population { get; set; }

        public int? CountyID { get; set; }
        public County? County { get; set; }

        public ICollection<School>? Schools { get; set; }
    }
}
