using Aapi.Seminars.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aapi.Seminars.Models
{
    [Table("Sponsors", Schema = AapiSeminarsContext.AapiSeminarsSchema)]
    public class Sponsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeminarId { get; set; }
    }
}
