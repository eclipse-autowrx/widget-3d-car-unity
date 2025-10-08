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

public class LightHazard : LightCustoms
{
    [SerializeField] Material material;
    //[SerializeField] Color baseColor;
    public Animator anim;  
   // [Tooltip("To check intensity")]
    //[Range(0,100)]
    //public float intensity = 0;
    //public bool isHazard = false;
    //readonly float defaulIntensity = 0;
    //[Range(1,30)]
    //public float hazardIntensity = 30f;
    //readonly float brakeIntensity = 50f;
    private void Start()
    {
        //gameObject.SetActive(false);
        //baseColor = material.GetColor("_EmissionColor");
    }
    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    ActiveHazard(true);
        //}
        //if (Input.GetKeyUp(KeyCode.L))
        //{
        //    ActiveHazard(false);
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    BrakeSignaling(true);
        //}
        //if (Input.GetKeyUp(KeyCode.K))
        //{
        //    BrakeSignaling(false);
        //}
    }
    //public void SetIntensity(float intensity)
    //{
    //    // Ensure the material is assigned before proceeding
    //    if (material != null)
    //    {
    //        // Adjust the emission color intensity by multiplying it with the given intensity
    //        Color newColor = baseColor * intensity;
    //        //Color newColor = new Color(1+ Mathf.Sin(Time.time *2f)* intensity, 0, 0);

    //        // Set the updated emission color back to the material
    //        material.SetColor("_EmissionColor", newColor);

    //        // Ensure Global Illumination (GI) updates dynamically for the new emission color
    //        DynamicGI.SetEmissive(GetComponent<Renderer>(), newColor);
    //    }
    //    else
    //    {
    //        // Log a warning if the material is not assigned
    //        Debug.LogWarning("Material is not assigned!");
    //    }
    //}
    public void ActiveHazard(bool bul)
    {
        anim.SetBool("isHazard", bul);
    }
    public void ActiveBrake(bool bul)
    {
        anim.SetBool("isBrake", bul);
    }
}
