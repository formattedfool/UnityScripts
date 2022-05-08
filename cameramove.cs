using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameramove : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 10f;
    public float TIME_LIMIT = 15F;
    public float TIME_STOP = 21F;
    public float TIME_Scene = 25F;
    public float timer = 0F;
    public string SceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= TIME_LIMIT)
         {
             rb.AddRelativeForce(Vector3.down * thrust * Time.deltaTime);
         }

        if (this.timer >= TIME_STOP)
        {
            rb.velocity = Vector3.zero;
        }
        if (this.timer >= TIME_Scene)
        {
            SceneManager.LoadScene(SceneLoad);
        }
    }
}
