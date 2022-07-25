﻿using Verse;

namespace ESCP_Birthsigns
{
    public class BirthSigns_ModSettings : ModSettings
    {
        private static BirthSigns_ModSettings _instance;

        /* Getters */

        public static bool AllowDisabledRaces => _instance.ESCP_BirthSigns_AllowDisabledRaces;
        public static bool DisableEntirely => _instance.ESCP_BirthSigns_DisableEntirely;
        public static string CurrentSetDef_String => _instance.ESCP_BirthSigns_CurrentSetDef_String;
        public static BirthsignSetDef CurrentSetDef
        {
            get
            {
                return _instance.ESCP_BirthSigns_CurrentSetDef;
            }
            set
            {
                _instance.ESCP_BirthSigns_CurrentSetDef = value;
            }
        }

        /* Variables */

        public bool ESCP_BirthSigns_AllowDisabledRaces = false;
        public bool ESCP_BirthSigns_DisableEntirely = false;
        public string ESCP_BirthSigns_CurrentSetDef_String = null;
        /// <summary>
        /// Never actually saved, as defs aren't loaded until after settings apparently
        /// Instead saved using 'ESCP_BirthSigns_CurrentSetDef_String'
        /// And loaded from in TooltipGenerator.SetInitialBirthsignSet
        /// </summary>
        public BirthsignSetDef ESCP_BirthSigns_CurrentSetDef;

        public BirthSigns_ModSettings()
        {
            _instance = this;
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref ESCP_BirthSigns_AllowDisabledRaces, "ESCP_BirthSigns_AllowDisabledRaces", false);
            Scribe_Values.Look(ref ESCP_BirthSigns_DisableEntirely, "ESCP_BirthSigns_DisableEntirely", false);
            if (ESCP_BirthSigns_CurrentSetDef != null)
            {
                Log.Message("3: String set to current def");
                ESCP_BirthSigns_CurrentSetDef_String = ESCP_BirthSigns_CurrentSetDef.ToString();
            }
            Scribe_Values.Look(ref ESCP_BirthSigns_CurrentSetDef_String, "ESCP_BirthSigns_CurrentSetDef_String", null);
            base.ExposeData();
        }
    }
}
