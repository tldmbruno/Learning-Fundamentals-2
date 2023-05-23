using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
