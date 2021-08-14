using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] bool isOnGround = false;
    [SerializeField]  GameObject [] arrowPrefabs;
    [SerializeField] Transform groundCheck;
    [SerializeField] float launchForce = 10f;
    [SerializeField] Transform firePoint;
    public Slider slider;
    public TextMeshProUGUI NormalarrowCountText;
    public TextMeshProUGUI FirearrowCountText;
    public TextMeshProUGUI WaterarrowCountText;
    Rigidbody2D rb;
    SpriteRenderer sp;
    public int fireIndex;
    public int playerhealthpoints = 100;
    Vector3 screenPos; 
    Ammo ammo;
    Enymy enymy;
   
    
    
    void Start()
    {
        GetComponents();
    }
    void Update()
    {     
        Fire();
        MovePlayer();  
        GroundCheck();
        UpdateUI();
        DestryOutOfBound();
        Die();
    }
    void GetComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        ammo = gameObject.GetComponent<Ammo>();  
        sp = GetComponent<SpriteRenderer>();
        enymy = GameObject.FindGameObjectWithTag("Enymy").GetComponent<Enymy>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.CompareTag("Arrow"))
        {
            Destroy(other.gameObject);

            if (fireIndex == 0)
            {
                ammo.NormalammoCount++;
            }
            else if (fireIndex == 1)
            {
                ammo.FireammoCount++;
            }
            else if (fireIndex == 2)
            {
                ammo.WaterammoCount++;
            }
        }
    }
        
        
        

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce (Vector2.right * horizontalInput * moveSpeed  * Time.deltaTime ,ForceMode2D.Force);
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rb.AddForce (Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    } 

    public void Fire ()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            NormalarrowCountText.gameObject.SetActive(true);
            FirearrowCountText.gameObject.SetActive(false);
            WaterarrowCountText.gameObject.SetActive(false);
            fireIndex = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) )
        {
            NormalarrowCountText.gameObject.SetActive(false);
            FirearrowCountText.gameObject.SetActive(true);
            WaterarrowCountText.gameObject.SetActive(false);
            fireIndex = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) )
        {
            NormalarrowCountText.gameObject.SetActive(false);
            FirearrowCountText.gameObject.SetActive(false);
            WaterarrowCountText.gameObject.SetActive(true);       
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

    void GroundCheck ()
    { 
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, 0.1f);
           if(groundInfo.collider == true)
           {
               isOnGround = true;
           }
           else
           {
               isOnGround= false;
           }
    }

     public void UpdateUI()
    {
        NormalarrowCountText.text = ammo.NormalammoCount.ToString();
        FirearrowCountText.text = ammo.FireammoCount.ToString();
        WaterarrowCountText.text = ammo.WaterammoCount.ToString();
        slider.value = playerhealthpoints;
    }
    void DestryOutOfBound()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0,0, camDistance));
        Vector2 rightlimit = Camera.main.ViewportToWorldPoint(new Vector3(1,1, camDistance));
        Vector3 pos = transform.position;
        float minX = leftLimit.x;
        float maxX = rightlimit.x;
        if(pos.x < minX) pos.x = minX;
        if(pos.x > maxX) pos.x = maxX;
        transform.position = pos;       
    }

    void Die()
    {
        if(playerhealthpoints <= 0)
        {
             //play death animation
            slider.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
 
}
