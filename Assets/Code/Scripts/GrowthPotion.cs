using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.localScale *= 2;
        Destroy(gameObject);
    }
}
