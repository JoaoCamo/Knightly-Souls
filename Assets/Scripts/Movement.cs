using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : Fighter
{

    private Vector3 originalSize;
    protected BoxCollider2D BoxCollider;
    protected Vector3 movement;
    protected RaycastHit2D hit;
    protected Animator animator;
    public bool hasAnimation = true;
    public float xSpeed = 1f;
    public float ySpeed = 1f;

    protected virtual void Start()
    {
        originalSize = transform.localScale;
        BoxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void UpdateMotor(Vector3 Input)
    {
        movement = new Vector3(Input.x * xSpeed, Input.y * ySpeed, 0);

        if(hasAnimation == true)
        {
            if(movement.x > 0)
            {
                transform.localScale = originalSize;
                animator.SetBool("Moving", true);
                if(!audio.isPlaying)
                {
                    audio.Play();
                }
            } else if(movement.x < 0) {
                transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);
                animator.SetBool("Moving", true);
                if(!audio.isPlaying)
                {
                    audio.Play();
                }
            } else if(movement.y > 0 || movement.y < 0) {
                animator.SetBool("Moving", true);
                if(!audio.isPlaying)
                {
                    audio.Play();
                }
            } else if( movement.x == 0) {
                animator.SetBool("Moving", false);
                audio.Stop();
            }
        } else {
            if(movement.x > 0)
            {
                transform.localScale = originalSize;
            } else if(movement.x < 0) {
                transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);
            }
        }

        movement += pushDirection;

        pushDirection = Vector3.Lerp(pushDirection,Vector3.zero,pushRecoverySpeed);

        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(movement.x, 0), Mathf.Abs(movement.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(movement.x * Time.deltaTime, 0, 0);
        }

        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(0, movement.y), Mathf.Abs(movement.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(0, movement.y * Time.deltaTime, 0);
        }
    }
}
