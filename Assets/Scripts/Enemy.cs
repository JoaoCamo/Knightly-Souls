using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Movement
{
    public float trigger = 2;
    public float chase = 4;
    public int enemyGold;
    public bool isFinalBoss;
    private bool chasing;
    private bool colliding;
    private Transform playerTransform;
    private Vector3 startingPosition;
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] Hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        if(isFinalBoss == false)
        {
            enemyStrength();
        }
    }

    protected virtual void enemyStrength()
    {
        maxHitpoint += GameManager.instance.floor;
        hitpoint = maxHitpoint;
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(playerTransform.transform.position, startingPosition) < chase)
        {
            if(Vector3.Distance(playerTransform.transform.position, startingPosition) < trigger)
            {
                chasing = true;
            }

            if(chasing)
            {
                if(!colliding)
                {
                    UpdateMotor((playerTransform.transform.position - transform.position).normalized);
                }
            } else {
                UpdateMotor(startingPosition - transform.position);
            }
        } else {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        colliding = false;
        BoxCollider.OverlapCollider(filter,Hits);
        for(int i = 0; i < Hits.Length; i++)
        {
            if(Hits[i] == null)
            {
                continue;
            }

            if(Hits[i].tag == "Fighter" && Hits[i].name == "Player")
            {
                colliding = true;
            }

            Hits[i] = null;
        }
    }

    protected override void death()
    {
        Destroy(gameObject);
        enemyGold = Random.Range(4,8);
        GameManager.instance.Gold += enemyGold;
        GameManager.instance.ShowText(enemyGold + " de Ouro!", 30, Color.yellow, transform.position, Vector3.up * 75, 1.0f);
        GameManager.instance.enemyKills++;
    }
}
