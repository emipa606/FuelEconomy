using System.Reflection;
using HarmonyLib;
using Mlie;
using UnityEngine;
using Verse;

namespace Fuel_Economy;

public class FuelEconomyMod : Mod
{
    public static Settings Settings;
    public static string CurrentVersion;

    public FuelEconomyMod(ModContentPack content) : base(content)
    {
        // initialize settings
        Settings = GetSettings<Settings>();
        CurrentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
        var harmony = new Harmony("Uuugggg.rimworld.Fuel_Economy.main");
        Harmony.DEBUG = true;
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        Settings.DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "TD.FuelEconomy".Translate();
    }
}