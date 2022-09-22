using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertRadius : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>()._seesPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>()._seesPlayer = false;
        }
    }
}
