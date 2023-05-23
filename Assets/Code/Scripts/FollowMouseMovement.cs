using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseMovement : MonoBehaviour
{
    [SerializeField] private float _followInterpolationSpeed = .2f;
    private Vector2 _lastClickPosition;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        _lastClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (_lastClickPosition == null) return;
        transform.position = Vector2.Lerp(transform.position, _lastClickPosition, _followInterpolationSpeed);
    }
}
