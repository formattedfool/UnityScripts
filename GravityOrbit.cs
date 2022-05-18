using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float Gravity;
    public bool FixedDirection;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<GravityCtrl>())
        {
            //if this object has gravity script, set this as planet
            other.GetComponent<GravityCtrl>().Gravity = this.GetComponent<GravityOrbit>();
        }    
    }
}