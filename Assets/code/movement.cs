 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{   
    [SerializeField] float mainthrust = 1f;
    [SerializeField] float mainrotation = 1f;
    [SerializeField] AudioClip mainengine;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        processthurst();
        processrotation();
    }

    void processthurst()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*mainthrust*Time.deltaTime);
            applysound();
        }
        else
        {
            audioSource.Stop();
        }
    }
    void processrotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            applyrotation(mainrotation);
        }
        else if (Input.GetKey(KeyCode.D))
        
        {
            applyrotation(-mainrotation);
        }
    }

    private void applyrotation(float rotationthisframe)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationthisframe * Time.deltaTime);
        rb.freezeRotation = false; //resumeing the roation to take over by physics system
         
    }
    void applysound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainengine);
        }
    }
}
