using UnityEngine;
using Verse;

namespace Fuel_Economy;

public class Settings : ModSettings
{
    public float EmptyPercent = 0.5f;
    public bool PastVanillaMaxRange;

    public void DoWindowContents(Rect rect)
    {
        var options = new Listing_Standard();
        options.Begin(rect);

        options.Label("TD.FuelSettingsDesc".Translate());
        options.CheckboxLabeled("TD.SettingExtendRange".Translate(), ref PastVanillaMaxRange);

        options.Gap();
        options.Label("TD.SettingEmptyPercent".Translate() + $" ({EmptyPercent:P})");
        EmptyPercent = options.Slider(EmptyPercent, 0, 1);
        options.Label("TD.EmptyPercentDesc".Translate());
        if (FuelEconomyMod.CurrentVersion != null)
        {
            options.Gap();
            GUI.contentColor = Color.gray;
            options.Label("TD.CurrentModVersion".Translate(FuelEconomyMod.CurrentVersion));
            GUI.contentColor = Color.white;
        }

        options.End();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref PastVanillaMaxRange, "vanillaMaxRange");
        Scribe_Values.Look(ref EmptyPercent, "emptyPercent", 0.5f);
    }
}