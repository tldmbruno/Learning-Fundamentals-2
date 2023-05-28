using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerMovement player)) return;
        player.AddComponent<ShooterBehavior>();
        Destroy(gameObject);
    }
}
