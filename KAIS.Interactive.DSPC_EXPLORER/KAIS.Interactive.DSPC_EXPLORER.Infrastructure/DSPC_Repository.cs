
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


            var data = (from grave in _dbContext.GraveOwners
                        from section in _dbContext.Sections
                        where grave.GraveReferenceCode == graveOwner.GraveReferenceCode && section.Id == graveOwner.Section.Id
                        select new GraveOwner
                        {
                            Id = grave.Id,
                            Section = new Section
                            {
                                Id = section.Id
                            }
                        }).FirstOrDefault();

            if(data == null)
            {

                graveOwner.Section = new Section()
                {
                    Id = data.Section.Id,
                    Code = data.Section.Code,
                    DateOpened = data.Section.DateOpened,
                    GraveCount =data.Section.GraveCount
                };

                _dbContext.GraveOwners.Add(graveOwner);
                int status = _dbContext.SaveChanges();

                return status > 0;
            }

            return false;

        }

    }
}
