using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject explosionBoom;
    public GameObject explosionRock;

    [SerializeField]
    private Value lives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Instantiate(explosionRock, collision.gameObject.transform.position, transform.rotation);
            Instantiate(explosionBoom, this.gameObject.transform.position, transform.rotation);

            lives.value--;
            Destroy(collision.gameObject);

            if (lives.value == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
