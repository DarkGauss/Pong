using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    float boundY = 2.25f;

    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();

        if (rb2D == null)
        {
            Debug.LogError("No rigidbody attached");
        }

    }

    /*
     * Allows for moving of the paddle, a distance as entered, and it will
     * be scaled to the length of time of the frame
     */
    public void Move(float distance)
    {


        float newY = rb2D.position.y + distance * Time.fixedDeltaTime;
        Vector2 vel = new Vector2(0f, distance * Time.fixedDeltaTime);
        //don't move if we are out of bounds
        if (newY <= boundY && newY >= -boundY)
        {
            rb2D.MovePosition(rb2D.position + vel);
        }
        if (rb2D.velocity.magnitude > 0) { Debug.Log(rb2D.velocity); }
    }
}
