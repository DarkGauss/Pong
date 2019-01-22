using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //describes how much the ball reacts to how far it was from center of baddle
    [SerializeField]
    float response = 1f;
    
    //max y velocity the ball can have
    [SerializeField]
    float maxY = 10f;

    [SerializeField]
    Vector2 initForce = new Vector2(20, -15);

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2);
    }

    void StartBall()
    {
        Debug.Log("Starting ball");
        GameObject.Find("GameManager").SendMessage("updateScoreText");
        //decides which direction the ball will go in
        float rand = Random.Range(0, 2);

        if (rand < 1)
        {
            rb2d.AddForce(initForce);
        }
        else
        {
            rb2d.AddForce(new Vector2(-initForce.x, initForce.y));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartBallGame()
    {
        Debug.Log("Restarting");
        ResetBallPos();
        Invoke("StartBall", 4);
    }
    public void RestartBall()
    {
        ResetBallPos();
        Invoke("StartBall", 1);
    }
    void ResetBallPos()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //when we collide with player
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            
            //gets the diffrence in y postion between the ball and the paddle
            float diffrence = rb2d.position.y - coll.transform.position.y;
            vel.y = rb2d.velocity.y + diffrence * response;
            if(vel.y >= maxY)
            {
                vel.y = maxY;
            }
            if(vel.y <= -maxY)
            {
                vel.y = -maxY;
            }
            rb2d.velocity = vel;
        }
    }
}
