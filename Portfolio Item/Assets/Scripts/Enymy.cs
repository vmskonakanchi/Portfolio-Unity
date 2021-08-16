using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enymy : MonoBehaviour
{
    PlayerController playerController;
    SpriteRenderer sp;
    Rigidbody2D rb;
    Animator animator;
    [Header("Components")]
    [Tooltip("Components Required For Enemy Controller")]
    public Slider enymyhealthBar;
    public Transform target;
    public Transform groundDetection;
    public Transform enymybulletSpwanpos;
    public GameObject enymyBullet;
    [Space(2f)]
    [Header("Enemy Properties")]
    [Tooltip("Variables For Controlling Enymy")]
    [SerializeField] float speed;
    [Range(1f,10f)]
    [SerializeField] float targetRange = 10f;
    public int enymyHitpoints = 100;
    public float timefornextShot;
    public float repeatRate;
    [Space(3f)]
    public int ReddamageMultiplier;
    public int BluedamageMultiplier;
    public int YellowdamageMultiplier;
    float direction = 2f;
    bool movingLeft = true;
    void Start()
    {
        
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if(target != null)
        {
            Die();
            UpdateUI();
            AIPatrol();
            FindPLayer();
        }



    }

    void UpdateUI()
    {
        enymyhealthBar.value = enymyHitpoints;
    }

    void AIPatrol()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position , Vector2.down, direction);
        RaycastHit2D enymyhitInfo = Physics2D.Raycast(groundDetection.position , Vector2.right, direction);
        RaycastHit2D anotherenymyhitInfo = Physics2D.Raycast(groundDetection.position , Vector2.left, direction);
      if(enymyhitInfo.collider == true)
      {
          transform.eulerAngles = new Vector3 (0,0,0);
      }
      else if (anotherenymyhitInfo.collider == true)
      {
          transform.eulerAngles = new Vector3 (0,-180,0);
      }
      if(groundInfo.collider == false )
      {
          movingLeft = true;
          if(movingLeft == true)
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
         Destroy(gameObject);
     }
    }


    void FindPLayer()
    {
        float targetDist = Vector3.Distance(target.position , groundDetection.position);
        if(targetDist < targetRange && Time.time > timefornextShot)
        {
            timefornextShot = repeatRate + Time.time;
            DamagePlayer();
        }

    }
    public void DamagePlayer()
    {

        float shoootingPower = 5f;
        Vector3 direction = target.position - groundDetection.position;
        GameObject projectile = Instantiate(enymyBullet, enymybulletSpwanpos.position, enymybulletSpwanpos.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * shoootingPower;

    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.CompareTag("Enymy"))
    //     {
    //         this.GetComponent<Rigidbody2D>().isKinematic = true;
    //     }
    // }
}
