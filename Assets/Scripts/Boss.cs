using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public bool isOrc;
    public bool isSkeleton;
    public bool isDemon;

    protected override void enemyStrength()
    {
        maxHitpoint += (5*GameManager.instance.floor);
        hitpoint = maxHitpoint;
    }

    protected override void death()
    {
        Destroy(gameObject);
        enemyGold = Random.Range(20,35);
        GameManager.instance.Gold += enemyGold;
        GameManager.instance.ShowText(enemyGold + " de Ouro!", 30, Color.yellow, transform.position, Vector3.up * 75, 1.0f);
        if(isOrc == true)
        {
            GameManager.instance.OrcMiniBossDefeated = true;
        } else if(isSkeleton == true) {
            GameManager.instance.SkeletonMiniBossDefeated = true;
        } else if(isDemon == true) {
            GameManager.instance.DemonMiniBossDefeated = true;
        }
    }
}
