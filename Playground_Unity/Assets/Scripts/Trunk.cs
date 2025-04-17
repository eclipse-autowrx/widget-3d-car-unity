using UnityEngine;


public class Trunk : MonoBehaviour, IClickable, IToggleable, ILockable, IActions
{
    public float rotationSpeed = 5f;

    // Target angles for open and close states
    public float openAngle;
    public float maxAngle;
    public float closedAngle = 0f;
    //public float targetAngleZ;
    //public float targetAngleY;
    // Current state of the door
    public bool isOpen = false;
    public bool isLocked { get; set; }
    public TargetAngles optionsAngles;
    Quaternion targetRotation;
    // Reference to the door GameObject
    public Transform trunkTransform;
    public enum TargetAngles
    {
        targetAngleX,
        targetAngleY,
        targetAngleZ,   
    }
    void Update()
    {
        float targetAngle = isOpen ? openAngle : closedAngle; // Determine target angle based on open/closed state
        
        // Determine the target rotation based on the selected rotation axis
        switch (optionsAngles)
        {
            case TargetAngles.targetAngleX:
                targetRotation = Quaternion.Euler(targetAngle, 0, 0); // Rotate around the X-axis
                break;
            case TargetAngles.targetAngleY:
                targetRotation = Quaternion.Euler(0, targetAngle, 0); // Rotate around the Y-axis
                break;
            case TargetAngles.targetAngleZ:
                targetRotation = Quaternion.Euler(0, 0, targetAngle); // Rotate around the Z-axis
                break;
        }

        // Check if the current rotation is close enough to the target rotation
        if (Quaternion.Angle(trunkTransform.localRotation, targetRotation) > 0.1f)
        {
            // Smoothly interpolate the rotation using Slerp
            trunkTransform.localRotation = Quaternion.Slerp(trunkTransform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

    }
    public void Open(bool vlue)
    {
        if(vlue & !isLocked)
        {
            isOpen = true;
            openAngle = maxAngle;
        }
        else
        {
            isOpen = false;
            openAngle = 0;
        }
    }

    public void OnClickAction()
    {
        isOpen = !isOpen;
        Open(isOpen);
        WebGLInteraction.SetValueAPIBrowser(gameObject.name, isOpen.ToString());
    }

    public void ActiveFunction(bool isActive)
    {
        Open(isActive);
        if (!isActive)
        {
            openAngle = 0;
            WebGLInteraction.SetValueAPIBrowser($"{gameObject.name}_position", openAngle.ToString());
        }
    }
    public void Locked(bool bul)
    {
        isLocked = bul;
    }

    public void ActiveFunctionsByAction(string actionName, string options)
    {
        switch(actionName)
        {
            case "position":
                if (isLocked) return;
                var tempAngle = Mathf.Clamp(float.Parse(options), 0f, 100f);
                openAngle = tempAngle * maxAngle / 100f;
                if(tempAngle>0)
                {
                    isOpen = true;                 
                }
                else
                {
                    isOpen = false;
                }
                WebGLInteraction.SetValueAPIBrowser(gameObject.name, isOpen.ToString());
                break;
        }
    }
}
