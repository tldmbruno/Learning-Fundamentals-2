using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehavior : MonoBehaviour
{
    [SerializeField] private Color _fire = Color.red;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.TryGetComponent(out SpriteRenderer sprite)) return;
        sprite.color = _fire;
    }
}
