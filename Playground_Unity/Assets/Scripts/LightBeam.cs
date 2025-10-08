// Copyright (c) 2025 Eclipse Foundation.
// 
// This program and the accompanying materials are made available under the
// terms of the MIT License which is available at
// https://opensource.org/licenses/MIT.
//
// SPDX-License-Identifier: MIT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : LightCustoms, IToggleable
{
    public List<Light> beams;
    //public bool isActive = false;
    public void LowBeams()
    {
        gameObject.SetActive(true);
        //isLowBeam = true;
        foreach (var beam in beams)
        {            
            beam.range = 15f;
        }
    }
    public void HighBeams()
    {
        gameObject.SetActive(true);
        //isHighBeam = true;
        foreach (var beam in beams)
        {
            beam.range = 50f;
        }
    }
    public void OffBeams()
    {      
     gameObject.SetActive(false);     
    }

    public void ActiveFunction(bool isActive)
    {
        gameObject.SetActive(isActive);     
    }
}
