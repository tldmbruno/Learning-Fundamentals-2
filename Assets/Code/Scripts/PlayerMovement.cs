using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 40f;
    [SerializeField] private float _dashForce = 20f;
    [SerializeField] private float _friction = 0.1f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        if (_rigidbody) return;
        if (!TryGetComponent(out Rigidbody2D rigidbody)) return;

        _rigidbody = rigidbody;
        _rigidbody.gravityScale = 0;
    }

    void Update()
    {
        if (!_rigidbody) return;
        MovementControl();
    }

    void FixedUpdate()
    {
        if (!_rigidbody) return;
        ComputeFriction();
    }

    void MovementControl()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.velocity += input.normalized * _moveSpeed * Time.deltaTime;

        DashControl(input);
    }

    void DashControl(Vector2 movement)
    {
        const float MINIMUM_SQUARED_MAGNITUDE_TO_DASH = .005f;
        if (_rigidbody.velocity.sqrMagnitude < MINIMUM_SQUARED_MAGNITUDE_TO_DASH) return;

        if (!Input.GetKeyDown(KeyCode.Space)) return;

        _rigidbody.velocity += movement * _dashForce;
    }

    void ComputeFriction()
    {
        if (_rigidbody.velocity.sqrMagnitude == 0) return;
        _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, _friction);
    }
}