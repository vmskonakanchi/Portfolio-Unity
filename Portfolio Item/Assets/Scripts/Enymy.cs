using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enymy : MonoBehaviour
{
    PlayerController playerController;
    public Slider enymyHealthslider;
    public Transform target;
    public Transform groundDetection;
    [SerializeField] float speed;
    float direction = 2f;
    bool movingLeft = true;
    public int enymyHitpoints = 100;


    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        Die();
        UpdateUI();
        AIPatrol();
        
    }

    void UpdateUI()
    {
        enymyHealthslider.value = enymyHitpoints;
    }

    void AIPatrol()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
      RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position , Vector2.down, direction);
      if(groundInfo.collider == false)
      {
          if(movingLeft== true)
          {
              transform.eulerAngles = new Vector3(0,-180,0);
              movingLeft = false;
          }
          else
          {
              transform.eulerAngles = new Vector3 (0,0,0);
              movingLeft = true;
          }
      }
    } 

    void Die()
    {
     if(enymyHitpoints <= 0)
     {
         //play enymy death animation
         Destroy(gameObject);
     }
    }    

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        { 
            //play player damage animation
            playerController.playerhealthpoints -= 10;
        }    
    } 
    
}
