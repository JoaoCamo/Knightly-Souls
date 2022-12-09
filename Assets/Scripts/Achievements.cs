using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public List<Sprite> Trophies;
    public List<Image> Trophie_images;
    public Text Trophie_1_text;
    public Text Trophie_2_text;
    public Text Trophie_3_text;
    public Text Trophie_4_text;
    public Text Trophie_5_text;
    public Text Trophie_6_text;

    public void UpdateMenu()
    {
        if(GameManager.instance.FinalBossDefeated == true)
        {
            Trophie_images[0].sprite = Trophies[0];
            Trophie_1_text.text = "Defensor do mundo\nDerrote o chefe final";
        }
        if(GameManager.instance.DemonMiniBossDefeated == true) 
        {
            Trophie_images[1].sprite = Trophies[1];
            Trophie_2_text.text = "Demon Slayer\nDerrote o chefe dos demônios";
        }
        if(GameManager.instance.OrcMiniBossDefeated == true)
        {
            Trophie_images[2].sprite = Trophies[3];
            Trophie_3_text.text = "WoW player\nDerrote o chefe dos orcs";
        }
        if(GameManager.instance.SkeletonMiniBossDefeated == true)
        {
            Trophie_images[3].sprite = Trophies[2];
            Trophie_4_text.text = "Crusader\nDerrote o Chefe morto-vivo";
        }
        if(GameManager.instance.enemyKills >= 1000)
        {
            Trophie_images[4].sprite = Trophies[4];
            Trophie_5_text.text = "Berserk\nDerrote 1000 inimigos";
        }
        if(GameManager.instance.Level_0 == true)
        {
            Trophie_images[5].sprite = Trophies[5];
            Trophie_6_text.text = "Meus parabéns\nDerrote o chefe final com a primeira espada";
        }
    }

}
