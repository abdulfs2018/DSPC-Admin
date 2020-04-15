
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface
{
    public interface IDSPC_Repository
    {
        Task<bool> AddNewRegistrar(Registrar registrar);
        Task<List<Registrar>> GetListRegistrar();
        Task<Registrar> GetRegistrarByName(string name);
        
    }
}
