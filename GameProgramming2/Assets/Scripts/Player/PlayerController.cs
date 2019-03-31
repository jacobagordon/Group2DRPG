using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector2 moveSpeed = new Vector2(5.0f, 5.0f);
    [SerializeField]
    float attackTime = 2f;

    bool playerMoving = false;
    bool bowAttack = false;
    bool swordAttack = false;
    bool gunAttack = false;
    bool magicAttack = false;
    float attackTimeCounter = 2f;

    Vector2 lastMove;

    SpriteRenderer mySpriteRenderer;
    Rigidbody2D myRigidbody2D;

    Animator myAnimator;
    Animator camAnim;

    //Transform attackPos;
    [SerializeField]
    LayerMask whatIsEnemies;
    [SerializeField]
    float attackRange;
    [SerializeField]
    int damage;

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
        if (!bowAttack || !swordAttack || !gunAttack || !magicAttack)
        {
            Walk();
        }

        BowAttack();
        GunAttack();
        MagicAttack();
        SwordAttack();

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
        if(Input.GetKeyDown(KeyCode.Alpha1))
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

    private void SwordAttack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            attackTimeCounter = attackTime;
            swordAttack = true;
            myRigidbody2D.velocity = Vector2.zero;
            myAnimator.SetBool("SwordAttack", true);
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            swordAttack = false;
            myAnimator.SetBool("SwordAttack", false);
        }
    }

    private void GunAttack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            attackTimeCounter = attackTime;
            gunAttack = true;
            myRigidbody2D.velocity = Vector2.zero;
            myAnimator.SetBool("GunAttack", true);
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            gunAttack = false;
            myAnimator.SetBool("GunAttack", false);
        }
    }

    private void MagicAttack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            attackTimeCounter = attackTime;
            magicAttack = true;
            myRigidbody2D.velocity = Vector2.zero;
            myAnimator.SetBool("MagicAttack", true);

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<RobotMiniController>().TakeDamage(damage);
            }
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            magicAttack = false;
            myAnimator.SetBool("MagicAttack", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
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
