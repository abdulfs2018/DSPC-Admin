using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class GraveSearchFilterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string AgeDetail { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; }
        public string DeathLocation { get; set; }
        public string MarriageStatus { get; set; }
        public string GraveOwnerName { get; set; }
        public string GraveOwnerAddress { get; set; }
        public string GraveSize { get; set; }
    }
}
