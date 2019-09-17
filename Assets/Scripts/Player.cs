using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Sprite))]
public class Player : MonoBehaviour
{
    Sprite player; 

    void Start()
    {
        player = GetComponent<Sprite>();
        player.stats.health = 100;
        player.stats.moveSpeed = 5;
        player.stats.maxJumpHeight = 2;
        player.stats.minJumpHeight = 1;
        player.stats.timeToJumpApex = .2f;
        player.stats.wallSlideSpeedMax = 3;
        player.stats.wallStickTime = .25f;
    }

    void Update()
    {
        //print("Tag Hor: " + player.controller.collisions.tagHorizontal);
        //print("Tag Vert: " + player.controller.collisions.tagVertical);

        if (!CheckPlayerAlive())
        {
            Destroy(gameObject);
        } else
        {
            Movement();
            EnemyInteractions();
        }
    }

    bool CheckPlayerAlive()
    {
        if (player.stats.health <= 0)
        {
            return false;
        } else
        {
            return true; 
        }
    }

    /*
     * Use input by player to move the player sprite
     */
    void Movement()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.OnJumpInputUp();
        }
    }
    
    /*
     * Deals with any effects on the player due to interactions with enemies. 
     */
    void EnemyInteractions()
    {
        if (player.controller.collisions.tagRight == "Rambwan" || player.controller.collisions.tagLeft == "Rambwan")
        {
            player.stats.health -= 0;
            print("Health: " + player.stats.health);
        }
    }

}
