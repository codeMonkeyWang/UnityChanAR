/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine.Rendering;
using System.Linq;

public class PostBuild
{
    /// This version of EasyAR only works with GLES2.0 on Android and iOS, please make sure Graphics API is correctly set.
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
#if UNITY_2_6 || UNITY_2_6_1 || UNITY_3_0 || UNITY_3_0_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5
        Debug.LogWarning("EasyAR has not been tested with current Unity version, please consider upgrade your Unity.");
#endif
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_IOS
        string title = "Incompatible graphics API detected!";
        string message = "Please set graphics API to \"OpenGL ES 2.0\" and rebuild, or EasyAR may not work as expected (e.g. white screen).";
#if UNITY_2_6 || UNITY_2_6_1 || UNITY_3_0 || UNITY_3_0_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9
        // we have tested in Unity 4.6.5+, if API is incompatible with your Unity version, change the below code
#if UNITY_IPHONE
        if (target == BuildTarget.iPhone && PlayerSettings.targetIOSGraphics != TargetIOSGraphics.OpenGLES_2_0){
            EditorUtility.DisplayDialog(title, message, "OK");
            Debug.LogError(title + " " + message);
        }
#endif
#if UNITY_ANDROID
        if (target == BuildTarget.Android && PlayerSettings.targetGlesGraphics != TargetGlesGraphics.OpenGLES_2_0)
        {
            EditorUtility.DisplayDialog(title, message, "OK");
            Debug.LogError(title + " " + message);
        }
#endif
#elif UNITY_5_0
#if UNITY_IPHONE
        if (target == BuildTarget.iOS && PlayerSettings.targetIOSGraphics != TargetIOSGraphics.OpenGLES_2_0)
        {
            EditorUtility.DisplayDialog(title, message, "OK");
            Debug.LogError(title + " " + message);
        }
#endif
#if UNITY_ANDROID
        if (target == BuildTarget.Android && PlayerSettings.targetGlesGraphics != TargetGlesGraphics.OpenGLES_2_0)
        {
            EditorUtility.DisplayDialog(title, message, "OK");
            Debug.LogError(title + " " + message);
        }
#endif
#else // suppose it should be unty 5.1+
        // we have tested in Unity 5.2.2, if API is incompatible with your Unity version, change the below code
        if (target != BuildTarget.Android && target != BuildTarget.iOS)
            return;
        if (PlayerSettings.GetUseDefaultGraphicsAPIs(target))
        {
            var apis = new GraphicsDeviceType[1];
            apis[0] = GraphicsDeviceType.OpenGLES2;
            PlayerSettings.SetGraphicsAPIs(target, apis);

            message = "Please uncheck \"Auto Graphics API\" (if not done by EasyAR) and rebuild, or EasyAR may not work as expected (e.g. white screen).";
            EditorUtility.DisplayDialog(title, message, "OK");
            Debug.LogError(title + " " + message);
        }
        else
        {
            var curapi = PlayerSettings.GetGraphicsAPIs(target);
            if (curapi.Length > 1 || !curapi.Contains(GraphicsDeviceType.OpenGLES2))
            {
                var apis = new GraphicsDeviceType[1];
                apis[0] = GraphicsDeviceType.OpenGLES2;
                PlayerSettings.SetGraphicsAPIs(target, apis);

                message = "Graphics API has been set to \"OpenGL ES 2.0\" by EasyAR. Please build again, or EasyAR may not work as expected (e.g. white screen).";
                EditorUtility.DisplayDialog(title, message, "OK");
                Debug.LogError(title + " " + message);
            }
        }
#endif
#endif
    }
}
