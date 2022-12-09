using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Enemy
{
    public float[] ballSpeed;
    public float balldistance;
    public float balldistance_2;
    public Transform[] balls;
    public Animator ending;

    private void Update()
    {
        balls[0].position = transform.position + new Vector3(-Mathf.Cos(Time.time * ballSpeed[0]) * balldistance, Mathf.Sin(Time.time * ballSpeed[0]) * balldistance, 0);
        balls[1].position = transform.position + new Vector3(Mathf.Cos(Time.time * ballSpeed[1]) * balldistance, -Mathf.Sin(Time.time * ballSpeed[1]) * balldistance_2, 0);
    }

    protected override void death()
    {
        Destroy(gameObject);
        GameManager.instance.FinalBossDefeated = true;
        ending.SetTrigger("show");
        if(GameManager.instance.weapon.weaponLevel == 0)
        {
            GameManager.instance.Level_0 = true;
        }
    }
}
