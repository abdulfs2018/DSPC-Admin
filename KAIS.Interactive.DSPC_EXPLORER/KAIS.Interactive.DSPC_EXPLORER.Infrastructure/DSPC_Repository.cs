using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAIS.Interactive.DSPC_EXPLORER.Common.Services.Enums;
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

            var data = await (from grave in _dbContext.GraveOwners
                              where grave.GraveReferenceCode == registrar.GraveOwner.GraveReferenceCode
                              select new GraveOwner
                                  {
                                      Id = grave.Id,
                                      GraveSize = grave.GraveSize,
                                      GraveReferenceCode = grave.GraveReferenceCode,
                                      Section = new Section
                                      {
                                          Id = grave.Section.Id,
                                      },
                                  }).FirstOrDefaultAsync();

            if (data != null)
            {
                SizeOfGrave graveSizeEnum = (SizeOfGrave)Enum.Parse(typeof(SizeOfGrave), data.GraveSize);
                int graveSize = GeneralEnums.GetGraveSizeFromLetter(graveSizeEnum);

                if (graveSize > 0)
                    {
                        int currentPeopleSize = GetRegistrarsByGraveReferenceCode(data.GraveReferenceCode).Result.Count;

                        if (currentPeopleSize < graveSize || registrar.Age < 11 || (registrar.AdditionalComments != null && registrar.AdditionalComments.ToUpper() == "JK"))
                        {

                            var dataGrave = GetGraveByReferenceCode(registrar.GraveOwner.GraveReferenceCode).Result;
                        var dataSection = dataGrave.Section;

                            if (dataSection.Code != null && dataGrave != null)
                            {
                                registrar.GraveOwner = dataGrave;
                                registrar.GraveOwner.Section = dataSection;
                                _dbContext.Entry(registrar.GraveOwner).State = EntityState.Unchanged;
                                _dbContext.Entry(registrar.GraveOwner.Section).State = EntityState.Unchanged;
                                _dbContext.Registrars.Add(registrar);
                                int status = _dbContext.SaveChanges();
                                return status > 0;
                            }
                        }
                    }     
            }
            return false;
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
                              where grave.GraveReferenceCode == graveOwner.GraveReferenceCode && section.Code == graveOwner.Section.Code
                              select new GraveOwner
                              {
                                  Id = grave.Id,
                                  GraveReferenceCode = grave.GraveReferenceCode,
                                  Section = new Section
                                  {
                                      Id = section.Id
                                  }
                              }).FirstOrDefaultAsync();

            SizeOfGrave graveSizeEnum = (SizeOfGrave)Enum.Parse(typeof(SizeOfGrave), graveOwner.GraveSize);
            int graveSize = GeneralEnums.GetGraveSizeFromLetter(graveSizeEnum);

            if (data == null && graveSize != 0)
            {
                var dataSection = GetSectionByCode(graveOwner.Section.Code);

                if (dataSection != null)
                {

                    graveOwner.Section = dataSection.Result;

                    _dbContext.Entry(graveOwner.Section).State = EntityState.Unchanged;
                    _dbContext.GraveOwners.Add(graveOwner);
                    int status = _dbContext.SaveChanges();

                    return status > 0;
                }

            }

            return false;

        }

        public async Task<bool> AddNewSection(Section section)
        {
            var data = await (from s in _dbContext.Sections
                              where s.Code == section.Code
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
            return await _dbContext.Sections
                          .Where(e => e.Code == code)
                          .FirstOrDefaultAsync();                        
        }

        public async Task<Section> GetSectionById(int id)
        {
            return await  _dbContext.Sections
                          .Where(e => e.Id == id)
                          .FirstOrDefaultAsync();

        }

        public async Task<GraveOwner> GetGraveByReferenceCode(string code)
        {
            return await _dbContext.GraveOwners
                .Include(e => e.Section)
                .Where(e => e.GraveReferenceCode == code)
                .FirstOrDefaultAsync();
        }

        public async Task<Registrar> GetRegistrarByReferenceCode(string code)
        {
            return await _dbContext.Registrars
                            .Include(e => e.GraveOwner)
                            .Where(e => e.GraveOwner.GraveReferenceCode == code).FirstOrDefaultAsync(); 
        }

        public async Task<List<Registrar>> GetRegistrarsByGraveReferenceCode(string refCode)
        {
            return await _dbContext.Registrars
                        .Include(e => e.GraveOwner)
                        .Include(e => e.GraveOwner).ThenInclude(e => e.Section)
                        .Where(e => e.GraveOwner.GraveReferenceCode == refCode)
                        .ToListAsync();
                    

        }

        public async Task<GraveOwnerViewModel> GetGraveOwnerDetailsByRefCode(string code)
        {
            var reg = GetRegistrarsByGraveReferenceCode(code);

            return await (from e in _dbContext.GraveOwners
                              join r in _dbContext.Registrars on e.GraveReferenceCode equals r.GraveOwner.GraveReferenceCode
                              where e.GraveReferenceCode.Equals(code)
                              select new GraveOwnerViewModel
                              {
                                  FullName =  e.GraveOwnerName,
                                  GraveReferenceCode = e.GraveReferenceCode,
                                  GraveSize = e.GraveSize,
                                  Registrars = reg.Result.ToList()
                              }).FirstOrDefaultAsync();

        }




    }
}
