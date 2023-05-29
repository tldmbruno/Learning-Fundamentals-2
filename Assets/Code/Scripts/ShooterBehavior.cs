using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    [SerializeField] private float _forceMagnitude = 900f;
    [SerializeField] private float _secondsBetweenShots = .05f;

    private Camera _mainCamera;
    private GameObject _projectile;
    private AudioSource _audioSource;
    private AudioClip _shootSound;
    private bool _isAbleToShoot = true;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _projectile = Resources.Load<GameObject>("Projectiles/FireProjectile");
        _audioSource = gameObject.AddComponent<AudioSource>();
        _shootSound = Resources.Load<AudioClip>("SFX/vineboom");
    }

    private void Update()
    {
        if (!gameObject.TryGetComponent(out PlayerMovement player)) return;
        if (GUIUtility.hotControl != 0) return;
        if (!Input.GetMouseButton(0) || !_isAbleToShoot) return;

        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        direction.Normalize();

        Rigidbody2D projectileBody = Instantiate(_projectile.GetComponent<Rigidbody2D>(), player.transform);
        projectileBody.transform.position += (Vector3)direction;
        projectileBody.AddForce(direction * _forceMagnitude);

        _audioSource.PlayOneShot(_shootSound);

        _isAbleToShoot = false;
        StartCoroutine(StartShotCooldown());
    }

    private IEnumerator StartShotCooldown()
    {
        yield return new WaitForSeconds(_secondsBetweenShots);
        _isAbleToShoot = true;
    }

}
