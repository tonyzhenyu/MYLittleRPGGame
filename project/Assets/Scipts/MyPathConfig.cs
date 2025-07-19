using UnityEngine;

public static class MyPathConfig
{
    readonly public static string CSV_PATH = $"{Application.streamingAssetsPath}/Scene";
    readonly public static string ADB_SCENE_PATH = $"{Application.streamingAssetsPath}/Scene/";
    readonly public static string SCENE_PATH = "Scene/";

    readonly public static string PREFABS = "Prefabs/";

    readonly public static string BTN_SCENE = PREFABS + "Btn_Scene";
    readonly public static string BTN_CHOICE = PREFABS + "Btn_Choice";
}
