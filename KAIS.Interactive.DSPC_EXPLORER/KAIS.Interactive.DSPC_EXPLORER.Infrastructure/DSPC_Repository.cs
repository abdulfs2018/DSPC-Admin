
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
        public async Task<bool> AddNewCompanyRecord(Registrar registrar)
        {
            //var existingRegistrars = _dbContext.Registrars.AllAsync(); ;
            throw new System.NotImplementedException();
        }

        public async Task<List<Registrar>> GetCompanyRecords()
        {
            throw new System.NotImplementedException();
        }
    }
}
