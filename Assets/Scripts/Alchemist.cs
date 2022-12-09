using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist : Collidable
{
    public Animator animator;
    public AlchemistMenu alchemistMenu;
    private float messageCooldown = 1.0f;
    private float lastMessage;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {   
            if(Time.time - lastMessage > messageCooldown)
            {
                lastMessage = Time.time;
                GameManager.instance.ShowText("E", 40, Color.white, transform.position + new Vector3(0, 0.20f), Vector3.zero, messageCooldown);
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("show");
                alchemistMenu.UpdateMenu();
            }
        }
    }
}
