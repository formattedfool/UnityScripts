using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    
    public Rigidbody rb;
    public float speed = 1000f, turnspeed = 0.1f;
    public int speedUp = 200;
    public int speedDown = -200;
    public int maxSpeed = 3000;
    public int minSpeed = 1000;
    public GameObject button;
    public Joystick JoyStick;
    Quaternion rotGoal;
  
    void Update() 
    {
        
        rb.velocity = new Vector3(JoyStick.Horizontal *speed * Time.deltaTime, JoyStick.Vertical * speed * Time.deltaTime);
        if (rb.velocity != Vector3.zero)
            {
            rotGoal = Quaternion.LookRotation(rb.velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnspeed);
            }
        
    }
    public void Boosting()
    {
        
        if(speed < maxSpeed)
        {
            speed += speedUp;
        }
        if(speed == maxSpeed)
        {
            //change button color 
        }
    }
    void MaxBoost()
    {
        
    }

    public void Slowing()
    {
        if(speed > minSpeed)
        {
            speed += speedDown;
        }
    }

    //create function to indicate max or min speed achieved 
    
   
}
