using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace Fuel_Economy;

internal static class LaunchableMethods
{
    // emptyPercent of 50% means a pod weighs 150kg, so a full pod weighs 300kg and an empty pod costs 50% fuel, and can go 2x as far
    // 0% means it's weightless, can send empty pod with 0% fuel
    // 100% means essentially infinite weight, all fuel is used to launch pod and the content doesn't matter, and that's vanilla so why do that
    private const float vanillaFuelPerTile = 2.25f;

    private const float SmallPodEfficiency = 5; //TODO DefExtensions to make this a xml value?

    private static readonly PropertyInfo transportersInGroupInfo =
        AccessTools.Property(typeof(CompLaunchable), "TransportersInGroup");

    public static float UpdatedFuelPerTile(CompLaunchable launchable)
    {
        var emptyPercent = FuelEconomyMod.Settings.EmptyPercent;
        var fuelPerTileBase = vanillaFuelPerTile * (emptyPercent + ((1 - emptyPercent) * percentFull(launchable)));
        if (launchable.parent.def != SmallPodDefOf.TransportPodSmall)
        {
            return fuelPerTileBase;
        }

        return fuelPerTileBase / SmallPodEfficiency; //TODO: DefExtension and just divide by that value
    }

    private static float percentFull(CompLaunchable launchable)
    {
        float mass = 0;
        float max = 0;
        var transporters = (List<CompTransporter>)transportersInGroupInfo.GetValue(launchable);
        foreach (var transporter in transporters)
        {
            foreach (var t in transporter.GetDirectlyHeldThings())
            {
                mass += t.GetStatValue(StatDefOf.Mass) * t.stackCount;
            }

            max += transporter.Props.massCapacity;
        }

        return mass / max;
    }
}