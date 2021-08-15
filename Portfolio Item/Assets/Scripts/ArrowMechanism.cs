using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMechanism : MonoBehaviour 
{ 
    void Start()
    {
        
    }


	void Update()
	{
       
         Direction();
         
		
	}
    public void Direction()
    {
        Vector2 arrowPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Direction = mousePos - arrowPos;
        transform.right = Direction;
    }

}
