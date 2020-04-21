using System;
using System.Collections.Generic;

namespace KAIS.Interactive.DSPC_EXPLORER.Common.Services.Enums
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

    public enum SizeOfGrave
    {
        S = 3,
        D = 6,
        T = 9,
        Q = 12,
        L = 1000
    }

    public static class GeneralEnums
    {

        static readonly Dictionary<SectionType, int> sectionMapping =
            new Dictionary<SectionType, int> {
                { SectionType.Z, 1 },
                { SectionType.A, 2 },
                { SectionType.B, 3 },
                { SectionType.C, 4 },
                { SectionType.D, 5 },
                { SectionType.E, 6 },
                { SectionType.F, 7 }
            };

        static readonly Dictionary<SizeOfGrave, int> graveSizeMapping =
            new Dictionary<SizeOfGrave, int> {
                { SizeOfGrave.S, 3 },
                { SizeOfGrave.D, 6 },
                { SizeOfGrave.T, 9 },
                { SizeOfGrave.Q, 12 },
                { SizeOfGrave.L, 1000 },
            };


        public static int GetSectionNumberFromLetter(SectionType section)
        {

            int sectionCode;

            if (sectionMapping.TryGetValue(section, out sectionCode))
            {
                return sectionCode;
            }

            return 0;
        }

        public static int GetGraveSizeFromLetter(SizeOfGrave size)
        {
            int graveSize;

            if (graveSizeMapping.TryGetValue(size, out graveSize))
            {
                return graveSize;
            }

            return 0;
        }
    }
}
