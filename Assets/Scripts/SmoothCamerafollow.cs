using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamerafollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float damping;

    private Vector3 velo = Vector3.zero;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movePos = target.position + offset;
        //transform.position = Vector3.SmoothDamp(transform.position, movePos, ref velo, damping);
    }

    private void FixedUpdate()
    {
        Vector3 movePos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePos, ref velo, damping);
    
    }



}
