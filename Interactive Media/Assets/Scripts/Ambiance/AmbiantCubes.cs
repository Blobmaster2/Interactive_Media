using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantCubes : MonoBehaviour
{
    Transform cubeParent;
    public GameObject cubePrefab;

    Vector3 r_rotation;
    float r_scale;
    Vector3 r_position;

    void Start()
    {
        cubeParent = transform;

        for (int i = 0; i < Random.Range(100, 200); i++)
        {
            var cube = Instantiate(cubePrefab);

            cube.transform.SetParent(cubeParent);

            r_position = new Vector3(Random.Range(-1500, 1500), Random.Range(400, 700), Random.Range(-1500, 1500));
            r_rotation = Random.rotation.eulerAngles;
            r_scale = Random.Range(10, 150);

            cube.transform.SetPositionAndRotation(r_position, Quaternion.Euler(r_rotation));
            cube.transform.localScale = new Vector3(r_scale, r_scale, r_scale);
        }
    }
}
