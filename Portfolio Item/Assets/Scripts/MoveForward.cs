using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update() 
    {
        Rotation();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.CompareTag("Enymy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Rotation()
    {
        float angle = Mathf.Atan2(rb.velocity.y , rb.velocity.x);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
