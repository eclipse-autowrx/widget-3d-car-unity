
using UnityEngine;

public class WindowCar : MonoBehaviour, IToggleable, IActions
{
    // The target position the window should move to
    public Transform currentTargetPos;

    // The starting position of the window (fully closed position)
    public Vector3 startPos;
    Vector3 hiddenPos;

    // Animator component for animations
    public Animator anim;

    // Lock state to prevent movement
    public bool isLocked = false;

    // Speed at which the window moves
    float moveSpeed = 0.2f;

    // Whether the window is in the "down" position
    public bool isDown = false;

    // The total movement range of the window
    public float range = 0f;

    // Percentage value to control how far the window opens (0% = closed, 100% = fully open)
    [Range(0, 100)]
    int percent = 100; // For testing purposes

    void Start()
    {
        // Store the initial position of the window
        startPos = transform.localPosition;
        hiddenPos = currentTargetPos.localPosition;
        if (currentTargetPos != null)
        {
            // Calculate the total range the window can move
            range = startPos.y - currentTargetPos.localPosition.y;
        }
    }

    void Update()
    {       
        if (currentTargetPos != null)
        {           
            // Choose the correct target position based on whether the window is down or not
            Vector3 targetPosition = isDown ? currentTargetPos.localPosition : startPos;

            // Move the window towards the target position
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);

            // Update the target position based on the percentage value
            if ((Vector3.Distance(transform.localPosition, hiddenPos)) > 0.01f)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;   
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }     
    }

    // Function to activate the window movement based on a boolean value
    public void ActiveFunction(bool isActive)
    {
        // Prevent movement if the window is locked
        if (isLocked) return;

        // Set animation state based on the input
        //anim.SetBool("isDown", isActive);
        SetIsDown(isActive);
    }
    public void SetIsDown(bool bul)
    {
        isDown = bul;
        // Adjust the Y position of the target based on the calculated movement amount
        Vector3 newTargetPosition = startPos;
        if (isDown)
        {
            newTargetPosition.y -= range;
            currentTargetPos.localPosition = newTargetPosition;
        }
        else
        {
            currentTargetPos.localPosition = startPos;       
        }           
    }
    // Set the target position based on a given percentage
    public void SetTargetPos(float percentage)
    {
        if (currentTargetPos != null )
        {
            if (percentage > 0)
            {
                WebGLInteraction.SetValueAPIBrowser(gameObject.name, "true");
            }
            else
            {
                WebGLInteraction.SetValueAPIBrowser(gameObject.name, "false");
            }

            // Calculate the movement amount based on the percentage
            float moveAmount = percentage * range / 100f;

            // Adjust the Y position of the target based on the calculated movement amount
            Vector3 newTargetPosition = startPos;
            newTargetPosition.y -= moveAmount;

            // Apply the new position to the target
            currentTargetPos.localPosition = newTargetPosition;
        }      
    }

    public void ActiveFunctionsByAction(string actionName, string options)
    {
        var tempVlue = Mathf.Clamp(float.Parse(options),0,100);
        //not implement yet
        switch(actionName)
        {
            case "position":
                SetTargetPos(tempVlue);
                break;
            default:
                SetTargetPos(tempVlue);
                break;
        }
    }
}
