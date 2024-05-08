using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtparticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;
    public bool doubleJump;
    public float JumpingPower = 16f;
    public bool doubleSpeed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    { // When you input/press space key the player will jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f);
            doubleJump = true;
            
            
        }

        else if (!isOnGround && doubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, JumpingPower);

                doubleJump = false;
                doubleSpeed = false;
                playerAnim.SetFloat("Speed_Multiplier", 1.0f);
            }

            if(Input.GetKey(KeyCode.LeftShift))
            {
                doubleSpeed = true;
                playerAnim.SetFloat("Speed_Multiplier", 2.0f);
            }

            else if (doubleSpeed)
            {
                doubleSpeed = false;
                playerAnim.SetFloat("Speed_Multiplier", 1.0f);
            }
    }
        //Detects collision 
        public void OnCollisionEnter(Collision Collision)
        {
           

            if(Collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtparticle.Stop();
            } else if(Collision.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Game Over");
                gameOver = true;
                playerAnim.SetBool("Death_b" , true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtparticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
            }   

            
        

            
        }
}
