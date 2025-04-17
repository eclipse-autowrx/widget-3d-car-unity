using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// This script controls the wheel rotation and car movement through user interaction or API
public class Wheels : MonoBehaviour, IActions
{
    public Slider accelerationSli;   // Reference to UI slider to set speed manually (for testing)
    public CarController car;        // Reference to the car controller
    public static float baseRotationSpeed = 1f; // Default rotation speed for wheels
    [Range(-10, 100)]
    public static float moveSpeed = 1f;         // Current speed value used for movement
    public static float lastSpeed = 0f;         // Speed from previous frame, for smoothing
    public static float acceleration = 0.002f;  // How quickly the wheel accelerates to target speed

    private void Start()
    {
        // Set initial values when the scene starts
        baseRotationSpeed = 10f;
        moveSpeed = 0f;
    }

    void Update()
    {
        // Rotate the wheels based on speed
        RotateWheel(moveSpeed);

        // Move the car accordingly
        car.MoveCar(moveSpeed);
    }

    // Rotate the wheel model visually based on speed
    public void RotateWheel(float speedMultiplier)
    {
        float finalSpeed = baseRotationSpeed * speedMultiplier; // Calculate rotation speed
        finalSpeed = Mathf.Lerp(lastSpeed, finalSpeed, acceleration); // Smooth transition
        transform.Rotate(-Vector3.forward * finalSpeed * Time.deltaTime); // Rotate wheel
        lastSpeed = finalSpeed;
    }

    // Interface method implementation - allows calling functions via string actions
    public void ActiveFunctionsByAction(string actionName, string options)
    {
        switch (actionName)
        {
            case "speed":
                float speed = float.Parse(options);                       // Parse speed value
                speed = Mathf.Clamp(speed, -20, 120);                    // Clamp to safe range
                SetMoveSpeedAllWheels(speed);                            // Update speed
                car.MoveCar(speed);                                      // Move the car with new speed
                break;
        }
    }

    // Static method to update speed for all wheels (in case there are multiple wheel objects)
    public static void SetMoveSpeedAllWheels(float speed)
    {
        moveSpeed = speed;
    }

    // For manual testing through the slider UI
    public void SetMoveSpeedAllWheelsTest()
    {
        moveSpeed = accelerationSli.value;
    }
}
