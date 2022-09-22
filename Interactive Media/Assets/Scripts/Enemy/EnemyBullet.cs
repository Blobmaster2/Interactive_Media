using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 0)
        {
            Destroy(gameObject);
        }
    }
}
