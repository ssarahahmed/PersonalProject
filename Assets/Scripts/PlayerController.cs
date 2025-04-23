using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public AudioClip cheesePickupSound; 


    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
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
    }

    void SetCountText()
    {
     
      /*  countText.text = "Cheese Count: " + count.ToString();
        if (count >= 8)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
     /*   if (collision.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(gameObject);

        }
     */
    }


}
