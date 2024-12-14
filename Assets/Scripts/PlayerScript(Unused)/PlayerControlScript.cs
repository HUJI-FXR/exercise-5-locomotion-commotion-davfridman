using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    private MovementScript movementScript;

    void Start()
    {
        movementScript = GetComponent<MovementScript>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){movementScript.Jump();}

        if (Input.GetKey(KeyCode.A)) {movementScript.MoveLeft();}
        else if (Input.GetKey(KeyCode.D)){movementScript.MoveRight();}

        if (Input.GetKey(KeyCode.W)){movementScript.MoveFront();}
        else if (Input.GetKey(KeyCode.S)){movementScript.MoveBack();}
    }
}