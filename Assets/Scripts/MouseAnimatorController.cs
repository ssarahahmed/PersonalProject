using UnityEngine;

public class MouseAnimationController : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public Transform ball;
    public float groundOffset = 0.5f;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = ballRigidbody.linearVelocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    void LateUpdate()
    {
        transform.position = ball.position + Vector3.down * groundOffset;

        Vector3 moveDirection = new Vector3(ballRigidbody.linearVelocity.x, 0, ballRigidbody.linearVelocity.z);
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = rotation;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}

