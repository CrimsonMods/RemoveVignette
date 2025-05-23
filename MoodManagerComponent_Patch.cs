using HarmonyLib;
using ProjectM.Presentation;
using UnityEngine.Rendering;

namespace RemoveVignette
{
    [HarmonyPatch(typeof(MoodManagerComponent), nameof(MoodManagerComponent.OnEnable))]
    internal static class MoodManagerComponent_Patch
    {   
        private static void Postfix(MoodManagerComponent __instance)
        {
            var sppTransform = __instance.transform.FindChild("Scene PostProcess");
            var volume = sppTransform.GetComponent<Volume>();
            foreach (var vc in volume.profile.components)
            {
                if (vc.name.StartsWith("Vignette"))
                {
                    vc.active = false;
                    break;
                }
            }
        }
    }
}
