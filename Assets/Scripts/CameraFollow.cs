using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    float offSet = 20;
    private Transform cameraTransform;
    public GameObject head;
    Transform headTransform;



    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
        headTransform = head.GetComponent<Transform>();
    }
    private void Update()
    {
        if (head != null)
        {
            if (cameraTransform.position.z < headTransform.position.z - offSet)
            {
                cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, headTransform.position.z - offSet);
            }
        }
    }
}
