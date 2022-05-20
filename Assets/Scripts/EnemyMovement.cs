using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speedX = 150;
    public float speedY = 1;
    private Rigidbody2D body;

    [SerializeField]
    private Value difficulty;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(Vector2.left * speedX);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && difficulty.value >= 25)
        {
            float step = speedY * Time.deltaTime;
            Vector3 newYPos = transform.position - player.transform.position;

            // move sprite towards the target location
            if (newYPos.y > 0.05)
                transform.position += Vector3.down * speedY * Time.deltaTime;
            else if (newYPos.y < -0.05)
                transform.position += Vector3.up * speedY * Time.deltaTime;

        }
    }
}
