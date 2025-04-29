using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 10f;
    public float jumpForce = 5f;
    private bool isGrounded;
    public TextMeshProUGUI countText;
    public AudioClip cheesePickupSound;
    public LayerMask groundLayer;
    public Transform respawnPoint;

    private InputActions controls; 

    void Awake()
    {
        controls = new InputActions(); 
    }
   
    void OnEnable()
    {
        controls.Enable(); 
    }

    void OnDisable()
    {
        controls.Disable(); 
    }
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void Update()
    {
        if (!GameManager.GameStarted) return;

        Vector2 movementVector = controls.Player.Move.ReadValue<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

        if (controls.Player.Jump.triggered && isGrounded)
        {
            Jump();
        }

        CheckGrounded();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            ParticleSystem sparkle = other.GetComponentInChildren<ParticleSystem>();
            if (sparkle != null)
            {
                sparkle.transform.parent = null;
                sparkle.Play();
                Destroy(sparkle.gameObject, 2f);
            }

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && cheesePickupSound != null)
            {
                audioSource.PlayOneShot(cheesePickupSound);
            }

            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            FindObjectOfType<HealthTimer>().AddHealth(30f);
        }

        if (other.CompareTag("Respawn"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero; 
        transform.position = respawnPoint.position;         
    }

    void SetCountText()
    {
        countText.text = "Cheese Count: " + count.ToString();

        if (count >= 5)
        {
            SavePlayerData(); // Save the cheese count before changing scenes
            SceneManager.LoadScene("GameOver");
        }
    }

    public int GetCheeseCount()
    {
        return count;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void CheckHealth(float currentHealth)
    {
        if (currentHealth <= 0f)
        {
            SavePlayerData(); // Save cheese count
            SceneManager.LoadScene("GameOver");

        }
    }
        public void SavePlayerData()
    {
        PlayerPrefs.SetInt("CheeseCount", count);
        PlayerPrefs.Save();
    }

}
