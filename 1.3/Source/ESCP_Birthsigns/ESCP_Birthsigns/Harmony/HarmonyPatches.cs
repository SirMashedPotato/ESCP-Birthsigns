﻿using HarmonyLib;
using Verse;
using System.Reflection;

namespace ESCP_Birthsigns
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_Birthsigns");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(PawnGenerator))]
    [HarmonyPatch("GenerateInitialHediffs")]
    public static class PawnGenerator_GenerateInitialHediffs_Patch
    {
        [HarmonyPostfix]
        public static void BirthsignPatch(Pawn pawn, PawnGenerationRequest request)
        {
            if (pawn.RaceProps.Humanlike && BirthsignExclusion.Get(pawn.def) == null)
            {
                BirthsignsDef signs = BirthsignsDefOf.ESCP_StandardBirthsigns;
                HediffDef signDef;
                if (!signs.additionalSigns.NullOrEmpty() && Rand.Chance(signs.additionalSignsChance))
                {
                    signDef = signs.additionalSigns.RandomElement();
                }
                else
                {
                    int quadrum = (int)pawn.ageTracker.BirthQuadrum;
                    int day = pawn.ageTracker.BirthDayOfYear;
                    int monthIndex = day;
                    while (monthIndex - 15 > -1)    ///-1 to account for the possibility of an index of exactly 0 for 60 days
                    {
                        monthIndex -= 15;
                    }
                    monthIndex /= 5;
                    signDef = signs.birthsignHediffs[quadrum][monthIndex];
                }
                pawn.health.AddHediff(signDef);
            }
        }
    }
}
