using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Value lives;

    [SerializeField]
    private Value points;
    // Start is called before the first frame update
    void Start()
    {
        lives.value = 5;
        points.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            lives.value--;
            Destroy(collision.gameObject);

            if (lives.value == 0)
            {
                Destroy(this.gameObject);
            }
        } else if (collision.tag == "Point")
        {
            Destroy(collision.gameObject);
            points.value += 100;
        }
    }

}
