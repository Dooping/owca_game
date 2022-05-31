using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 10f;
    private float vertical;
    private float horizontal;
    private DeviceType deviceType;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        deviceType = SystemInfo.deviceType;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (deviceType == DeviceType.Handheld)
        {
            vertical = Input.acceleration.x;
            horizontal = Input.acceleration.y;
        } else
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
