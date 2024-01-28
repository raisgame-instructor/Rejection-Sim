using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMoverment : MonoBehaviour
{

    public string SceneName;

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
    public GameObject pausecanvas;

    private void Update()
    {
        Interacting();
        OnPause();
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
        if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0f;
            pausecanvas.SetActive(true);
        }
        //set timescale to Zero and open pause canvas
        
        //will probably need to create a script for pause canvas and have buttons resume and quit and such

        //default keys for this ATM are "Esc" and "P"
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        pausecanvas.SetActive(false);

    }
     
    public void OnRestart()
    {

        SceneManager.LoadScene(SceneName);


    }

    public void OnQuit()
    {
        Application.Quit();
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
