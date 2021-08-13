using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public TextMeshProUGUI bulletText;
   Ammo ammo;
    void Start()
    {
         ammo = GetComponent<Ammo>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
