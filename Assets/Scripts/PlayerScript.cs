using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameObject LevelWonPanel;
    public GameObject LevelLostPanel;
    public GameObject ResumeGamePanel;
    public float speed;
    public float movespeed=1;
    public static bool IsGamePaused = false;
    private bool isGameOver = false;

    void Start()
    {

    }
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused == true)
            {
                ResumeGame ();
            }
            else
            {
                PauseGame ();
            }
        }

     // Movement Parameters
       if(isGameOver == true)
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
                isGameOver=true;
            }
            else if(other.tag == "Obstacle")
            {
                Debug.Log("Level Lost");
                LevelLostPanel.SetActive(true); 
                isGameOver=true;
            }
            else if(other.tag == "Portal")
            {
                transform.position = new Vector2(-5.0f, 1.0f);
            }  
            else if(other.tag == "Portal2")
            {
                transform.position = new Vector2(3.0f, -3.0f);
            }    
        }

        public void RestartGame()
        
        {
            Debug.Log("Button Clicked");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
        public void ResumeGame ()
        {
            ResumeGamePanel.SetActive(false);
            Time.timeScale = 1; 
            IsGamePaused = false;
        }
        void PauseGame ()
        {
            ResumeGamePanel.SetActive(true);
            Time.timeScale = 0;
            IsGamePaused = true;
        }
        public void QuitGame()
        {
            Debug.Log("Quit");
        }
        
}
