using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRingX : MonoBehaviour
{
    public float propellorSpeed = 10;
    public float ringSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, propellorSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, ringSpeed * Time.deltaTime);
    }
}
