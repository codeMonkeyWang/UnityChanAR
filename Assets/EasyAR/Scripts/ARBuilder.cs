/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EasyAR
{
    public class ARBuilder
    {
        private static readonly ARBuilder instance = new ARBuilder();
        public List<CameraDeviceBaseBehaviour> CameraDeviceBehaviours = new List<CameraDeviceBaseBehaviour>();
        public List<AugmenterBaseBehaviour> AugmenterBehaviours = new List<AugmenterBaseBehaviour>();
        public List<ImageTrackerBaseBehaviour> TrackerBehaviours = new List<ImageTrackerBaseBehaviour>();

        static ARBuilder()
        {
        }

        ARBuilder()
        {
        }

        public static ARBuilder Instance
        {
            get
            {
                return instance;
            }
        }

        public bool InitializeEasyAR(string key)
        {
            bool success;
#if UNITY_ANDROID && !UNITY_EDITOR
            using (new AndroidJavaClass("cn.easyar.engine.EasyARNative"))
            {
            }
            using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                var playerActivityContext = actClass.GetStatic<AndroidJavaObject>("currentActivity");
                success = Engine.Initialize(key, playerActivityContext.GetRawObject());
            }
#else
            success = Engine.Initialize(key, IntPtr.Zero);
#endif
            if (!success)
            {
                Debug.LogError("Fail to initialize EasyAR!");
                return false;
            }
            return true;
        }

        public bool EasyBuild()
        {
            AugmenterBehaviours.Clear();
            CameraDeviceBehaviours.Clear();
            TrackerBehaviours = GameObject.FindObjectsOfType<ImageTrackerBaseBehaviour>().ToList();

            var augmenterbehaviour = GameObject.FindObjectOfType<AugmenterBaseBehaviour>();
            if (augmenterbehaviour == null)
            {
                Debug.LogError("ARBuilder: fail to build AR");
                return false;
            }
            AugmenterBehaviours.Add(augmenterbehaviour);

            var cambehaviour = GameObject.FindObjectOfType<CameraDeviceBaseBehaviour>();
            if (cambehaviour == null)
            {
                Debug.LogError("ARBuilder: fail to build AR");
                return false;
            }
            CameraDeviceBehaviours.Add(cambehaviour);

            foreach (var behaviour in GameObject.FindObjectsOfType<DeviceUserAbstractBehaviour>())
            {
                behaviour.Bind(cambehaviour);
                Debug.Log("ARBuilder: " + behaviour + " bind " + cambehaviour);
            }
            foreach (var behaviour in AugmenterBehaviours)
            {
                behaviour.Bind(cambehaviour);
            }
            return true;
        }

        public void Start()
        {
            foreach (var behaviour in CameraDeviceBehaviours)
            {
                behaviour.OpenAndStart();
            }
        }
    }
}
