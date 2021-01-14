using System;
using System.Reflection;
using HarmonyLib;
using NitroxClient.GameLogic;
using NitroxClient.MonoBehaviours;
using NitroxModel.Core;
using NitroxModel.DataStructures;
using NitroxModel.DataStructures.GameLogic.Buildings.Metadata;
using UnityEngine;

namespace NitroxPatcher.Patches.Dynamic
{
    class BulkheadDoor_ToggleImmediately_Patch : NitroxPatch, IDynamicPatch
    {
        public static readonly Type TARGET_CLASS = typeof(BulkheadDoor);
        public static readonly MethodInfo TARGET_METHOD = TARGET_CLASS.GetMethod("ToggleImmediately", BindingFlags.Instance | BindingFlags.Public);

        public static void Prefix(BulkheadDoor __instance)
        {
            GameObject gameObject = __instance.gameObject.FindAncestor<PrefabIdentifier>().gameObject;
            NitroxId id = NitroxEntity.GetId(__instance.gameObject);

            BulkheadDoorMetadata BulkheadDoorMetadata = new BulkheadDoorMetadata(__instance.isOpen);
            NitroxServiceLocator.LocateService<Building>().MetadataChanged(id, BulkheadDoorMetadata);
        }

        public override void Patch(Harmony harmony)
        {
            PatchPrefix(harmony, TARGET_METHOD);
        }
    }
}
