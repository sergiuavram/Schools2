using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Schools2.Models
{
    public class Country
    {
        public int ID { get; set; }
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        [Display(Name = "Official Language")]
        public string OfficialLanguage { get; set; }
        [Display(Name = "Fun Fact")]
        public string FunFact { get; set; }

        public ICollection<County>? Counties { get; set; }
    }
}
