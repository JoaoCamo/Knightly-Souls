using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text  Health, Gold, Floor, ArmorLevel, SwordLevel, PlayerDamage;
    public Image weaponSprite;

    public void UpdateMenu()
    {
        weaponSprite.sprite = GameManager.instance.SwordSprites[GameManager.instance.weapon.weaponLevel];
        Health.text = GameManager.instance.player.hitpoint.ToString() + "/" + GameManager.instance.player.maxHitpoint.ToString();
        Gold.text = GameManager.instance.Gold.ToString();
        Floor.text = GameManager.instance.floor.ToString() + "/25";
        ArmorLevel.text = "Armadura Nível " + (GameManager.instance.player.armorLevel + 1).ToString();
        SwordLevel.text = "Espada Nível " + (GameManager.instance.weapon.weaponLevel).ToString();
        PlayerDamage.text = "Dano: " + (GameManager.instance.weapon.SwordDamage[GameManager.instance.weapon.weaponLevel]).ToString();
    }
}
