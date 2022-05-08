using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportfour : MonoBehaviour
{
   [SerializeField] float xAngle = 0.0f;
   [SerializeField] float yAngle = 0.0f;
   [SerializeField] float zAngle = 0.0f;

   

     void OnTriggerEnter(Collider other) 
    {
    
       if (other.tag == "Player")
       {
       other.transform.position = new Vector3(xAngle,yAngle,zAngle);
       }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
