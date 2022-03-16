using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipping : MonoBehaviour
{
    public SpriteRenderer spr;
    public WayPointFollower ways;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            Destroy(this.gameObject); 
        }
    }

    void Update()
    {

        if (ways.currentWaypointIndex == 1)
        {
            spr.flipX = true;
        }
        else 
        {
            spr.flipX = false;
        }
    }
}
