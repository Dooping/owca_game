using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    public float minSpeed = 120;
    public float maxSpeed = 140;
    private Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(Vector2.left * Random.Range(minSpeed, maxSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
