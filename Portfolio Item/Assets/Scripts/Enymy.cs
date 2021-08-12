using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enymy : MonoBehaviour
{
   [SerializeField] float enymyspeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.left * enymyspeed * Time.deltaTime);
    }
    void  OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.CompareTag ("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    
       
        
    
}
