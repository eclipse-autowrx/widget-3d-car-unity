// Copyright (c) 2025 Eclipse Foundation.
// 
// This program and the accompanying materials are made available under the
// terms of the MIT License which is available at
// https://opensource.org/licenses/MIT.
//
// SPDX-License-Identifier: MIT

using System.Runtime.InteropServices;
using UnityEngine;

public class WebGLInteraction : MonoBehaviour
{
    // Calls a JavaScript function named "PrintMessage" and passes a string message as a parameter
    public void CallJavaScript()
    {
        string message = "Hello from Unity!";
        Application.ExternalCall("PrintMessage", message); // This method is deprecated in newer Unity versions
    }

    // Calls a JavaScript function using ShowMessage in WebGL builds
    public static void SetValueAPIBrowser(string name, string vlue)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // This block is executed only in WebGL builds (not in the Unity Editor)
        SetAPIValueFromUnity(name, vlue);
        
#else
        // Logs a message in the Unity Editor or other non-WebGL platforms
        Debug.Log("This only works in WebGL builds.");
#endif
    }

    [DllImport("__Internal")]
    private static extern void SetAPIValueFromUnity(string name, string value);
    [DllImport("__Internal")]
    private static extern void ShowInfo(string info);

    public static  void SendDataMessage(string info)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // This block is executed only in WebGL builds (not in the Unity Editor)
        ShowInfo(info);
        
#else
        // Logs a message in the Unity Editor or other non-WebGL platforms
        Debug.Log("This only works in WebGL builds.");
#endif
    }

}
