using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    public float _health = 3;
    public float _score;
    public float _shootDelay;

    [SerializeField] Text _scoreText;
    [SerializeField] Text _healthText;
    [SerializeField] Text _controlsText;
    [SerializeField] Image _crosshairs;
    [SerializeField] VideoPlayer _youdied;

    public bool _isDead = false;
    [HideInInspector]
    public bool _canShoot = true;

    void Update()
    {
        if (_health <= 0)
        {
            _isDead = true;
        }

        if (_isDead)
        {
            StartCoroutine(PlayYouDied());
        }

        _scoreText.text = "Score: " + _score;
        _healthText.text = "Health: " + _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(_shootDelay);

        _canShoot = true;
    }

    IEnumerator PlayYouDied()
    {
        _crosshairs.enabled = false;
        _scoreText.enabled = false;
        _healthText.enabled = false;
        _controlsText.enabled = false;

        _youdied.Play();

        yield return new WaitForSeconds(7);

        Debug.Log("quit");
        Application.Quit();
    }
}
