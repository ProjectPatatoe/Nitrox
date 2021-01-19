using System;
using System.Reflection;
using HarmonyLib;
using NitroxClient.Communication.Abstract;
using NitroxModel.Core;
using UnityEngine;

namespace NitroxPatcher.Patches.Dynamic
{
    public class IngameMenu_QuitGame_Patch : NitroxPatch, IDynamicPatch
    {
        public static readonly Type TARGET_CLASS = typeof(IngameMenu);
        public static readonly MethodInfo TARGET_METHOD = TARGET_CLASS.GetMethod("QuitGame");

        public static bool Prefix(IngameMenu __instance)
        {
            IMultiplayerSession multiplayerSession = NitroxServiceLocator.LocateService<IMultiplayerSession>();            
            multiplayerSession.Disconnect();

            //set Permadeath to avoid saving in Async
            //GameModeUtils.SetGameMode(GameModeOption.Permadeath, GameModeOption.None);
            //Application.Quit();
            
            //UWE.CoroutineHost.StartCoroutine()

            //MainGameController.Instance.PerformGarbageAndAssetCollectionAsync();
            //__instance.ChangeSubscreen("Main");
            //__instance.mainPanel.SetActive(false);
            //UWE.Utils.lockCursor = false;
            //SceneCleaner.Open();
            return true;
        }

        public override void Patch(Harmony harmony)
        {
            PatchPrefix(harmony, TARGET_METHOD);
        }
    }
}
