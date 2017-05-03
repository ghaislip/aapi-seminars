using Aapi.Seminars.Contexts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aapi.Seminars.Models
{
    [Table("Sessions", Schema = AapiSeminarsContext.AapiSeminarsSchema)]
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SeminarId { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int SpeakerId { get; set; }

        [ForeignKey(nameof(SpeakerId))]
        public Speaker Speaker { get; set; }
    }
}
