using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Howard R. Lee
// Email: howardrlee@yahoo.com
// Company: Affinity Systems, Inc.
// Date: November 23, 2020


public class spawnScript : MonoBehaviour
{
     // Variable to store the enemy prefab
    public GameObject enemy;

    // Variable to know how fast we should create new enemies
    public float spawnTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addEnemy", 0, spawnTime);    
    }

    // New function to spawn an enemy
    public void addEnemy() {
        // Get the renderer component of the spawn object
        var rd = GetComponent<Renderer> ();

        // Position of the left edge of the spawn object
        // It's: (position of the center) minus (half the width)
        var x1 = transform.position.x - rd.bounds.size.x/2;

        // Same for the right edge
        var x2 = transform.position.x + rd.bounds.size.x/2;

        // Randomly pick a point within the spawn object
        var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Create an enemy at the 'spawnPoint' position
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    } 


    // Update is called once per frame
    void Update()
    {
        
    }
}

