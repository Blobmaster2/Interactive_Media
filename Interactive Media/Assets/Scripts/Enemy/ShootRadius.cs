using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRadius : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>()._inShootRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>()._inShootRange = false;
        }
    }
}
