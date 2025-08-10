using HarmonyLib;
using RimWorld;
using RimWorld.Planet;

namespace Fuel_Economy;

[HarmonyPatch(typeof(CompLaunchable), nameof(CompLaunchable.FuelNeededToLaunchAtDist))]
public static class CompLaunchable_FuelNeededToLaunchAtDist
{
    public static void Postfix(float dist, PlanetLayer layer, ref float __result, CompLaunchable __instance)
    {
        if (__instance is not CompLaunchable_TransportPod)
        {
            return;
        }

        var fuelPerTile = LaunchableMethods.UpdatedFuelPerTile(__instance);

        var num = dist * (fuelPerTile * layer.Def.rangeDistanceFactor);
        if (__instance.Props.minFuelCost > 0f && num < __instance.Props.minFuelCost)
        {
            __result = __instance.Props.minFuelCost;
        }
        else
        {
            __result = num;
        }
    }
}