using System.ComponentModel.DataAnnotations;

namespace Schools2.Models
{
    public class School
    {
        public int ID { get; set; }
        [Display(Name = "School Name")]
        public string Name { get; set; }
        public string Profile { get; set; }

        public int? CityID { get; set; }
        public City? City { get; set; }
    }
}
