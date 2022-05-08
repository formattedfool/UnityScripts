 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotSpeed = 100f;
    [SerializeField] float revThrust = 100f;
    [SerializeField] AudioClip engine;
    [SerializeField] float SoundDelay = 1f;
    [SerializeField] ParticleSystem jetParticles;
    [SerializeField] ParticleSystem jetParticlesL;
    [SerializeField] ParticleSystem jetParticlesR;
    [SerializeField] ParticleSystem jetParticlesF;
 
    Rigidbody rbody;
    AudioSource audiosource;
    public Joystick joystick;

    bool isAlive;

    void Start()
    {
       rbody = GetComponent<Rigidbody>();
       audiosource = GetComponent<AudioSource>();

    }

    void Update()
    {
       
       ProcessThrust();
       ProcessRotation();
       ProcessRevThrust();
    }


    
    void ProcessThrust()
    {
        if (joystick.Vertical >= .2f)
        {   
            rbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!audiosource.isPlaying)
                {
                audiosource.PlayOneShot(engine);
                }
            
                if (Input.GetKey(KeyCode.RightShift))
                    {
                    rbody.AddRelativeForce(Vector3.up * thrust * 2 * Time.deltaTime);
                    
                    }
                    
            if(!jetParticles.isPlaying)
            {
                jetParticles.Play();
            }
        }
        else 
        {
            audiosource.Stop();
            jetParticles.Stop();
        }
    }

    void ProcessRevThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rbody.AddRelativeForce(Vector3.down * revThrust * 10 * Time.deltaTime);
            if(!jetParticlesF.isPlaying)
            {
                jetParticlesF.Play();
            }
            
        }
        else
            {
                jetParticlesF.Stop();
            }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotSpeed);
            if(!jetParticlesR.isPlaying)
            {
                jetParticlesR.Play();
            }
            
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
                ApplyRotation(-rotSpeed);
                if(!jetParticlesL.isPlaying)
                {
                    jetParticlesL.Play();
                }
            }    
            else
            {
                jetParticlesR.Stop();
                jetParticlesL.Stop();
            }
        
    
    }

    

    public void ApplyRotation(float rotationThisFrame)
    {
        rbody.freezeRotation = true; // freezing rotation for manual use
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rbody.freezeRotation = false; // physics system to take over
    }
}
