using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    PaddleMovement moveComp;

    [SerializeField]
    float speed = 10.0f;

    [SerializeField]
    string inputAxis = "MovementY";

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        moveComp = this.GetComponent<PaddleMovement>();

        if (moveComp== null)
        {
            Debug.LogError("No move component");
        }

    }

  
    void FixedUpdate()
    { 
        float moveY = Input.GetAxis(inputAxis);
        moveComp.Move(moveY*speed);
    }
}
