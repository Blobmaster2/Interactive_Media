using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _health;
    public float _maxHealth;
    [Space]
    [SerializeField] MeshRenderer _alertRadius;
    public bool _showAlertRadius;



    private void Start()
    {
        
    }

    private void Update()
    {
        _alertRadius.enabled = _showAlertRadius;
    }
}
