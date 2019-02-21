using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{

    [SerializeField]
    private float moveSpeedX = 5.0f;

    [SerializeField]
    private float moveSpeedY = 5.0f;

    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        if (directionX > 0.0f)
        {
            //Left
        }
        else
        {
            //Right
        }

        float velocityX = moveSpeedX * directionX;
        float velocityY = moveSpeedY * directionY;
        myRigidbody2D.velocity = new Vector2(velocityX, velocityY);
    }
}
