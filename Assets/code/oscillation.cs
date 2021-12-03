using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillation : MonoBehaviour
{   
    Vector3 startingpossion;
    [SerializeField] Vector3 movementpossion;
    [SerializeField] [Range(0,1)] float movementfactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingpossion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if(period <=Mathf.Epsilon){return;}
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawsinwave =  Mathf.Sin(cycles*tau);

        movementfactor = ((rawsinwave+1f)/2f);
        Vector3 offset =movementpossion * movementfactor;
        transform.position=offset + startingpossion;
    }
}
