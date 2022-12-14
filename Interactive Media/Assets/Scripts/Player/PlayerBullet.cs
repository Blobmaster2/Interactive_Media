using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Player>()._score += 100;
        }

        if (collision.gameObject.layer == 0)
        {
            Destroy(gameObject);
        }
    }
}
