using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField]  float delay =1f;
    [SerializeField] AudioClip crashsound;
    [SerializeField] AudioClip nextlevelsound;

    AudioSource audioSource;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
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
                break;
            
        }
    }
    void crashsequence()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(crashsound);
        }
        GetComponent<movement>().enabled=false;
        Invoke("Reloadlevel",delay);
    }
    void nextlevelsequence()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(nextlevelsound);
        } 
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
