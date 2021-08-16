using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public GameObject explosionFX;
    public  GameObject groundFx;
    Rigidbody2D rb;
    [Range(0 ,50)]
    [SerializeField]float speed = 10f;
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
        Move();

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject groundVFX = Instantiate(groundFx , gameObject.transform.position, Quaternion.identity);
        groundVFX.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
        if(other.gameObject.CompareTag("Enymy") &&  playerController.fireIndex == 0)
        {
            enymy.enymyHitpoints -= 10;
        }
        else if(other.gameObject.CompareTag("Enymy") && playerController.fireIndex == 1)
        {
            enymy.enymyHitpoints -= 30;
        }
        else if(other.gameObject.CompareTag("Enymy") && playerController.fireIndex == 2)
        {
            enymy.enymyHitpoints -= 60;
            
        }
        else if(other.gameObject.CompareTag("Enymy") && enymy.enymyHitpoints <= 0 )
        {
            enymy.enymyhealthBar.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Enymy"))
        {
            GameObject explosionVFX = Instantiate(explosionFX , this.transform.position, Quaternion.identity);
            explosionVFX.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }


    void OnBecameInvisible() 
    {
         Destroy(gameObject);
     }

     void Move()
     {  
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
     }

}
