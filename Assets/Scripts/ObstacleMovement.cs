using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public int minRange;
    public int maxRange;
    public float speed = 150;

    private Rigidbody2D body;
    private float degreesPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        degreesPerSecond = Random.Range(minRange, maxRange);
        body.AddForce(Vector2.left * speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond * Time.deltaTime));
    }
}
