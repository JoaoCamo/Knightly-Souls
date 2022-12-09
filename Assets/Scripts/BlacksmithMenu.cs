using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlacksmithMenu : MonoBehaviour 
{
    public Text UpgradePrice;
    public Text UpgradePriceArmor;
    public Image weaponSprite;
    public AudioSource upgradeAudio;

    public void UpdateMenu()
    {
        if(GameManager.instance.weapon.weaponLevel == GameManager.instance.SwordPrices.Count)
        {
            UpgradePrice.text = "MAX";
        } else {
            UpgradePrice.text = GameManager.instance.SwordPrices[GameManager.instance.weapon.weaponLevel].ToString();
        }
        if(GameManager.instance.weapon.weaponLevel != 5)
        {
            weaponSprite.sprite = GameManager.instance.SwordSprites[GameManager.instance.weapon.weaponLevel + 1];
        }

        if(GameManager.instance.player.armorLevel == GameManager.instance.ArmorPrices.Count)
        {
            UpgradePriceArmor.text = "MAX";
        } else {
            UpgradePriceArmor.text = GameManager.instance.ArmorPrices[GameManager.instance.player.armorLevel].ToString();
        }
    }

    public void OnUpgradeClickWeapon()
    {
        if(GameManager.instance.TryUpgradeWeapon())
        {
            upgradeAudio.Play();
            UpdateMenu();
        }
    }

    public void OnUpgradeClickArmor()
    {
        if(GameManager.instance.TryUpgradeArmor())
        {
            upgradeAudio.Play();
            UpdateMenu();
            GameManager.instance.HealthBarChange();
        }
    }
}
