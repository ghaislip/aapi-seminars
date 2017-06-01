using System.Threading.Tasks;
using Aapi.Seminars.Contexts;
using Aapi.Seminars.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aapi.Seminars.DataServices
{
    [TestClass]
    public class FrequentlyAskedQuestionsDataServiceTests
    {
        public TestContext TestContext { get; set; }
        private IAapiSeminarsContext TestAapiSeminarsContext { get; set; }

        [TestInitialize]
        public async Task Initialize()
        {
            var options = new DbContextOptionsBuilder<AapiSeminarsContext>()
                .UseInMemoryDatabase(this.TestContext.TestName)
                .Options;
            this.TestAapiSeminarsContext = new AapiSeminarsContext(options);
            this.TestAapiSeminarsContext.FrequentlyAskedQuestions.Add(new FrequentlyAskedQuestion {Id = 2, Question = "Who are you?", Answer = "Zach"});
            this.TestAapiSeminarsContext.FrequentlyAskedQuestions.Add(new FrequentlyAskedQuestion {Id = 3, Question = "Where do you live?", Answer = "Birmingham"});
            this.TestAapiSeminarsContext.FrequentlyAskedQuestions.Add(new FrequentlyAskedQuestion {Id = 4, Question = "What is your middle name?", Answer = "Wayne"});
            await this.TestAapiSeminarsContext.SaveChangesAsync();
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnCorrectCounts()
        {
            var frequentlyAskedQuestionsDataService = new FrequentlyAskedQuestionsDataService(this.TestAapiSeminarsContext, null);

            var frequentlyAskedQuestions = await frequentlyAskedQuestionsDataService.GetAll(1, 2);

            Assert.IsNotNull(frequentlyAskedQuestions);
            Assert.AreEqual(3, frequentlyAskedQuestions.TotalItemCount);
            Assert.AreEqual(2, frequentlyAskedQuestions.Results.Count);
        }
    }
}