using UnityEngine;

public class AIMouseController : MonoBehaviour
{
    public Transform player;
    public float damage = 10f;
    public AudioClip damageSound;
    private Animator animator;
    private AudioSource audioSource;
    public float moveSpeed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position);
        direction.y = 0f;

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        animator.SetFloat("Speed", 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthTimer playerHealth = collision.gameObject.GetComponent<HealthTimer>();
            if (playerHealth != null)
            {
                playerHealth.ReduceHealth();
            }

            if (audioSource && damageSound)
            {
                audioSource.PlayOneShot(damageSound);
            }

            Destroy(gameObject);
        }
    }
}
