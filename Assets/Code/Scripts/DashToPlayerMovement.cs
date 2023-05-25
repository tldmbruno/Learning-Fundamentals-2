using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _detectRadius = 4f;
    [SerializeField] private float _dashSpeed = 5f;

    private CircleCollider2D _triggerArea;
    private Vector2 _targetLocation;
    private bool _hasFoundPlayer;
    
    private void OnEnable()
    {
        _triggerArea = gameObject.AddComponent<CircleCollider2D>();
        _triggerArea.radius = _detectRadius;
        _triggerArea.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out PlayerMovement playerMovement)) return;
        _hasFoundPlayer = true;
        _targetLocation = playerMovement.transform.position;
    }

    private void FixedUpdate()
    {
        if (_targetLocation == null || !_hasFoundPlayer) return;
        if ((Vector2) transform.position == _targetLocation)
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, _targetLocation, _dashSpeed * Time.deltaTime);
    }

}
