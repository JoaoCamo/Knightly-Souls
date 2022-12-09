using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemistMenu : MonoBehaviour
{
    public Text PotionPriceSmall, PotionPriceBig;
    public AudioSource potionHealAudio;

    public void UpdateMenu()
    {
        if(GameManager.instance.player.hitpoint == GameManager.instance.player.maxHitpoint)
        {
            PotionPriceBig.text = "MAX";
            PotionPriceSmall.text = "MAX";
        } else {
            PotionPriceBig.text = "50";
            PotionPriceSmall.text = "20";
        }
    }

    public void BuyPotionBig()
    {
        if(GameManager.instance.player.hitpoint < GameManager.instance.player.maxHitpoint && GameManager.instance.Gold >= 50)
        {
            if(GameManager.instance.player.hitpoint + 40 < GameManager.instance.player.maxHitpoint)
            {
                GameManager.instance.player.hitpoint += 40;
            } else if (GameManager.instance.player.hitpoint + 40 > GameManager.instance.player.maxHitpoint) {
                GameManager.instance.player.hitpoint += GameManager.instance.player.maxHitpoint - GameManager.instance.player.hitpoint; 
            }
            potionHealAudio.Play();
            GameManager.instance.Gold -= 50;
            GameManager.instance.HealthBarChange();
            UpdateMenu();
        } else {
            return;
        }
    }

    public void BuyPotionSmall()
    {
        if(GameManager.instance.player.hitpoint < GameManager.instance.player.maxHitpoint && GameManager.instance.Gold >= 20)
        {
            if(GameManager.instance.player.hitpoint + 10 < GameManager.instance.player.maxHitpoint)
            {
                GameManager.instance.player.hitpoint += 10;
            } else if (GameManager.instance.player.hitpoint + 10 > GameManager.instance.player.maxHitpoint) {
                GameManager.instance.player.hitpoint += GameManager.instance.player.maxHitpoint - GameManager.instance.player.hitpoint; 
            }
            potionHealAudio.Play();
            GameManager.instance.Gold -= 20;
            GameManager.instance.HealthBarChange();
            UpdateMenu();
        } else {
            return;
        }
    }
}
