using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField]  float delay =1f;
    [SerializeField] AudioClip crashsound;
    [SerializeField] AudioClip nextlevelsound;
    [SerializeField] ParticleSystem nextlevelpraticles;
    [SerializeField] ParticleSystem crashpraticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {   
        if (isTransitioning){return;}
        switch (other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("you hit friendly thingh");
                break;
            case "Finish":
                nextlevelsequence();
                break;
            default:
                crashsequence();
                crashpraticles.Play();
                break;
            
        }
    }
    void crashsequence()
    {   
        crashpraticles.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashsound);
        GetComponent<movement>().enabled=false;
        Invoke("Reloadlevel",delay);
    }
    void nextlevelsequence()
    {   
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(nextlevelsound);
        nextlevelpraticles.Play();
        GetComponent<movement>().enabled=false;
        Invoke("loadnextlevel",delay);
    }
    void loadnextlevel()
    {
        int currentscenceindex = SceneManager.GetActiveScene().buildIndex;
        int nextscenceindex = currentscenceindex+1;
        if (nextscenceindex == SceneManager.sceneCountInBuildSettings)
        {
            nextscenceindex=0;
        }
        SceneManager.LoadScene(nextscenceindex);
    }
    void Reloadlevel()
    {   
        int currentscenceindex =SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscenceindex);
    }
}
