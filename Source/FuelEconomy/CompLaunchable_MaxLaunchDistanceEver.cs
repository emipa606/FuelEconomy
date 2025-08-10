using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;

namespace Fuel_Economy;

[HarmonyPatch(typeof(CompLaunchable), nameof(CompLaunchable.MaxLaunchDistanceEver))]
public static class CompLaunchable_MaxLaunchDistanceEver
{
    private const int VanillaMax = 66;

    public static void Postfix(ref int __result, CompLaunchable __instance, PlanetLayer layer)
    {
        if (__result == 0)
        {
            return;
        }

        if (__instance is not CompLaunchable_TransportPod)
        {
            return;
        }

        var fuelPerTile = LaunchableMethods.UpdatedFuelPerTile(__instance);
        if (__instance.Props.fixedLaunchDistanceMax >= 0)
        {
            __result = __instance.Props.fixedLaunchDistanceMax;
        }
        else if (__instance.FuelLevel < __instance.Props.minFuelCost)
        {
            __result = 0;
        }
        else
        {
            __result = Mathf.FloorToInt(__instance.FuelLevel / (fuelPerTile * layer.Def.rangeDistanceFactor));
        }

        if (__instance.Props.fixedLaunchDistanceMax >= 0)
        {
            __result = Mathf.Min(__result,
                Mathf.RoundToInt(__instance.Props.fixedLaunchDistanceMax / layer.Def.rangeDistanceFactor));
        }

        if (!FuelEconomyMod.Settings.PastVanillaMaxRange && __result > VanillaMax)
        {
            __result = VanillaMax;
        }
    }
}