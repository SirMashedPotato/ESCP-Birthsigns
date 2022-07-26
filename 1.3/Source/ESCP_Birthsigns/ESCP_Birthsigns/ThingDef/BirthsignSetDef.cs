using System.Collections.Generic;
using Verse;

namespace ESCP_Birthsigns
{
    public class BirthsignSetDef : Def
    {
        public List<List<HediffDef>> birthsignHediffs;
        public List<HediffDef> additionalSigns;         ///ignored if left empty
        public float additionalSignsChance = 0.08f;     ///roughly equal chance to a standard birthsign
        public bool canBeDefault = false;               ///If the def can be defaulted to
        /// <summary>
        /// only other values used are: defName, label, description
        /// </summary>

        public override IEnumerable<string> ConfigErrors()
        {
            foreach (string text in base.ConfigErrors())
            {
                yield return text;
            }
            if (label == null || label == "")
            {
                yield return "label is null or blank";
            }
            if (description == null || description == "")
            {
                yield return "desciption is null or blank";
            }
            ///Checking to make sure birthsignHediffs is set up correctly
            bool flag = false;
            if (birthsignHediffs.NullOrEmpty())
            {
                yield return "birthsignHediffs is null or empty";
                flag = true;
            } 
            else
            {
                if (birthsignHediffs.Count != 4)
                {
                    yield return "birthsignHediffs does not contain exactly 4 season groups";
                    flag = true;
                } 
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (birthsignHediffs[i].Count != 3)
                        {
                            yield return "birthsignHediffs does not contain exactly 3 hediffs in season group: " + (i+1) + ", starting with: " + (birthsignHediffs[i].NullOrEmpty() ? "Null" : birthsignHediffs[i][0].defName);
                            flag = true;
                        }
                    }
                }
            }
            if (flag)
            {
                yield return "errors found, this will cause out of bounds exceptions";
            }
            yield break;
        }
    }
}
