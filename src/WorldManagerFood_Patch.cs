using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace NoMoreHungry
{
	[HarmonyPatch(typeof(WorldManager), nameof(WorldManager.GetCardRequiredFoodCount))]
	public static class WorldManagerFood_Patch
	{

		public static void Postfix(GameCard c, ref bool __runOriginal, ref int __result)
		{
			__result = Math.Min(__result, Plugin.MaxFoodRequirement.Value);
		}

	}
}
