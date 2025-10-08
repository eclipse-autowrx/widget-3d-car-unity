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

public class LightBrake : LightCustoms
{
    [SerializeField] Material material;
    //[SerializeField] Color baseColor;
    public Animator anim;
    public void ActiveBrake(bool bul)
    {
        anim.SetBool("isBrake", bul);
    }
}
