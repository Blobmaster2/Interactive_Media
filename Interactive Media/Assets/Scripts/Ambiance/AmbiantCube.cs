using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantCube : MonoBehaviour
{
    public Vector3 r_rotate_interval;

    void Awake()
    {
        r_rotate_interval = new Vector3(Random.Range(0f, 0.005f), Random.Range(0f, 0.005f), Random.Range(0f, 0.005f));
    }

    void Update()
    {
        transform.Rotate(r_rotate_interval);
    }
}
