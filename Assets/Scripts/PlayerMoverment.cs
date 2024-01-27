using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoverment : MonoBehaviour
{
    public Rigidbody2D RB2D;
    private Vector2 Movement;
    public float Speed;

    private void OnMove(InputValue IValue)
    {
        Movement = IValue.Get<Vector2>();
        RB2D.velocity = Movement * Speed;
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
