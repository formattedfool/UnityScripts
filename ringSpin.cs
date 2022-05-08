using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ringSpin : MonoBehaviour
{
    public float xAngle = 0.00f,yAngle = 0.00f,zAngle = 0.00f, speed = 0.00f;
    
    public float TIME_ONE = 15F,TIME_TWO = 15F,TIME_STOP = 21F,timer = 0F;
    public string SceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   this.timer += Time.deltaTime;
        if (this.timer >= TIME_ONE)
        {
        transform.Rotate(xAngle,yAngle,zAngle * Time.deltaTime); 
        }
        this.timer += Time.deltaTime;
        if (this.timer >= TIME_TWO)
        {
        transform.Rotate(xAngle,yAngle,zAngle *speed * Time.deltaTime); 
        }
        
    }
}
