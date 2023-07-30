using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace NoMoreHungry
{
	[HarmonyPatch(typeof(WorldManager), nameof(WorldManager.GetCardRequiredFoodCount))]
	public static class WorldManagerFood_Patch
	{

		public static void Prefix(GameCard c, ref bool __runOriginal, ref int __result)
		{
			__runOriginal = false;

			if (c.CardData is BaseVillager baseVillager)
			{

				__result =  Math.Min(baseVillager.GetRequiredFoodCount(), Plugin.MaxFoodRequirement.Value);
				return;
			}
			if (c.CardData is Kid)
			{
				__result = Math.Min(1, Plugin.MaxFoodRequirement.Value);
				return;
			}
			__result = 0;
			return;

		}

	}
}
