using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameObject LevelWonPanel;
    public float speed;
    public float movespeed=1;
    //public float Velocity;
    void Start()
    {
        
    }
    private bool isGameWon;
    void Update()
    {
        // Movement Parameters
       if(isGameWon == true)
       {
        return;
       }
       if( Input.GetAxis("Horizontal") > 0 ) //Movement to right
       {
        rigidbody2d.velocity =  new Vector2 (speed*movespeed, 0f);
       }
       else if( Input.GetAxis("Horizontal") < 0 ) //Movement to left
       {
        rigidbody2d.velocity =  new Vector2 (-speed*movespeed, 0f);
       }
       else if( Input.GetAxis("Vertical") > 0 ) //Movement to up
       {
        rigidbody2d.velocity =  new Vector2 (0f, speed*movespeed);
       }
       else if( Input.GetAxis("Vertical") < 0 ) //Movement to down
       {
        rigidbody2d.velocity =  new Vector2 (0f, -speed*movespeed);
       }
       else if( Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 ) //Zero Movement
       {
        rigidbody2d.velocity =  new Vector2 (0f, 0f);
       }

    }
    //Trigger
       private void OnTriggerEnter2D (Collider2D other) 
        {
            if(other.tag == "Door")
            {
                Debug.Log("Level Complete");
                LevelWonPanel.SetActive(true); 
                isGameWon=true;
            }
            if(other.tag == "Portal")
            {
                transform.position = new Vector2(-5.0f, 1.0f);
            }  
            if(other.tag == "Portal2")
            {
                transform.position = new Vector2(3.0f, -3.0f);
            }    
        }
}
