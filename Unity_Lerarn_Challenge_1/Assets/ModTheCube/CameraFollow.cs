using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // The target (cube) the camera should follow
    public Vector3 offset;     // The offset from the target to keep the camera at a specific position

    void LateUpdate()
    {
        // Update the camera position to follow the target while maintaining the offset
        transform.position = target.position + offset;
    }
}
