
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface
{
    public interface IDSPC_Repository
    {
        Task<bool> AddNewCompanyRecord(Registrar registrar);
        Task<List<Registrar>> GetCompanyRecords();
        
    }
}
