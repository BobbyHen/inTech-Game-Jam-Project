using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float cameraDistance = 20f;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Awake() {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}
