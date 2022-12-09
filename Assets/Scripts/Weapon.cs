using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public int[] SwordDamage = {2,5,10,15,20,30};
    public float SwordKnockback = 5.0f;

    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private float cooldown = 0.5f;
    private float lastSwing;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        } else if(Input.GetKeyDown(KeyCode.X)) {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                SwingUp();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Player")
            {
                return;
            }
            Damage dmg = new Damage
            {
                damageAmount = SwordDamage[weaponLevel],
                origin = transform.position,
                pushForce = SwordKnockback
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        animator.SetTrigger("Attack");        
    }

    private void SwingUp()
    {
        animator.SetTrigger("AttackUp");        
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.SwordSprites[weaponLevel];
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.SwordSprites[weaponLevel];
        
    }

    public void ResetWeaponLevel()
    {
        weaponLevel = 0;
        spriteRenderer.sprite = GameManager.instance.SwordSprites[weaponLevel];
    }
}
