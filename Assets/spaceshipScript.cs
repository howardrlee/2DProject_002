﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

// Author: Howard R. Lee
// Email: howardrlee@yahoo.com
// Company: Affinity Systems, Inc.
// Date: November 23, 2020


public class spaceshipScript : MonoBehaviour
{
    private bool moving = false;
    public float speed = 2.0f;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public GameObject bullet;

    public static float shipX = 0;
    public static float shipY = 0;

    public AudioSource audioSource;

  private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();        
    }

    // Update is called once per frame
    void Update()
    {
        shipX = gameObject.transform.position.x;
        shipY = gameObject.transform.position.y;

 //Press the Up arrow key to move the RigidBody upwards
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.velocity = new Vector2(0.0f, 2.0f);
            moving = true;
            speed = 0.0f;
        } else 

        //Press the Down arrow key to move the RigidBody downwards
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.velocity = new Vector2(0.0f, -2.0f);
            moving = true;
            speed = 0.0f;
        } else

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(5.0f, 0.0f);
            moving = true;
            speed = 0.0f;
        } else

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-5.0f, 0.0f);
            moving = true;
            speed = 0.0f;
        } else

        if (Input.GetKey(KeyCode.End))
        {
            rb2d.velocity = new Vector2(0.0f, 0.0f);
            moving = false;
            speed = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("KeyCode.Space");
            // Create a new bullet at “transform.position” 
            // Which is the current position of the ship
            // Quaternion.identity = add the bullet with no rotation
            audioSource.Play();
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);            
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Debug.Log("KeyCode.Return");
            // Create a new bullet at “transform.position” 
            // Which is the current position of the ship
            // Quaternion.identity = add the bullet with no rotation
            enabled = false;
            Destroy(gameObject);
        }

        if (moving)
        {
            // Record the time spent moving up or down.
            // When this is 1sec then display info
            speed = speed + Time.deltaTime;
            if (speed > 1.0f)
            {
                //Debug.Log(gameObject.transform.position.y + " : " + speed);
                speed = 0.0f;
            }
        }

        //StartCoroutine(GetRequest("http://api.icndb.com/jokes/12"));
        //Debug.Log("Show Called: " + Screen.width + "/" + Screen.height + "[" +  gameObject.transform.position.x +"/" + gameObject.transform.position.y+"]");
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("Show Called[0]: "+screenBounds + " | [" + gameObject.transform.position.x +"/" + gameObject.transform.position.y+"]");
        //Debug.Log("Show Called[1]: "+screenOrigo + " | [" + gameObject.transform.position.x +"/" + gameObject.transform.position.y+"]");

    }

IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Debug.Log(uri);
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            //string[] pages = uri.Split('/');
            //int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                //Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                if (speed > 1.0f) {
                    //Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                }
            }
        }
    }    
}
