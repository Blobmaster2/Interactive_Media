using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool _seesPlayer;
    public bool _inShootRange;

    public float _shootDelay;
    bool _canShoot = true;

    [SerializeField] float _minRandomTurnTime;
    [SerializeField] float _maxRandomTurnTime;
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] float _walkSpeed;
    [SerializeField] float _bulletSpeed;


    Transform _player;
    Rigidbody _rb;

    bool _randomTurnFlag = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (!_inShootRange)
        {
            if (_seesPlayer)
            {
                MoveTowardsPlayer();
            }
            else
            {
                MoveRandom();
            }
        }
        else
        {
            transform.LookAt(_player);
            _rb.velocity = Vector3.zero;
            if (_canShoot) Shoot();
        }
    }

    void MoveRandom()
    {
        if (_randomTurnFlag) StartCoroutine(WaitForTurn());
        _rb.velocity = transform.forward * _walkSpeed;
    }

    void MoveTowardsPlayer()
    {
        transform.LookAt(_player);
        _rb.velocity = transform.forward * _walkSpeed;
    }

    void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        bullet.transform.forward = transform.forward;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(bullet.transform.forward.x, bullet.transform.forward.y, bullet.transform.forward.z) * _bulletSpeed;

        Destroy(bullet, 5);

        _canShoot = false;
        StartCoroutine(WaitForShoot());
    }

    IEnumerator WaitForTurn()
    {
        _randomTurnFlag = false;

        transform.rotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);

        yield return new WaitForSeconds(Random.Range(_minRandomTurnTime, _maxRandomTurnTime));

        _randomTurnFlag = true;
    }

    public IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(_shootDelay);

        _canShoot = true;
    }
}
