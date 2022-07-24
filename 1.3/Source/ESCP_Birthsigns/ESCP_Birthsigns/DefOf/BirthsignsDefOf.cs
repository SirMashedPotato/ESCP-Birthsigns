using RimWorld;

namespace ESCP_Birthsigns
{
	[DefOf]
	public static class BirthsignsDefOf
	{

		static BirthsignsDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(BirthsignsDefOf));
		}

		public static BirthsignsDef ESCP_StandardBirthsigns;
	}
}
