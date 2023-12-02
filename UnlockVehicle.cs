using System.Reflection;
using HarmonyLib;

public class UnlockVehicle : IModApi // ModEntryPoint - RESERVED LOOKUP NAME
{
    public void InitMod(Mod _modInstance)
    {
        Harmony harmony = new Harmony(base.GetType().ToString());
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    [HarmonyPatch(typeof(EntityVehicle), "Awake")]
    public class EntityVehicle_Awake
    {
        [HarmonyPostfix]
        public static void postfix(EntityVehicle __instance)
        {
            __instance.isLocked = false;
        }
    }
}