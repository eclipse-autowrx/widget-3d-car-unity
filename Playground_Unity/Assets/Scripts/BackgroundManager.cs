// Copyright (c) 2025 Eclipse Foundation.
// 
// This program and the accompanying materials are made available under the
// terms of the MIT License which is available at
// https://opensource.org/licenses/MIT.
//
// SPDX-License-Identifier: MIT

using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // The currently active background in the scene
    public GameObject currentBackground;

    // An array to store the available background GameObjects
    public GameObject[] backgrounds = new GameObject[5];

    // A static variable to keep track of the toggle state (0 or 1)
    static int checkToggle = 0;

    // Enum to define the background types for better readability
    public enum BACKGROUND
    {
        Garage,         // Background inside a garage
        OnTheStreet,    // Background outside on the street
    }

    // Switch to a background based on the given order
    public void SwitchBackgrounds(int order)
    {
        // Check if the background exists in the array
        if (backgrounds[order])
        {
            // Deactivate the current background
            currentBackground.SetActive(false);

            // Set the new background as the current one
            currentBackground = backgrounds[order];

            // Activate the newly selected background
            currentBackground.SetActive(true);
        }
    }

    // Toggle between the two main backgrounds
    public void ToggleBackground()
    {
        if (checkToggle == 0)
        {
            // Switch to the "OnTheStreet" background
            SwitchBackgrounds(1);
            checkToggle = 1; // Update toggle state
        }
        else
        {
            // Switch to the "Garage" background
            SwitchBackgrounds(0);
            checkToggle = 0; // Update toggle state
        }
    }
    public void HiddenBackground(bool bul)
    {
        gameObject.SetActive(!bul);
    }
}
