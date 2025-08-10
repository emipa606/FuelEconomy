using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Fuel_Economy;

[HarmonyPatch(typeof(Dialog_LoadTransporters), "CheckForErrors")]
internal class Dialog_LoadTransporters_CheckForErrors
{
    public static void Postfix(ref bool __result, List<CompTransporter> ___transporters,
        List<TransferableOneWay> ___transferables)
    {
        if (!__result)
        {
            return;
        }

        if (___transporters.Any(t => t.parent.def != SmallPodDefOf.TransportPodSmall))
        {
            return;
        }

        var maxMass = ___transporters[0].Props.massCapacity;
        if (___transferables.Any(t => t.CountToTransfer > 0 && t.AnyThing is Pawn))
        {
            Messages.Message("TD.SmallTransportPodItemsOnly".Translate(), MessageTypeDefOf.RejectInput);
            __result = false;
            return;
        }

        if (!___transferables.Any(t => t.CountToTransfer > 0 && t.AnyThing.GetStatValue(StatDefOf.Mass) > maxMass))
        {
            return;
        }

        Messages.Message("TD.SmallTransportPodTooLarge".Translate(maxMass), MessageTypeDefOf.RejectInput);
        __result = false;
    }
}