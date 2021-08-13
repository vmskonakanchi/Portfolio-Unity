using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{   
    public  GameObject [] arrowPrefabs;
    
    Rigidbody2D rb;
    int fireIndex;
    [SerializeField] float launchForce = 10f;
    public Transform firePoint;
    Ammo ammo;
    public TextMeshProUGUI NormalarrowCountText;
    public TextMeshProUGUI FirearrowCountText;
    public TextMeshProUGUI WaterarrowCountText;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] bool isOnGround;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ammo = gameObject.GetComponent<Ammo>();   
    }

    void Update()
    {
        NormalarrowCountText.text = ammo.NormalammoCount.ToString();
        FirearrowCountText.text = ammo.FireammoCount.ToString();
        WaterarrowCountText.text = ammo.WaterammoCount.ToString();
        Fire();
        MovePlayer();  
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Platform"))
        {
           isOnGround = true;
        }
    }
    void MovePlayer()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce (Vector2.right * horizontalInput * moveSpeed  * Time.deltaTime, ForceMode2D.Impulse);
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rb.AddForce (Vector2.up * jumpSpeed * Time.deltaTime , ForceMode2D.Impulse);
        }
    } 

    public void Fire ()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            fireIndex = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) )
        {
           
            fireIndex = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) )
        {
                    
            fireIndex = 2;     
        }
        if(Input.GetMouseButtonDown(0) && ammo.NormalammoCount > 0 && fireIndex == 0 )
        {
            ammo.NormalammoCount--;
            GameObject newArrow = Instantiate (arrowPrefabs[fireIndex] ,firePoint.position , firePoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity =  transform.right * launchForce;      
        }
        else if(Input.GetMouseButtonDown(0) && ammo.FireammoCount > 0 && fireIndex ==  1)
        {
            ammo.FireammoCount--;
            GameObject newArrow = Instantiate (arrowPrefabs[fireIndex] ,firePoint.position , firePoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity =  transform.right * launchForce;      
        }
        else if(Input.GetMouseButtonDown(0) && ammo.WaterammoCount > 0 && fireIndex ==  2)
        {
            ammo.WaterammoCount--;
            GameObject newArrow = Instantiate (arrowPrefabs[fireIndex] ,firePoint.position , firePoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity =  transform.right * launchForce;      
        }
            
    }

   
 
}
