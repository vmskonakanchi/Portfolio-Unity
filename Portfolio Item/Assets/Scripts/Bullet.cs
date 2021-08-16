using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject collisionFX;
   
    Enymy enymy;
    PlayerController playerController;
    SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enymy = GameObject.FindGameObjectWithTag("Enymy").GetComponent<Enymy>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       
        if(other.gameObject.CompareTag ("Player"))
        {
            Color redColor = new Color(255, 0, 0, 255);
            Color blueColor = new Color(0, 0, 255, 255);
            Color yellowColor = new Color(255, 255, 0, 255);
            GameObject newVFX = Instantiate(collisionFX, this.transform.position, this.transform.rotation);
            newVFX.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject); 
       
        if (sp.color == redColor)
        {
            playerController.playerhealthpoints -= enymy.ReddamageMultiplier;
        }
        else if (sp.color == blueColor)
        {
            playerController.playerhealthpoints -= enymy.BluedamageMultiplier;
        }
        else if (sp.color == yellowColor)
        {
            playerController.playerhealthpoints -= enymy.YellowdamageMultiplier;
        }   
        }
    }
}
