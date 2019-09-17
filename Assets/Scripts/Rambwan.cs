using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class Rambwan : MonoBehaviour
{
    Sprite rambwan;

    void Start()
    {
        rambwan = GetComponent<Sprite>();
        rambwan.stats.health = 100;
        rambwan.stats.moveSpeed = 1;
        rambwan.stats.maxJumpHeight = 3;
        rambwan.stats.minJumpHeight = 1;
        rambwan.stats.timeToJumpApex = .3f;
        rambwan.stats.wallSlideSpeedMax = 3;
        rambwan.stats.wallStickTime = .25f;
    }

    void Update()
    {
        if (!CheckRambwanAlive())
        {
            Destroy(gameObject);
        } else
        {
            print("Tag Left: " + rambwan.controller.collisions.tagLeft);
            print("Tag Right: " + rambwan.controller.collisions.tagRight);
            print("Tag Above: " + rambwan.controller.collisions.tagAbove);
            print("Tag Below: " + rambwan.controller.collisions.tagBelow);

            //Vector2 directionalInput = new Vector2(-1, 0);
            HandlePlayerInteractions();
        }
    }

    bool CheckRambwanAlive()
    {
        if (rambwan.stats.health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /*
     * Deals with any effects on the rambwan due to interactions with players. 
     */
    void HandlePlayerInteractions()
    {
        if (rambwan.controller.collisions.tagAbove == "Player")
        {
            rambwan.stats.health -= 10;
            print("Rambwan health: " + rambwan.stats.health);
        }
    }
}
