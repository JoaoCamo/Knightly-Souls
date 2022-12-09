using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficult : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player" && GameManager.instance.floorUp == true)
        {
            GameManager.instance.floor++;
            GameManager.instance.floorUp = false;
        }
    }
}
