using System.Collections.Generic;
using UnityEngine;

// Data structure to hold control information for a car component
public class ComponentControlData
{
    public string name;     // The name of the component to control
    public string action;   // The action to perform on the component
    public string options;  // Additional options related to the action
}

public class CarController : MonoBehaviour
{
    public float speed = 0.1f;           // Movement speed multiplier
    private float moveInput;             // Current input value for movement
    public float lastSpeed = 0f;         // Speed value from previous frame
    private float turnInput;             // Turn input (not used in this version)
    public float acceleration = 0.0001f; // How quickly the car accelerates
    public Vector3 rollbackPos;          // Position to reset to when out of bounds

    // References to car components
    public BackgroundManager background;
    public List<LightCustoms> lightHazard; // List of hazard lights
    public List<LightCustoms> lightBrake;  // List of brake lights
    public GameObject[] arrComponent = new GameObject[100]; // Array holding all car components
    public Dictionary<string, GameObject> entitiesManager;  // Dictionary for name-component mapping

    private void Start()
    {
        // Initialize the entity dictionary with references from the array
        entitiesManager = new Dictionary<string, GameObject>()
        {
            {"mirror_left"       ,arrComponent[0]},
            {"mirror_right"      ,arrComponent[1]},
            {"beam_high"         ,arrComponent[2]},
            {"beam_low"          ,arrComponent[3]},
            {"seat1"             ,arrComponent[4]},
            {"seat2"             ,arrComponent[5]},
            {"window_1"          ,arrComponent[6]},
            {"window_2"          ,arrComponent[7]},
            {"ambientlight_1"    ,arrComponent[8]},
            {"ambientlight_2"    ,arrComponent[9]},
            {"row2_door3"        ,arrComponent[10]},
            {"window_3"          ,arrComponent[11]},
            {"window_4"          ,arrComponent[12]},
            {"row2_door4"        ,arrComponent[13]},
            {"wheels"            ,arrComponent[14]},
            {"trunk_front"       ,arrComponent[15]},
            {"trunk_rear"        ,arrComponent[16]},
            {"rear_light"        ,arrComponent[17]},
            {"front_light"       ,arrComponent[18]},
            {"license_plate"     ,arrComponent[19]},
            {"wipper_rear"       ,arrComponent[20]},
            {"seat3"             ,arrComponent[21]},
            {"seat4"             ,arrComponent[22]},
            {"air_bag"           ,arrComponent[23]},
            {"wipper_front"      ,arrComponent[24]},
            {"row1_door1"        ,arrComponent[25]},
            {"row1_door2"        ,arrComponent[26]},
        };
    }

    private void Update()
    {
        // Apply acceleration and update position
        moveInput = Mathf.Lerp(lastSpeed, moveInput, acceleration);
        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);
        lastSpeed = moveInput;

        // Check if car went out of bounds
        RollbackPosition();
    }

    // Main control function triggered by external API (with JSON input)
    public void ControlComponent(string jsonData)
    {
        // Deserialize input string into structured data
        ComponentControlData data = JsonUtility.FromJson<ComponentControlData>(jsonData);
        string entityName = data.name;
        string action = data.action;
        string options = data.options;

        // Check if the component exists
        if (entitiesManager.TryGetValue(entityName, out var entity))
        {
            // Check if the action is a boolean string
            if (bool.TryParse(action, out var result))
            {
                switch (options)
                {
                    case "islocked":
                        // Lock or unlock if component supports locking
                        ILockable lockable = entity.GetComponent<ILockable>();
                        if (lockable != null)
                        {
                            lockable.Locked(result);
                        }
                        break;
                    default:
                        // Toggle component if supported
                        IToggleable toggleFunctions = entity.GetComponent<IToggleable>();
                        if (toggleFunctions != null)
                        {
                            toggleFunctions.ActiveFunction(result);
                        }
                        break;
                }
            }
            else
            {
                // Handle more complex actions
                IActions actionName = entity.GetComponent<IActions>();
                if (actionName != null)
                {
                    actionName.ActiveFunctionsByAction(action, options);
                }
            }
        }

        // Special case for certain light systems
        switch (entityName)
        {
            case "light_brake":
                PerformLightsAction(lightBrake, action, options);
                break;
            case "hazard_signaling":
                PerformLightsAction(lightHazard, action, options);
                break;
        }
    }

    // Perform action on a list of light components
    public void PerformLightsAction(List<LightCustoms> lights, string action, string options)
    {
        switch (action)
        {
            case "turn_on_beam_low":
                foreach (LightBeam light in lights)
                    light.LowBeams();
                break;
            case "turn_on":
                foreach (LightBeam light in lights)
                    light.HighBeams();
                break;
            case "turn_off":
                foreach (LightBeam light in lights)
                    light.OffBeams();
                break;
            case "turn_on_brake":
                foreach (LightBrake light in lights)
                    light.ActiveBrake(true);
                break;
            case "turn_off_brake":
                foreach (LightBrake light in lights)
                    light.ActiveBrake(false);
                break;
            case "turn_on_signal":
                foreach (LightHazard light in lights)
                    light.ActiveHazard(true);
                break;
            case "turn_off_signal":
                foreach (LightHazard light in lights)
                    light.ActiveHazard(false);
                break;
        }
    }

    // Update movement inputs
    public void MoveCar(float move, float turn = 0f)
    {
        moveInput = move;
        turnInput = turn;
    }

    // If car goes out of bounds, reset its position
    public void RollbackPosition()
    {
        Vector3 temp = transform.localPosition;
        if (temp.x > 100 || temp.x < -25)
        {
            background.HiddenBackground(true);
            transform.localPosition = rollbackPos;
        }
    }
}
