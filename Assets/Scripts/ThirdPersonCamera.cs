using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; 
    public Vector2 sensitivity = new Vector2(120f, 120f);
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    private float yaw;
    private float pitch;

    public float distanceFromTarget = 5f;
    public Transform camTransform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity.x * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        transform.position = target.position;
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        camTransform.position = target.position - rotation * Vector3.forward * distanceFromTarget + Vector3.up * 2f;
        camTransform.LookAt(target.position + Vector3.up * 2f);
    }
}

