using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] float _lifeTime = 2f;

    private void Start()
    {
        StartCoroutine(StartDestroyCooldown());
    }

    private IEnumerator StartDestroyCooldown()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
