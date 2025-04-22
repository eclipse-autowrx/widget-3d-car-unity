using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float minDistance = 3f; 
    public float maxDistance = 20f; 

    public float fov = 75f;
    public float nearClip = 0.1f;
    public float farClip = 1000f;
    public float rotationSpeed = 100f;

    private float currentX = -180f;
    private float currentY = 23.6f;
    private float zoomSpeed = 5f;

    bool isSendData = true;
    void Start()
    {
        Camera.main.fieldOfView = fov;
        Camera.main.nearClipPlane = nearClip;
        Camera.main.farClipPlane = farClip;

#if UNITY_WEBGL && !UNITY_EDITOR
        // This block is executed only in WebGL builds (not in the Unity Editor)
            StartCoroutine(nameof(DelaySendDataToPG));
#else
        // Logs a message in the Unity Editor or other non-WebGL platforms
        Debug.Log("This only works in WebGL builds.");
#endif 
    }

    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     isSendData = false;
        // }
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     isSendData = true;
        // }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Vector3 camPos = Camera.main.transform.position;
        //     SendCameraPositionToJS(camPos.x, camPos.y, camPos.z);
        // }

        if (Input.GetMouseButton(0))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            currentY = Mathf.Clamp(currentY, 5f, 80f);
        }
       
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        
    }
    private void LateUpdate()
    {
        if (target != null)
        {
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance);

            transform.position = position;
            transform.LookAt(target);
        }
    }

    public void ControlComponent(string action)
    {
        if(action=="move_toward") {
            distance -= 0.8f;
        }
        if(action=="move_backward") {
            distance += 0.8f;
        }
    }

    [DllImport("__Internal")]
    private static extern void SendCameraPositionToJS(float x, float y, float z);
    public IEnumerator DelaySendDataToPG()
    {
        while(true)
        {
            if(isSendData)
            {
                yield return new WaitForSeconds(1f);
                Vector3 camPos = Camera.main.transform.position;
                SendCameraPositionToJS(camPos.x, camPos.y, camPos.z);
            }
            else
            {
                yield return null;
            }
            
        }    
    }
    
}
