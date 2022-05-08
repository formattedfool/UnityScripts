using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 3f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
   
    AudioSource audioSource;
    MeshRenderer meshRenderer;
    
    
    
    bool isTransitioning = false;
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
         
        
    
    }
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning){ return; }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this thing is friendly");
                break;
            case "Fuel":
                Debug.Log("This adds fuel");
                break;
            case "Finish":
                LandedSafely();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

        


    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
            
        Invoke ("ReloadLevel", 1f);
    }

    
    void LandedSafely()
    {   
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        
        Invoke ("LoadNextLevel", 1f * levelLoadDelay);
    }
    void PortalRotate()
    {

    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
   
    
}
