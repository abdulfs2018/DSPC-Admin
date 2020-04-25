﻿using System;
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

                            var dataGrave = GetGraveByReferenceCode(registrar.GraveOwner.GraveReferenceCode);
                            var dataSection = dataGrave.Result.Section;

                            if (dataSection != null && dataGrave != null)
                            {
                                registrar.GraveOwner = dataGrave.Result;
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
            return await /*(from section in*/ _dbContext.Sections
                          .Where(e => e.Code == code)
                          .FirstOrDefaultAsync();
                          
                          //where section.Code == code
                          //select new Section
                          //{
                          //    Id = section.Id,
                          //    Code = section.Code,
                          //    DateOpened = section.DateOpened,
                          //    GraveCount = section.GraveCount,
                          //}).FirstOrDefaultAsync();

        }

        public async Task<Section> GetSectionById(int id)
        {
            return await /*(from section in */_dbContext.Sections
                          .Where(e => e.Id == id)
                          .FirstOrDefaultAsync();
                          //where section.Id == id
                          //select new Section
                          //{
                          //    Id = section.Id,
                          //    Code = section.Code,
                          //    DateOpened = section.DateOpened,
                          //    GraveCount = section.GraveCount,
                          //}).FirstOrDefaultAsync();

        }

        public async Task<GraveOwner> GetGraveByReferenceCode(string code)
        {
            return await _dbContext.GraveOwners
                .Where(e => e.GraveReferenceCode == code)
                .FirstOrDefaultAsync();

                          //where grave.GraveReferenceCode == code
                          //select new GraveOwner
                          //{
                          //    Id = grave.Id,
                          //    SubId = grave.SubId,
                          //    GraveReferenceCode = grave.GraveReferenceCode,
                          //    GraveRow = grave.GraveRow,
                          //    GraveDepth = grave.GraveDepth,
                          //    GraveSize = grave.GraveSize,
                          //    GraveLocation = grave.GraveLocation,
                          //    GraveHeadStone = grave.GraveHeadStone,
                          //    GraveOwnerName = grave.GraveOwnerName,
                          //    GraveOwnerAddress = grave.GraveOwnerAddress,
                          //    Remarks = grave.Remarks,
                          //    Section = new Section
                          //    {
                          //        Id = grave.Section.Id,
                          //        Code = grave.Section.Code,
                          //        DateOpened = grave.Section.DateOpened,
                          //        GraveCount = grave.Section.GraveCount,
                          //    }
                          //}).FirstOrDefaultAsync();
        }

        public async Task<Registrar> GetRegistrarByReferenceCode(string code)
        {
            // this is also not good.. because there more than one registrar with grave ref code -> talk to kieron
            return await _dbContext.Registrars
                            .Include(e => e.GraveOwner)
                            .Where(e => e.GraveOwner.GraveReferenceCode == code).FirstOrDefaultAsync(); 
                          //where person.GraveOwner.GraveReferenceCode == code
                          //select new Registrar
                          //{
                          //    BookPage = person.BookPage,
                          //    NumberInBook = person.NumberInBook,
                          //    FirstName = person.FirstName,
                          //    LastName = person.LastName,
                          //    Sex = person.Sex,
                          //    Age = person.Age,
                          //    AgeDetail = person.AgeDetail,
                          //    Religion = person.Religion,
                          //    Occupation = person.Occupation,
                          //    DeathLocation = person.DeathLocation,
                          //    MarriageStatus = person.MarriageStatus,
                          //    DeathDate = person.DeathDate,
                          //    BurialDate = person.BurialDate,
                          //    GraveOwner = new GraveOwner
                          //    {
                          //        Id = person.GraveOwner.Id,
                          //        SubId = person.GraveOwner.SubId,
                          //        GraveReferenceCode = person.GraveOwner.GraveReferenceCode,
                          //        GraveRow = person.GraveOwner.GraveRow,
                          //        GraveDepth = person.GraveOwner.GraveDepth,
                          //        GraveSize = person.GraveOwner.GraveSize,
                          //        GraveLocation = person.GraveOwner.GraveLocation,
                          //        GraveHeadStone = person.GraveOwner.GraveHeadStone,
                          //        GraveOwnerName = person.GraveOwner.GraveOwnerName,
                          //        GraveOwnerAddress = person.GraveOwner.GraveOwnerAddress,
                          //        Remarks = person.GraveOwner.Remarks,
                          //        Section = new Section
                          //        {
                          //            Id = person.GraveOwner.Section.Id,
                          //            Code = person.GraveOwner.Section.Code,
                          //            DateOpened = person.GraveOwner.Section.DateOpened,
                          //            GraveCount = person.GraveOwner.Section.GraveCount,
                          //        }
                          //    },
                          //    Public = person.Public,
                          //    Proprietary = person.Proprietary,
                          //    SectionInfo = person.SectionInfo,
                          //    NumberInfo = person.NumberInfo,
                          //    InternmentSignature = person.InternmentSignature,
                          //    AdditionalComments = person.AdditionalComments,
                          //    RegistrarName = person.RegistrarName,
                          //}).FirstOrDefaultAsync();
        }

        public async Task<List<Registrar>> GetRegistrarsByGraveReferenceCode(string refCode)
        {
            return await _dbContext.Registrars
                        .Include(e => e.GraveOwner)
                        .Where(e => e.GraveOwner.GraveReferenceCode == refCode)
                        .ToListAsync();
                          //where person.GraveOwner.GraveReferenceCode == refCode
                          //select new Registrar
                          //{
                          //    BookPage = person.BookPage,
                          //    NumberInBook = person.NumberInBook,
                          //    FirstName = person.FirstName,
                          //    LastName = person.LastName,
                          //    Sex = person.Sex,
                          //    Age = person.Age,
                          //    AgeDetail = person.AgeDetail,
                          //    Religion = person.Religion,
                          //    Occupation = person.Occupation,
                          //    DeathLocation = person.DeathLocation,
                          //    MarriageStatus = person.MarriageStatus,
                          //    DeathDate = person.DeathDate,
                          //    BurialDate = person.BurialDate,
                          //    GraveOwner = new GraveOwner
                          //    {
                          //        Id = person.GraveOwner.Id,
                          //        SubId = person.GraveOwner.SubId,
                          //        GraveReferenceCode = person.GraveOwner.GraveReferenceCode,
                          //        GraveRow = person.GraveOwner.GraveRow,
                          //        GraveDepth = person.GraveOwner.GraveDepth,
                          //        GraveSize = person.GraveOwner.GraveSize,
                          //        GraveLocation = person.GraveOwner.GraveLocation,
                          //        GraveHeadStone = person.GraveOwner.GraveHeadStone,
                          //        GraveOwnerName = person.GraveOwner.GraveOwnerName,
                          //        GraveOwnerAddress = person.GraveOwner.GraveOwnerAddress,
                          //        Remarks = person.GraveOwner.Remarks,
                          //        Section = new Section
                          //        {
                          //            Id = person.GraveOwner.Section.Id,
                          //            Code = person.GraveOwner.Section.Code,
                          //            DateOpened = person.GraveOwner.Section.DateOpened,
                          //            GraveCount = person.GraveOwner.Section.GraveCount,
                          //        }
                          //    },
                          //    Public = person.Public,
                          //    Proprietary = person.Proprietary,
                          //    SectionInfo = person.SectionInfo,
                          //    NumberInfo = person.NumberInfo,
                          //    InternmentSignature = person.InternmentSignature,
                          //    AdditionalComments = person.AdditionalComments,
                          //    RegistrarName = person.RegistrarName,
                          //}).ToListAsync();

        }




    }
}
