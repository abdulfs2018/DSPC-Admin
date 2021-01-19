using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public string Code { get; set; }
        public DateTime DateOpened { get; set; }
        public int GraveCount { get; set; }

        public List<GraveOwner> GraveOwners { get; set; }
    }
}
