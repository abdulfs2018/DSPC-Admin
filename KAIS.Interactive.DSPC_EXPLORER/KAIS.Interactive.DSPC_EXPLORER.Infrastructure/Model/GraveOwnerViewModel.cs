using System;
using System.Collections.Generic;
using System.Text;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class GraveOwnerViewModel
    {
        public string FullName { get; set; }

        public string GraveReferenceCode { get; set; }
        public string GraveSize { get; set; }

        public List<Registrar> Registrars { get; set; }
        public object GraveOwnerAddress { get; internal set; }
    }
}
