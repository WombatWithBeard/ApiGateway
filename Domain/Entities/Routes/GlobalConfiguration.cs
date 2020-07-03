using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Routes
{
    public class GlobalConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GlobalConfigurationId { get; set; }
        public string BaseUrl { get; set; }
    }
}