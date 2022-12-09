using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collected
{
    public Sprite emptyChest;
    public int chestGold;

    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            chestGold = Random.Range(1,20);
            GameManager.instance.Gold += chestGold;
            GameManager.instance.ShowText(chestGold + " de Ouro!", 25, Color.yellow, transform.position, Vector3.up * 75, 2.5f);
        }
    }
}
