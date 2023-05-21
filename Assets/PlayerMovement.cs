using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKeyDown) return;

        Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
        if (!rigidbodyComponent) return;

        rigidbodyComponent.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }
}
