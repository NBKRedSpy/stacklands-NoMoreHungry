using System.Reflection;
using HarmonyLib;

namespace NoMoreHungry;

public class Plugin : Mod
{

	public static ConfigEntry<int> MaxFoodRequirement { get; set; }
	public static ModLogger Log { get; set; }	

	public override void Ready()
	{
		MaxFoodRequirement = Config.GetEntry<int>("MaxFoodRequirement", 0, new ConfigUI()
		{
			Name = "Max Food Requirement",
			//NameTerm = "NoMoreHungry_MaxFoodRequirement_Name",
			Tooltip = @"
The maximum amount of food a villager will require.  
Set to zero to not require food.
The base game normally requires up to two food per villager."
			//TooltipTerm = "NoMoreHungry_MaxFoodRequirement_Toolikp",
		});

		Log = Logger;


		Harmony.PatchAll();
	}
}
