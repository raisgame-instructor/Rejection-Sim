using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    /* Drag HUD into "RizzMeterScript" in the Inspector
    Change sprite to whatever art you have for the pickups */
    public RizzMeter RizzMeterScript;
    //OnTriggerEnter we add some rizz and then delete the gameobject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RizzMeterScript.PosUpdateRizz();
            GameObject.Destroy(this.gameObject);
        }  
    }
}
