using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoverment : MonoBehaviour
{
    public Rigidbody2D RB2D;
    private Vector2 Movement;
    public float Speed;
    public bool CanInteract;

    public Transform Location;
    public float checkradius;
    public LayerMask whatInteract;


    private void OnMove(InputValue IValue)
    {
        Movement = IValue.Get<Vector2>();
        RB2D.velocity = Movement * Speed;
    }

    
    private void OnInteract()
    {
        CanInteract = true;
    }




    /* player moves
     * if (in trigger volume)
     * {
     *  UI on, show "press button to talk"
     *  {
     *      open dialogue UI
     *  }
     * }
     */
}
