using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemy1Script : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public static int enemyDirection = 0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();  

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Laser: " + bulletScript.bulletX + ":" + gameObject.transform.position.x + " / " + bulletScript.bulletY + ":" + gameObject.transform.position.y);
        float otherObjectX = (float)Math.Round(bulletScript.bulletX,1);
        float otherObjectY = (float)Math.Round(bulletScript.bulletY,1);
        float thisObjectX = (float)Math.Round(gameObject.transform.position.x,1);
        float thisObjectY = (float)Math.Round(gameObject.transform.position.y,1);
        Debug.Log("Ship[0]: " + otherObjectX + ":" + thisObjectX + " / " + otherObjectY + ":" + thisObjectY);
        //Debug.Log("Ship[0]: " + spaceshipScript.shipX + ":" + gameObject.transform.position.x + " / " + spaceshipScript.shipY + ":" + gameObject.transform.position.y);
        //Debug.Log("Ship[1]: " + spaceshipScript.shipX + ":" + rb2d.position.x + " / " + spaceshipScript.shipY + ":" + rb2d.position.y);
        //if (bulletScript.bulletX == gameObject.transform.position.x || bulletScript.bulletY == gameObject.transform.position.y) {
        if (otherObjectX == thisObjectX && otherObjectY == thisObjectY) {            
            Destroy(gameObject);
        } else {
            /*
            if (enemyDirection == 0) {
                enemyDirection = 1;
                rb2d.velocity = new Vector2(2.0f, 2.0f);
            } else {
                enemyDirection = 0;
                rb2d.velocity = new Vector2(-2.0f, -2.0f);
            }
            */
        }
    }
}
