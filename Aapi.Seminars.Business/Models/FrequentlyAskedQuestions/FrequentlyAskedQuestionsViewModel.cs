using System.Collections.Generic;

namespace Aapi.Seminars.Models.FrequentlyAskedQuestions
{
    public class FrequentlyAskedQuestionsViewModel
    {
        public IList<FrequentlyAskedQuestion> Results { get; set; }
        public int TotalItemCount { get; set; }
    }
}
