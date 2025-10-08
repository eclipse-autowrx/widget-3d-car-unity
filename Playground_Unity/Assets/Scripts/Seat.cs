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
using UnityEngine.UIElements;

public class Seat : MonoBehaviour,IActions
{
    [SerializeField]
    float highestPosVlue = 0.5f;
    [SerializeField]
    float lowestPosVlue = 0.36f;
    [SerializeField]  
    float forwardPosStart = -1.5f;
    [SerializeField]
    float forwardPosEnd = -1.9f;
    [SerializeField]
    public float moveSpeed =2f;
    [Range(0.36f,0.5f)]
    float targetHeight = 0.5f;
    [Range(-10f, 10f)]
    public float targetForward = -1.7f;
    //[Range(0, 100)]
    //public int vlueInput;
    
    private void Update()
    {
        //SetHeight(vlueInput);
        AdjustHeight(targetHeight);   
        AdjustForward(targetForward);
    }  
    private void AdjustHeight(float height)
    {
        Vector3 targetPos = transform.localPosition;
        targetPos.y = height;
        //targetPos.y = Mathf.Clamp(height, lowestPos.y, highestPos.y);       
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed);
    }
    private void AdjustForward(float foward)
    {
        Vector3 targetPos = transform.localPosition;
        targetPos.x = foward;
        //targetPos.y = Mathf.Clamp(height, lowestPos.y, highestPos.y);       
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed);
    }
    public void SetHeight(string height)
    {
        int temp = int.Parse(height);
        temp = Mathf.Clamp(temp,0,10);
        targetHeight = Mathf.Lerp(lowestPosVlue, highestPosVlue, temp/10f);
        //Debug.Log(targetHeight);
    }
    public void SetForward(string forward)
    {
        int temp = int.Parse(forward);
        temp = Mathf.Clamp(temp, 0, 100);
        targetForward = Mathf.Lerp(forwardPosStart, forwardPosEnd, temp / 100f);
        //Debug.Log(targetHeight);
    }

    public void ActiveFunctionsByAction(string actionName, string options)
    {
        switch (actionName)
        {
            case "seat_height":
                SetHeight(options);
                break;
            case "seat_position":
                SetForward(options);
                break;
        }
    }
}
