using System;
using System.Reflection;
using HarmonyLib;

namespace NoMoreHungry;

public class Plugin : Mod
{

	public static ConfigEntry<int> MaxFoodRequirement { get; set; }

	public static ConfigEntry<bool> EmulateFeeding { get; set; }
	public static ModLogger Log { get; set; }	

	public override void Ready()
	{
		MaxFoodRequirement = Config.GetEntry<int>("MaxFoodRequirement", 0, new ConfigUI()
		{
			Name = "Max Food Requirement",
			Tooltip = 
@"The maximum amount of food a villager will require.  
Set to zero to not require food.
The base game normally requires up to two food per villager."
		});

		EmulateFeeding = Config.GetEntry<bool>("Emulate Feeding", true, new ConfigUI()
		{
			Tooltip = 
@"If using zero for required food (no food required), 
this mod will emulate feeding which allows villagers to heal.  
This should remain on and is available only in case there 
is a bug in the feeding functionality."
		});


		MaxFoodRequirement.OnChanged += ValidateMaxFoodRequirement;

		Log = Logger;


		Harmony.PatchAll();
	}

	private static void ValidateMaxFoodRequirement(int newValue)
	{
		if(newValue < 0)
		{
			MaxFoodRequirement.Value = 0;
		}
	}

}
