using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject victoryMenu;
    public GameObject explosionBoom;
    public GameObject explosionRock;
    public GameObject explosionLove;
    public GameObject explosionUnicorn;
    public GameObject explosionFire;

    public AudioSource owcaDying;
    public AudioSource explosion;
    public AudioSource collect;
    public AudioSource unicornDying;
    public AudioSource burn;

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
            explosion.Play();
            
            HitPlayer();
        } 
        else if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionUnicorn, collision.gameObject.transform.position, transform.rotation);
            unicornDying.Play();

            HitPlayer();
        }
        else if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionFire, collision.gameObject.transform.position, transform.rotation);
            burn.Play();

            HitPlayer();
        }
        else if (collision.tag == "Point")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionLove, collision.gameObject.transform.position, transform.rotation);
            collect.Play();

            points.value += lovePerHeart;
        }
    }

    void HitPlayer()
    {
        Instantiate(explosionBoom, this.gameObject.transform.position, transform.rotation);
        owcaDying.Play();

        lives.value--;

        if (lives.value == 0)
        {
            Destroy(this.gameObject);
            victoryMenu.SetActive(true);
        }
    }

}
