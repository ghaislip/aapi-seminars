using Aapi.Seminars.DataServices;
using Aapi.Seminars.Models.Seminars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Aapi.Seminars.Controllers
{
    public class SeminarsController : AapiSeminarsControllerBase
    {
        public SeminarsController(ILogger logger, ISeminarsDataService seminarsDataService)
            : base(logger)
        {
            this.SeminarsDataService = seminarsDataService;
        }

        private ISeminarsDataService SeminarsDataService { get; }

        [HttpGet("api/seminars")]
        public SeminarsViewModel GetAll(int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            return this.SeminarsDataService.GetAll(pageNumber, pageSize);
        }

        [HttpGet("api/seminar")]
        public SeminarViewModel GetById(int id)
        {
            return this.SeminarsDataService.GetById(id);
        }

        [HttpPost("api/seminars")]
        public void Add(SeminarAddCommandModel seminarAddCommandModel)
        {
            if (seminarAddCommandModel == null)
            {
                throw new ArgumentException("seminarAddCommandModel can not be null", nameof(seminarAddCommandModel));
            }
            this.SeminarsDataService.Add(seminarAddCommandModel);
        }

        [HttpPut("api/seminar")]
        public void Update(SeminarUpdateCommandModel seminarUpdateCommandModel)
        {
            if (seminarUpdateCommandModel == null)
            {
                throw new ArgumentException("seminarUpdateCommandModel can not be null", nameof(seminarUpdateCommandModel));
            }
            this.SeminarsDataService.Update(seminarUpdateCommandModel);
        }

        [HttpDelete("api/seminar")]
        public void Delete(int id)
        {
            this.SeminarsDataService.Delete(id);
        }
    }
}
