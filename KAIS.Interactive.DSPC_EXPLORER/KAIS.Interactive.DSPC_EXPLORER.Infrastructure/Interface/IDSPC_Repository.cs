using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface
{
    public interface IDSPC_Repository
    {
        Task<bool> AddNewRegistrar(Registrar registrar);
        Task<List<Registrar>> GetListRegistrar();

        Task<List<Registrar>> GetListSimpleSearchRegistrar(string FirstName, string LastName);
        Task<Registrar> GetRegistrarByName(string name);
        Task<Registrar> GetRegistrarById(int Id); 
        Task<Registrar> GetRegistrarByReferenceCode(string name);

        Task<bool> AddNewGraveOwner(GraveOwner graveOwner);
        Task<List<GraveOwner>> GetListGraveOwner();
        Task<GraveOwner> GetGraveByReferenceCode(string code);

        Task<bool> AddNewSection(Section section);
        Task<List<Section>> getListSection();
        Task<Section> GetSectionByCode(string code);
        Task<Section> GetSectionById(int id);
        Task<GraveOwnerViewModel> GetGraveOwnerDetailsByRefCode(string code);
        Task<List<Registrar>> SearchGravesByFilterData(GraveSearchFilterModel filter);

    }
}
