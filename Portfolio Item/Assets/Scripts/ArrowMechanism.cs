using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMechanism : MonoBehaviour 
{
    [SerializeField] float launchForce = 10f;
    public Transform firePoint;
    public GameObject Arrow;
    void Start() 
    {
    }
    void Update() 
    {
         if(Input.GetMouseButton(0))
        {
            Fire();   
        }
        ArrowDirection();
    }

   

    void ArrowDirection()
    {
        Vector2 arrowPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Direction = mousePos - arrowPos;
        transform.right = Direction;
    }
     void Fire ()
    {
        GameObject newarrow = Instantiate (Arrow ,firePoint.position , firePoint.rotation);
        newarrow.GetComponent<Rigidbody2D>().velocity = transform.position * launchForce;

    }
   
}