using Aapi.Seminars.Contexts;
using Aapi.Seminars.Models;
using Aapi.Seminars.Models.Seminars;
using AutoMapper;
using System.Linq;

namespace Aapi.Seminars.DataServices
{
    public interface ISeminarsDataService
    {
        SeminarsViewModel GetAll(int pageNumber, int pageSize);
        SeminarViewModel GetById(int id);
        void Add(SeminarAddCommandModel seminarAddCommandModel);
        void Update(SeminarUpdateCommandModel seminarUpdateCommandModel);
        void Delete(int id);
    }

    public class SeminarsDataService : DataServiceBase<Seminar>, ISeminarsDataService
    {
        public SeminarsDataService(IAapiSeminarsContext aapiSeminarsContext, IMapper mapper)
            : base(aapiSeminarsContext, mapper)
        {
        }

        public SeminarsViewModel GetAll(int pageNumber, int pageSize)
        {
            return new SeminarsViewModel
            {
                Results = this.DbSet
                    .OrderBy(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                TotalItemCount = this.DbSet
                    .Count()
            };
        }

        public SeminarViewModel GetById(int id)
        {
            return this.DbSet
                .Select(x => this.Mapper.Map<SeminarViewModel>(x))
                .SingleOrDefault(x => x.Id == id);
        }

        public void Add(SeminarAddCommandModel seminarAddCommandModel)
        {
            var seminar = this.Mapper.Map<Seminar>(seminarAddCommandModel);
            this.AapiSeminarsContext.Seminars.Add(seminar);
            this.AapiSeminarsContext.SaveChanges();
        }

        public void Update(SeminarUpdateCommandModel seminarUpdateCommandModel)
        {
            var seminarToUpdate = this.DbSet
                .SingleOrDefault(x => x.Id == seminarUpdateCommandModel.Id);
            this.Mapper.Map(seminarUpdateCommandModel, seminarToUpdate);
            this.AapiSeminarsContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var seminarToDelete = this.DbSet
                .Single(x => x.Id == id);
            this.AapiSeminarsContext.Seminars.Remove(seminarToDelete);
            this.AapiSeminarsContext.SaveChanges();
        }
    }
}
