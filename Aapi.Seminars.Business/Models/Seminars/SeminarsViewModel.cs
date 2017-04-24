using System.Collections.Generic;

namespace Aapi.Seminars.Models.Seminars
{
    public class SeminarsViewModel
    {
        public IList<Seminar> Results { get; set; }
        public int TotalItemCount { get; set; }
    }
}
