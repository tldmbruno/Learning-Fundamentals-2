using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPotion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.localScale *= 2;
        Destroy(gameObject);
    }
}
