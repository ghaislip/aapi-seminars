using Aapi.Seminars.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aapi.Seminars.Models
{
    [Table("FrequentlyAskedQuestions", Schema = AapiSeminarsContext.AapiSeminarsSchema)]
    public class FrequentlyAskedQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
