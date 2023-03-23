using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothing = 5f; // The smoothing applied to the camera movement
    Vector3 offset; // The offset between the camera and the target
    void Start()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        if (target != null)
        {
            // Camare Follow 
            MoveTheCamera();
        }
    }
    void MoveTheCamera()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
