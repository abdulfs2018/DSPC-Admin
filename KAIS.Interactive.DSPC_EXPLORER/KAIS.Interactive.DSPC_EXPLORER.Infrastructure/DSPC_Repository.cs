
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure
{
    public class DSPC_Repository : IDSPC_Repository
    {
        private DSPC_ExplorerDbContext _dbContext;

        public DSPC_Repository(DSPC_ExplorerDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> AddNewRegistrar(Registrar registrar)
        {
            //var existingRegistrars = _dbContext.Registrars.AllAsync(); ;
            throw new System.NotImplementedException();
        }

        public async Task<List<Registrar>> GetListRegistrar()
        {
            return await _dbContext.Registrars.ToListAsync();
        }

        public async Task<Registrar> GetRegistrarByName(string name)
        {
            return await (from r in _dbContext.Registrars
                          where r.Equals(name)
                          select new Registrar
                          {
                              FirstName = r.FirstName,

                          }).FirstOrDefaultAsync();
        }

        public async Task<bool> AddNewGraveOwner(GraveOwner graveOwner)
        {

            var data = await (from grave in _dbContext.GraveOwners
                        from section in _dbContext.Sections
                        where grave.GraveReferenceCode == graveOwner.GraveReferenceCode && section.Id == graveOwner.Section.Id
                        select new GraveOwner
                        {
                            Id = grave.Id,
                            Section = new Section
                            {
                                Id = section.Id
                            }
                        }).FirstOrDefaultAsync();

            if(data == null)
            {

                // Use a get on GraveOwner based on the Section Code used, then use this section if exists

                //graveOwner.Section = new Section()
                //{
                //    Id = data.Section.Id,
                //    Code = data.Section.Code,
                //    DateOpened = data.Section.DateOpened,
                //    GraveCount =data.Section.GraveCount
                //};

                _dbContext.GraveOwners.Add(graveOwner);
                int status = _dbContext.SaveChanges();

                return status > 0;
            }

            return false;

        }

        public async Task<bool> AddNewSection(Section section)
        {
            var data = await (from s in _dbContext.Sections
                              where s.Id == section.Id
                              select new Section
                              {
                                  Id = s.Id,
                                  Code = s.Code,
                                  DateOpened = s.DateOpened,
                                  GraveCount = s.GraveCount
                              }).FirstOrDefaultAsync();

            if (data == null)
            {
                _dbContext.Sections.Add(section);
                int status = _dbContext.SaveChanges();

                return status > 0;
            }

            return false;
        }

        public async Task<List<Section>> getListSection()
        {
            return await _dbContext.Sections.ToListAsync();
        }

        public async Task<List<GraveOwner>> GetListGraveOwner()
        {
            return await _dbContext.GraveOwners.ToListAsync();
        }

        public async Task<Section> GetSectionByCode(string code)
        {
            return await (from section in _dbContext.Sections
                          where section.Code == code
                          select new Section
                          {
                              Id = section.Id,
                              Code = section.Code,
                              DateOpened = section.DateOpened,
                              GraveCount = section.GraveCount,
                          }).FirstOrDefaultAsync();

        }

    }
}
