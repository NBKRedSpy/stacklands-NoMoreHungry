using System.Reflection;
using HarmonyLib;

namespace NoMoreHungry;

public class Main : Mod
{

	public override void Ready()
	{
		InitializeMod();
	}

	private void InitializeMod()
	{
		
		
		MethodInfo original = AccessTools.Method(typeof(WorldManager), "GetCardRequiredFoodCount");
		MethodInfo method = AccessTools.Method(typeof(Main), "GetCardRequiredFoodCount_Patched");
		
		Harmony.Patch(original, null, new HarmonyMethod(method));
	}

	public static void GetCardRequiredFoodCount_Patched(ref int __result)
	{
		__result = 0;
	}
}
