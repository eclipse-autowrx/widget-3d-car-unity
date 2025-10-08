// Copyright (c) 2025 Eclipse Foundation.
// 
// This program and the accompanying materials are made available under the
// terms of the MIT License which is available at
// https://opensource.org/licenses/MIT.
//
// SPDX-License-Identifier: MIT

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance; // Singleton instance of the GameController
    static int sceneCount = 0; // Static counter to track scene switches
    public int SceneCount = 0; // Public property to expose the scene count to other scripts or the Inspector

    private void Awake()
    {
        // Ensure that there is only one instance of GameController (Singleton pattern)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameController instances
        }

        // Prevent the GameController object from being destroyed when switching scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Update the public SceneCount property to reflect the static sceneCount value
        SceneCount = sceneCount;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                IClickable clickable = clickedObject.GetComponent<IClickable>();
                if (clickable != null)
                {
                    clickable.OnClickAction();
                }
            }
        }
    }

    public void SwitchScenes()
    {
        // Switch between scenes based on the current value of sceneCount
        if (sceneCount % 2 == 0)
        {
            SceneManager.LoadScene(1); // Load scene with build index 1
        }
        else
        {
            SceneManager.LoadScene(0); // Load scene with build index 0
        }

        // Increment the scene count after switching
        sceneCount++;
    }
}
