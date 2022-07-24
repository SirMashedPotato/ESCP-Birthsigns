﻿using System.Collections.Generic;
using Verse;

namespace ESCP_Birthsigns
{
    public class BirthsignsDef : Def
    {
        public List<List<HediffDef>> birthsignHediffs;
        public List<HediffDef> additionalSigns;         ///ignored if left empty
        public float additionalSignsChance = 0.08f;     ///roughly equal chance to a standard birthsign
        /// <summary>
        /// only other values used are: defName, label, description
        /// </summary>

        public override IEnumerable<string> ConfigErrors()
        {
            return base.ConfigErrors();
        }
    }
}
