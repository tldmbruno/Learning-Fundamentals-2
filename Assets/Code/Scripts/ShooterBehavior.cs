using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    [SerializeField] private float _forceMagnitude = 800f;
    [SerializeField] private float _secondsBetweenShots = .2f;

    private Camera _mainCamera;
    private GameObject _projectile;
    private bool _isAbleToShoot = true;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _projectile = Resources.Load<GameObject>("Projectiles/FireProjectile");
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

        _isAbleToShoot = false;
        StartCoroutine(StartShotCooldown());
    }

    private IEnumerator StartShotCooldown()
    {
        yield return new WaitForSeconds(_secondsBetweenShots);
        _isAbleToShoot = true;
    }

}
