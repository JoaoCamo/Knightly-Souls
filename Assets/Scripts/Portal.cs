using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] Scenes;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.floorUp = true;
            GameManager.instance.SaveState();
            if(GameManager.instance.floor == 25 && GameManager.instance.finalboss == false)
            {
                SceneManager.LoadScene("PreFinalBoss");
                GameManager.instance.finalboss = true;
            } else if(GameManager.instance.finalboss == true) {
                SceneManager.LoadScene("FinalBoss");
                GameManager.instance.finalboss = false;
            } else {
                string scene = Scenes[Random.Range(0, Scenes.Length)];
                SceneManager.LoadScene(scene);
            }
        }
    }
}
