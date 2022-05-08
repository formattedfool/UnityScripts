using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHere : MonoBehaviour
{
     public List<GameObject> pullObjects;
     public Vector3 pullDirection;
     public float pullSpeed = 10f;
     void Start () 
     {
         pullObjects = new List<GameObject> ();
     }
 
     void Update () {
         foreach (GameObject obj in pullObjects) 
         {
             obj.transform.Translate (Time.deltaTime * pullSpeed *3 * pullDirection, Space.World);
         }
     }
      public void OnTriggerEnter(Collider col)
     {
         if(col.tag == "Player")
         {
         Debug.Log ("object entered");
         pullObjects.Add (col.gameObject);
         }
     }
 
 
     public void OnTriggerExit(Collider col)
     {
         pullObjects.Remove (col.gameObject);
     }
}
