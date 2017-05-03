using Aapi.Seminars.Contexts;
using Aapi.Seminars.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aapi.Seminars.Models
{
    [Table("Seminars", Schema = AapiSeminarsContext.AapiSeminarsSchema)]
    public class Seminar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public SessionStatus Status { get; set; }
    }
}
