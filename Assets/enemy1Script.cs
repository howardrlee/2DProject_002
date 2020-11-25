using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class enemy1Script : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public static int enemyDirection = 0;

    public static Boolean destroyed = false;

    DateTime destroyTime = DateTime.UtcNow;

    public AudioSource audioSource;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        Scene scene = SceneManager.GetActiveScene();

        //soundExplosion = Resources.Load<AudioClip>("Explosion 1.wav");
        //audioSource = GetComponent<AudioSource>();
    }

     private void OnTriggerEnter2D(Collider2D collider2D)
    {
        audioSource.Play();
        //Do something
        Debug.Log("Enemy Collision");
        //Destroy(gameObject);
        gameObject.SetActive(false);
        destroyed = true;
        destroyTime = DateTime.UtcNow;
        Invoke("show", 5.0f);
    }

    void show() {
        Debug.Log("Show Called: " + Screen.width + "/" + Screen.height + "[" +  gameObject.transform.position.x +"/" + gameObject.transform.position.y+"]");
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
        TimeSpan diff = DateTime.UtcNow.Subtract(destroyTime);
        if (true) {            
            Debug.Log("Diff: " + diff);
            /*
            if (diff.TotalSeconds > 5) {
                destroyed = false;
                gameObject.SetActive(true);
            }
            */
        }
        Debug.Log("show: " + diff);
        gameObject.SetActive(true);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // Range to re-animate the enemy ship
        System.Random rnd = new System.Random();

        Debug.Log("Random[" + screenOrigo.x + "/" + screenBounds.x + "]");
        transform.position = new Vector2((float) rnd.Next((int)screenOrigo.x, (int)screenBounds.x), 0.0f);
        //transform.position += Vector3.right * 2.0f;
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Show Called[0]: "+screenBounds + " | [" + gameObject.transform.position.x +"/" + gameObject.transform.position.y+"]");
        Debug.Log("Show Called[1]: "+screenOrigo + " | [" + gameObject.transform.position.x +"/" + gameObject.transform.position.y+"]");
    }
    // Update is called once per frame
    void Update()
    {
        //if (destroyed == true) {
        /*
        if (destroyed == false) {
            //Debug.Log("Laser: " + bulletScript.bulletX + ":" + gameObject.transform.position.x + " / " + bulletScript.bulletY + ":" + gameObject.transform.position.y);
            float otherObjectX = (float)Math.Round(bulletScript.bulletX,1);
            float otherObjectY = (float)Math.Round(bulletScript.bulletY,1);
            float thisObjectX = (float)Math.Round(gameObject.transform.position.x,1);
            float thisObjectY = (float)Math.Round(gameObject.transform.position.y,1);
            //Debug.Log("Ship[0]: " + otherObjectX + ":" + thisObjectX + " / " + otherObjectY + ":" + thisObjectY);
            //Debug.Log("Ship[0]: " + spaceshipScript.shipX + ":" + gameObject.transform.position.x + " / " + spaceshipScript.shipY + ":" + gameObject.transform.position.y);
            //Debug.Log("Ship[1]: " + spaceshipScript.shipX + ":" + rb2d.position.x + " / " + spaceshipScript.shipY + ":" + rb2d.position.y);
            //if (bulletScript.bulletX == gameObject.transform.position.x || bulletScript.bulletY == gameObject.transform.position.y) {
            if (otherObjectX == thisObjectX && otherObjectY == thisObjectY) {            
                Destroy(gameObject);
                destroyed = true;
            } else {
          
                if (enemyDirection == 0) {
                    enemyDirection = 1;
                    rb2d.velocity = new Vector2(2.0f, 2.0f);
                } else {
                    enemyDirection = 0;
                    rb2d.velocity = new Vector2(-2.0f, -2.0f);
                }
          
            }
        }
        */
    }
}
