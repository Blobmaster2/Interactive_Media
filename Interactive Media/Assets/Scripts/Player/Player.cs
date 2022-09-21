using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float _health;
    public float score;
    public float _shootDelay;

    public bool _isDead = false;
    [HideInInspector]
    public bool _canShoot;

    void Update()
    {
        if (_health <= 0)
        {
            _isDead = true;
        }

        if (_isDead)
        {

        }
    }

    public IEnumerator waitForShoot()
    {
        yield return new WaitForSeconds(_shootDelay);

        _canShoot = true;
    }

}
