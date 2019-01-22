using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //store which player is attacking the goal
    [SerializeField]
    int attackPlayer = 0;

    //stores the game manager script
    //[SerializeField]
   // GameObject gameManObj;

   // GameManager gameMan;
    void Start()
    {
      //  gameMan = gameManObj.GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
    /*void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.name == "Ball")
        {
            Debug.Log("Player" + attackPlayer + "scored");
            gameMan.Score(attackPlayer);
        }
    }*/
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            GameManager.Score(attackPlayer);
            //hitInfo.gameObject.SendMessage("RestartBall");
        }
    }
}
