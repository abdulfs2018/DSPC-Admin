using System;
using System.Collections.Generic;
using System.Text;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class Registrar
    {
        public int Id { get; set; }
        public string BookPage { get; set; }
        public int NumberInBook { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string AgeDetail { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; }
        public string DeathLocation { get; set; }
        public string MarriageStatus { get; set; }
        public DateTime DeathDate { get; set; }
        public DateTime BurialDate { get; set; }
        public string Public { get; set; }
        public string Proprietary { get; set; }
        public string SectionInfo { get; set; }
        public string NumberInfo { get; set; }
        public string InternmentSignature { get; set; }
        public string AdditionalComments { get; set; }
        public string RegistrarName { get; set; }
        public GraveOwner GraveOwner { get; set; }
    }
}
