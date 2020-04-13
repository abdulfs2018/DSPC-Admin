
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface
{
    public interface IDSPC_Repository
    {

        Task AddNewUser(User user);
    }
}
