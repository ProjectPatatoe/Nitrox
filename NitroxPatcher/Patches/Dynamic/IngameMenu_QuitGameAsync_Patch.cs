using System;
using System.Reflection;
using HarmonyLib;
using NitroxModel.Logger;
using UnityEngine;

namespace NitroxPatcher.Patches.Dynamic
{
    class IngameMenu_QuitGameAsync_Patch : NitroxPatch, IDynamicPatch
    {
        public static readonly Type TARGET_CLASS = typeof(IngameMenu);
        public static readonly MethodInfo TARGET_METHOD = TARGET_CLASS.GetMethod("QuitGameAsync");

        public static bool Prefix(bool quitToDesktop)
        {
            Log.Debug("quitToDesktop:" + quitToDesktop);
            if (!quitToDesktop)
            {
                UWE.Utils.lockCursor = false;
                return true;
            }
            else
            {
                Application.Quit();
                return false;
            }
            //return false;
        }

        public override void Patch(Harmony harmony)
        {
            PatchPrefix(harmony, TARGET_METHOD);
        }
    }
}
