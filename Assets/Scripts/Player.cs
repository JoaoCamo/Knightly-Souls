using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    private bool alive = true;
    public int armorLevel = 0;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(alive == true)
        {
            UpdateMotor(new Vector3(x,y,0));
        }
    }

    public void UpgradeArmor()
    {
        armorLevel++;
        maxHitpoint += 5;
    }

    public void SetArmorLevel(int level)
    {
        armorLevel = level;
    }

    public void ResetArmorLevel()
    {
        armorLevel = 0;
        maxHitpoint = 15;
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if(!alive)
        {
            return;
        }

        base.ReceiveDamage(dmg);
        GameManager.instance.HealthBarChange();
    }

    protected override void death()
    {
        alive = false;
        GameManager.instance.deathMenu.SetTrigger("show");
    }

    public void Respawn()
    {
        hitpoint = maxHitpoint;
        alive = true;
        lastImmune = Time.time;
    }
}
