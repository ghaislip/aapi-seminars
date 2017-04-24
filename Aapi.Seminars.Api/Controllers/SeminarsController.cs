using Aapi.Seminars.DataServices;
using Aapi.Seminars.Models.Seminars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Aapi.Seminars.Controllers
{
    public class SeminarsController : AapiSeminarsControllerBase
    {
        public SeminarsController(ILogger<SeminarsController> logger, ISeminarsDataService seminarsDataService)
            : base(logger)
        {
            this.SeminarsDataService = seminarsDataService;
        }

        private ISeminarsDataService SeminarsDataService { get; }

        [HttpGet("api/seminars")]
        public async Task<SeminarsViewModel> GetAll(int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            return await this.SeminarsDataService.GetAll(pageNumber, pageSize);
        }

        [HttpGet("api/seminar")]
        public async Task<SeminarViewModel> GetById(int id)
        {
            return await this.SeminarsDataService.GetById(id);
        }

        [HttpPost("api/seminars")]
        public async Task Add(SeminarAddCommandModel seminarAddCommandModel)
        {
            if (seminarAddCommandModel == null)
            {
                throw new ArgumentException("seminarAddCommandModel can not be null", nameof(seminarAddCommandModel));
            }
            await this.SeminarsDataService.Add(seminarAddCommandModel);
        }

        [HttpPut("api/seminar")]
        public async Task Update(SeminarUpdateCommandModel seminarUpdateCommandModel)
        {
            if (seminarUpdateCommandModel == null)
            {
                throw new ArgumentException("seminarUpdateCommandModel can not be null", nameof(seminarUpdateCommandModel));
            }
            await this.SeminarsDataService.Update(seminarUpdateCommandModel);
        }

        [HttpDelete("api/seminar")]
        public async Task Delete(int id)
        {
            await this.SeminarsDataService.Delete(id);
        }
    }
}
