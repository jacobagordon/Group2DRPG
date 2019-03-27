using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector2 moveSpeed = new Vector2(5.0f, 5.0f);
    [SerializeField]
    float attackTime = 1f;

    bool playerMoving = false;
    bool bowAttack = false;
    float attackTimeCounter = 1f;

    Vector2 lastMove;

    SpriteRenderer mySpriteRenderer;
    Rigidbody2D myRigidbody2D;

    Animator myAnimator;



    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!bowAttack)
        {
            Walk();
        }

        BowAttack();
        Menu();
    }

    private void Walk()
    {
        playerMoving = false;
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 velocity = new Vector2(direction.x * moveSpeed.x, direction.y * moveSpeed.y);
        myRigidbody2D.velocity = velocity;
        
        if(direction.x > 0.5f || direction.x < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(direction.x, 0f);
        }

        if(direction.y > 0.5f || direction.y < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, direction.y);
        }

        myAnimator.SetFloat("MoveX", direction.x);
        myAnimator.SetFloat("MoveY", direction.y);
        myAnimator.SetBool("PlayerMoving", playerMoving);
        myAnimator.SetFloat("LastMoveX", lastMove.x);
        myAnimator.SetFloat("LastMoveY", lastMove.y);
    }

    private void BowAttack()
    {
        if(Input.GetButtonDown("Jump"))
        {
            attackTimeCounter = attackTime;
            bowAttack = true;
            myRigidbody2D.velocity = Vector2.zero;
            myAnimator.SetBool("BowAttack", true);
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            bowAttack = false;
            myAnimator.SetBool("BowAttack", false);
        }
    }

    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject ip = Inventory.instance.inventoryPanel;

            if (!ip.activeSelf)
            {
                ip.SetActive(true);
            }
            else
            {
                ip.SetActive(false);
            }
        }
    }
}
