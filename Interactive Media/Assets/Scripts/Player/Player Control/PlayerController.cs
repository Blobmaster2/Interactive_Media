using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveDirection = Vector2.zero;

    Rigidbody rb;
    public float speed = 5f;
    public PlayerInput playerControls;

    public GameObject playerBullet;
    public Transform bulletSpawn;
    public float bulletSpeed;

    InputAction move;
    InputAction fire;
    InputAction escape;

    Player _player;

    void Start()
    {
        _player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        playerControls = new PlayerInput();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
        escape = playerControls.Player.Escape;
        escape.Enable();
        escape.performed += Escape;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        escape.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = 
            new Vector3(transform.forward.x * moveDirection.y * speed, 0, transform.forward.z * moveDirection.y * speed) + 
            new Vector3(transform.right.x * moveDirection.x * speed, 0, transform.right.z * moveDirection.x * speed);

        if (transform.forward != Camera.main.transform.forward) transform.forward = Camera.main.transform.forward;

    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (_player._canShoot)
        {
            _player._canShoot = false;

            var bullet = Instantiate(playerBullet, bulletSpawn.position, Quaternion.Euler(transform.rotation.eulerAngles.x - 105, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));

            var bulletDirection = transform.forward.normalized;

            bullet.GetComponent<Rigidbody>().velocity = new Vector3(bulletDirection.x, bulletDirection.y + 0.04f, bulletDirection.z) * bulletSpeed;

            Destroy(bullet, 5);

            StartCoroutine(_player.waitForShoot());
        }
    }

    private void Escape(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

}
