using Aapi.Seminars.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aapi.Seminars.Models
{
    [Table("Seminars", Schema = AapiSeminarsContext.AapiSeminarsSchema)]
    public class Seminar
    {
        [Key]
        public int Id { get; set; }
    }
}
