using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    Rigidbody2D rb;
    Enymy enymy;
    PlayerController playerController;
    void Start()
    {
        enymy = GameObject.FindGameObjectWithTag("Enymy").GetComponent<Enymy>();
        rb = GetComponent<Rigidbody2D>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update() 
    {
        Rotation();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enymy") && playerController.fireIndex == 0)
        {
            enymy.enymyHitpoints -= 10;
        }
         if(other.gameObject.CompareTag("Enymy") && playerController.fireIndex == 1)
        {
            enymy.enymyHitpoints -= 30;
        }
         if(other.gameObject.CompareTag("Enymy") && playerController.fireIndex == 2)
        {
            enymy.enymyHitpoints -= 70;
        }
        if(other.gameObject.CompareTag("Enymy") && enymy.enymyHitpoints <= 0 )
        {
            enymy.enymyHealthslider.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Enymy"))
        {
            Debug.Log(explosionParticle.isPlaying);
            Instantiate(explosionParticle);
            explosionParticle.Play();
            Destroy(gameObject);
        }
    }

    void Rotation()
    {
        float angle = Mathf.Atan2(rb.velocity.y , rb.velocity.x);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void OnBecameInvisible() 
    {
         Destroy(gameObject);
     }

     void PlayParticle()
     {
          GameObject firework = Instantiate(explosionParticle, gameObject.transform.position, Quaternion.identity);
          firework.GetComponent<ParticleSystem>().Play();
     }

}
