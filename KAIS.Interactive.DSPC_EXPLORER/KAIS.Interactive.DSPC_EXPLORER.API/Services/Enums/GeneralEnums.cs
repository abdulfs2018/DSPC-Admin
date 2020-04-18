using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.API.Services.Enums
{

    public enum SectionType
    {
        Z = 1,
        A = 2,
        B = 3,
        C = 4,
        D = 5,
        E = 6,
        F = 7,
    }

    public class GeneralEnums
    {

       

        readonly Dictionary<SectionType, int> sectionMapping = 
            new Dictionary<SectionType, int> {
                { SectionType.Z, 1 },
                { SectionType.A, 2 },
                { SectionType.B, 3 },
                { SectionType.C, 4 },
                { SectionType.D, 5 },
                { SectionType.E, 6 },
                { SectionType.F, 7 }
            };


        public int GetSectionNumberFromLetter(SectionType section)
        {
            return sectionMapping[section];
        }
        
    }

}
