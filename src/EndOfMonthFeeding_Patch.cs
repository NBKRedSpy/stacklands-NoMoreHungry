using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace NoMoreHungry
{
	[HarmonyPatch(typeof(WorldManager), "EndOfMonthRoutine")]
	public static class EndOfMonthFeeding_Patch
	{
		private static MethodInfo TryCreatePoopMethod;


        static EndOfMonthFeeding_Patch()
        {
			TryCreatePoopMethod = AccessTools.Method(typeof(EndOfMonthCutscenes), "TryCreatePoop");
		}

        public static void Prefix()
		{

			//Emulate health increase.
			//The game will only heal units if they are in the feed list and are fed.
			//	with zero food, this will never occur.
			if(Plugin.MaxFoodRequirement.Value == 0 && Plugin.EmulateFeeding.Value)
			{
				foreach (CardData cardToFeed in EndOfMonthCutscenes.GetCardsToFeed())
				{
					if (cardToFeed is BaseVillager villager)
					{
						villager.HealthPoints = Mathf.Min(villager.HealthPoints + 3, villager.ProcessedCombatStats.MaxHealth);
						TryCreatePoopMethod.Invoke(null, new object[] { villager });
					}
				} 
			}
		}

    }
}
