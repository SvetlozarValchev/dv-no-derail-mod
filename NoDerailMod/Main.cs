using System;
using System.Reflection;
using UnityModManagerNet;
using Harmony12;
using UnityEngine;

namespace NoDerailMod
{
    public class Main
    {
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            // Something
            return true; // If false the mod will show an error.
        }
    }

    [HarmonyPatch(typeof(Bogie), "Start")]
    class Bogie_Start_Patch
    {
        static void Postfix(ref bool ___canDerail)
        {
            ___canDerail = false;
        }
    }
}