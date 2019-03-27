using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMiniController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float timeBetweenMove = 2f;
    [SerializeField]
    float timeToMove = 1f;
    [SerializeField]
    int damageToPlayer = 10;
    [SerializeField]
    Item DropItem;

    float timeBetweenMoveCounter;
    float timeToMoveCounter;
    bool moving = false;
    Vector2 moveDirection;

    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody2D.velocity = moveDirection;
            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody2D.velocity = Vector2.zero;
            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector2(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("Hit Player");
            other.gameObject.GetComponent<PlayerHealthManager>().DamageToPlayer(damageToPlayer);
            Inventory.instance.Add(DropItem);
        }
    }

}
