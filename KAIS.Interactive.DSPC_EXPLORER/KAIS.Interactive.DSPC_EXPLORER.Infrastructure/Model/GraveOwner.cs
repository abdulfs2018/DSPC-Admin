using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class GraveOwner
    {
        [Key]
        public int GraveOwnerId { get; set; }
        public string SubId { get; set; }
        [ForeignKey("GraveReferenceCode")]

        public string JKIndex { get; set; }
        public string GraveReferenceCode { get; set; }
        public int GraveRow { get; set; }
        public int GraveDepth { get; set; }
        public string GraveSize { get; set; }
        public string GraveLocation { get; set; }
        public bool GraveHeadStone { get; set; }
        public string GraveOwnerName { get; set; }
        public string GraveOwnerAddress { get; set; }
        public string Remarks { get; set; }

        public List<Registrar> Registrars { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }

    }
}
