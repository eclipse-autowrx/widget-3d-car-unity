// Copyright (c) 2025 Eclipse Foundation.
// 
// This program and the accompanying materials are made available under the
// terms of the MIT License which is available at
// https://opensource.org/licenses/MIT.
//
// SPDX-License-Identifier: MIT

using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wipper : MonoBehaviour, IActions
{
    public Animator anim;
    
    // Update is called once per frame
    void Update()
    {
        //ActiveWipper(animMode);
    }
    public void ActiveWipper(int speed)
    {
        float temp = speed + 0.9f;
        anim.SetFloat("speed", temp);    
    }

    public void ActiveFunctionsByAction(string actionName, string options)
    {
        switch(options)
        {
            case "OFF":
                ActiveWipper(0);
                break;
            case "SLOW":
                ActiveWipper(1);
                break;
            case "MEDIUM":
                ActiveWipper(2);
                break;
            case "FAST":
                ActiveWipper(3);
                break;
            case "INTERVAL":
                ActiveWipper(5);
                break;
            case "RAIN_SENSOR":
                ActiveWipper(5);
                break;
        }
    }
}
