using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject explosionBoom;
    public GameObject explosionRock;

    public AudioSource owcaDying;
    public AudioSource explosion;
    public AudioSource collect;

    public int lovePerHeart = 1000;

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
            Destroy(collision.gameObject);
            Instantiate(explosionRock, collision.gameObject.transform.position, transform.rotation);
            Instantiate(explosionBoom, this.gameObject.transform.position, transform.rotation);
            owcaDying.Play();
            explosion.Play();

            lives.value--;

            if (lives.value == 0)
            {
                Destroy(this.gameObject);
            }
        } 
        else if (collision.tag == "Point")
        {
            Destroy(collision.gameObject);
            collect.Play();

            points.value += lovePerHeart;
        }
    }

}
