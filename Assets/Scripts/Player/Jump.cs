using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{

    private Rigidbody2D rigid;
    private Animator anim;
    public float jumpforce = 5f;
    public bool canJump=true;
    Button jumpButton;
    float forwardForce;


    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpButton = GameObject.Find("Jump Button").GetComponent<Button>();
        jumpButton.onClick.AddListener(() => JumpButton());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        canJump = true;
        if (collision.gameObject.tag == "Obstacle")
        {
            anim.Play("Idle");
            anim.SetBool("Jump", false);
            anim.SetBool("Stop", true);
        }
        if (collision.gameObject.tag == "ground")
        {
            anim.SetBool("Jump", false);

        }
    }
        private void OnCollisionExit2D(Collision2D collision) {

            if (collision.gameObject.tag == "Obstacle")
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Stop", false);
        }
        }
    

        
    

    public void JumpButton()
    {
        if (canJump)
        {
            canJump = false;
            if(transform.position.x < 0)
            {
                forwardForce = 1f;
            }
            else
            {
                forwardForce = 0f;
            }
            anim.SetBool("Jump", true);
            rigid.velocity = new Vector2(forwardForce, jumpforce);
        }


    }
}
