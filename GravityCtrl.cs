using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    //attach to all rigidbodies to orbit world

    public GravityOrbit Gravity;
    public Rigidbody rb;


    public float RotationSpeed = 20;


    void NotinUse() 
    {
    
    }
    public void Attract(Transform playerTransform)
    {
        //Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        //Vector3 localUp = playerTransform.up;

        //playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
        //Quaternion targetRot = Quaternion.FromToRotation(localUp,gravityUp) * transform.rotation;
        //playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation,targetRot, 50f * Time.deltaTime);


    }

    private void FixedUpdate()
    {
        if(Gravity)
        {
            Vector3 gravityUp = Vector3.zero;

            gravityUp = (transform.position - Gravity.transform.position).normalized;
            
            
            Vector3 localUp = transform.up;

            Quaternion targetRot = Quaternion.FromToRotation(localUp,gravityUp) * transform.rotation;

            transform.rotation = Quaternion.Lerp(transform.rotation,targetRot, RotationSpeed * Time.deltaTime);

            //push down for gravity
            rb.AddForce((-gravityUp * Gravity.Gravity) * rb.mass);
        }
    }
}
