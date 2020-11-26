using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 6.0f;
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public static float bulletX = 0;
    public static float bulletY = 0;
    // Start is called before the first frame update

    public AudioSource audioSource;

    void Start()
    {
        //Debug.Log("Bullet Start.");
        rb2d = GetComponent<Rigidbody2D> ();  
        rb2d.velocity = new Vector2(0.0f, speed);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("Bullet Collision");
        //audioSource.Play();
        //Destroy(gameObject);
        //Do something
    }


    // Function called when the object goes out of the screen
    void OnBecameInvisible() {
        // Destroy the bullet 
        //Debug.Log("Bullet Destroyed.");
        //Destroy(gameObject);
         enabled = false;
         Destroy(gameObject);
    } 

    // Update is called once per frame
    void Update()
    {
            bulletX = gameObject.transform.position.x;
            bulletY = gameObject.transform.position.y;

            //if ((speed + Time.deltaTime) > 1.0f)
            {
                //Debug.Log("Laser: " + gameObject.transform.position.y + " : " + gameObject.transform.position.x + " : " + speed);
                speed = 0.0f;
            }
        
    }
}
