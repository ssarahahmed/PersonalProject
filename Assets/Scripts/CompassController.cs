using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{
    public Transform player;      
    public Transform target;      
    public RectTransform needle;  

    void Update()
    {
        Vector3 direction = target.position - player.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        needle.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}
