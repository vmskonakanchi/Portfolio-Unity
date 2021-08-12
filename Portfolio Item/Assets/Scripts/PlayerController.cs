using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    
    Rigidbody2D rb;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField ]bool isOnGround = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        MovePlayer();
        
        
    }

    void MovePlayer()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce (Vector2.right * horizontalInput * moveSpeed  * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rb.AddForce (Vector2.up * jumpSpeed * Time.deltaTime , ForceMode2D.Impulse);
        }
    } 

      void OnCollisionEnter2D(Collision2D other) 
   {
       if(other.gameObject.CompareTag("Platform"))
       {
           isOnGround = true;
       }
   }
    
   
}
