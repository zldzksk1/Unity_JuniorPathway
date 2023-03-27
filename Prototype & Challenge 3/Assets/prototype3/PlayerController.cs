using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    private int jumpCount = 0;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Rigidbody playerRb;
    private Animator playerAnime;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnime = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
            if(jumpCount >= 2)
            {
                isOnGround = false;
            }
            playerAnime.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
            //Debug.Log(isOnGround);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0;
            dirtParticle.Play();

        } else if(other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");  
            playerAudio.PlayOneShot(crashSound, 1.0f);
            playerAnime.SetBool("Death_b", true);
            playerAnime.SetInteger("DeathType_int",1);  
            explosionParticle.Play(); 
            dirtParticle.Stop();
       
        }

    }
}
