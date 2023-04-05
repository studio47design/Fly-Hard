using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem ringParticle;

    private GameManager gameManager;

    public AudioClip crashSound;
    public AudioClip ringSound;
    public AudioClip engineSound;
    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            // get the user's vertical input
            verticalInput = Input.GetAxis("Vertical");

            horizontalInput = Input.GetAxis("Horizontal");

            playerRb.useGravity = false;
            playerRb.mass = 1;
        }
        else
        {
            playerRb.useGravity = true;
            playerRb.mass = 500;
        }

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 2.0f);
            Destroy(collision.gameObject);
            gameManager.GameOver();
        }

        if(collision.gameObject.CompareTag("Building"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.5f);
            gameManager.GameOver();
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        {
            ringParticle.Play();
            playerAudio.PlayOneShot(ringSound, 0.5f);
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            transform.Translate(Vector3.zero * speed);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            speed = 0f;
            rotationSpeed = 0f;
        }
    }
}
