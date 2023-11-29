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
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    { // When you input/press space key the player will jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
        //Detects collision 
        public void OnCollisionEnter(Collision Collision)
        {
           

            if(Collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            } else if(Collision.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Game Over");
                gameOver = true;
            }   

            
        }
}
