using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 1f;
    public float rotationSpeed;
    public Transform Player;

    private Rigidbody enemyRb;
    private GameObject player;

    public ParticleSystem explosionParticle;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 LookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(LookDirection * speed * Time.deltaTime, ForceMode.Impulse);
        transform.LookAt(player.transform.position);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            enemyRb.useGravity = true;
            enemyRb.mass = 500;
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 2.0f);
            Destroy(gameObject, 0.5f);
        }
        else
        {
            enemyRb.useGravity = false;
            enemyRb.mass = 1;
        }
    }
}
