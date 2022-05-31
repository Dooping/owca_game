using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUpMovement : MonoBehaviour
{
    public float speed = 500f;
    private Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(Vector2.up * speed);

        Destroy(gameObject, 4f);
    }
}
