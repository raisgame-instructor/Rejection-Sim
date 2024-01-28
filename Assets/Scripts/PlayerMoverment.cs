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

    //for gizmo to interact with romance partners
    public Transform Location;
    public float checkradius;
    public LayerMask whatInteract;
    public bool isInteracting;

    public bool CanMove = true;

    private void Update()
    {
        Interacting();
    }

    private void OnMove(InputValue IValue)
    {
        if (CanMove)
        {
            Movement = IValue.Get<Vector2>();
            RB2D.velocity = Movement * Speed;
        }
    }

    private void OnPause()
    {
        //set timescale to Zero and open pause canvas
        //will probably need to create a script for pause canvas and have buttons resume and quit and such
        //default keys for this ATM are "Esc" and "P"
    }


    void Interacting()
    {
        isInteracting = Physics2D.OverlapCircle(Location.position, checkradius, whatInteract);
    }

    void OnInteract()
    {
        if (isInteracting == true)
        {
            CanInteract = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Location.position, checkradius);
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
