using Aapi.Seminars.Contexts;
using Aapi.Seminars.Models;
using Aapi.Seminars.Models.Seminars;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Aapi.Seminars.DataServices
{
    public interface ISeminarsDataService
    {
        Task<SeminarsViewModel> GetAll(int pageNumber, int pageSize);
        Task<SeminarViewModel> GetById(int id);
        Task Add(SeminarAddCommandModel seminarAddCommandModel);
        Task Update(SeminarUpdateCommandModel seminarUpdateCommandModel);
        Task Delete(int id);
    }

    public class SeminarsDataService : DataServiceBase<Seminar>, ISeminarsDataService
    {
        public SeminarsDataService(IAapiSeminarsContext aapiSeminarsContext, IMapper mapper)
            : base(aapiSeminarsContext, mapper)
        {
        }

        public async Task<SeminarsViewModel> GetAll(int pageNumber, int pageSize)
        {
            return new SeminarsViewModel
            {
                Results = await this.DbSet
                    .OrderBy(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                TotalItemCount = await this.DbSet
                    .CountAsync()
            };
        }

        public async Task<SeminarViewModel> GetById(int id)
        {
            return await this.DbSet
                .Select(x => this.Mapper.Map<SeminarViewModel>(x))
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(SeminarAddCommandModel seminarAddCommandModel)
        {
            var seminar = this.Mapper.Map<Seminar>(seminarAddCommandModel);
            this.AapiSeminarsContext.Seminars.Add(seminar);
            await this.AapiSeminarsContext.SaveChangesAsync();
        }

        public async Task Update(SeminarUpdateCommandModel seminarUpdateCommandModel)
        {
            var seminarToUpdate = await this.DbSet
                .SingleOrDefaultAsync(x => x.Id == seminarUpdateCommandModel.Id);
            this.Mapper.Map(seminarUpdateCommandModel, seminarToUpdate);
            await this.AapiSeminarsContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var seminarToDelete = await this.DbSet
                .SingleAsync(x => x.Id == id);
            this.AapiSeminarsContext.Seminars.Remove(seminarToDelete);
            await this.AapiSeminarsContext.SaveChangesAsync();
        }
    }
}
