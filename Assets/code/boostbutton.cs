using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostbutton : MonoBehaviour


{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] AudioClip mainengine;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] float mainThrust = 100f;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    public void  Update()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainengine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
}
