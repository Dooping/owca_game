using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject victoryMenu;
    public GameObject heartSpawner;
    public GameObject explosionBoom;
    public GameObject explosionRock;
    public GameObject explosionLove;
    public GameObject explosionUnicorn;
    public GameObject explosionFire;

    public GameObject sounds;
    private SoundController soundController;

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
        soundController = sounds.GetComponent<SoundController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionRock, collision.gameObject.transform.position, transform.rotation);
            soundController.PlayExplosion();
            
            HitPlayer();
        } 
        else if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionUnicorn, collision.gameObject.transform.position, transform.rotation);
            soundController.PlayUnicornDying();

            HitPlayer();
        }
        else if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionFire, collision.gameObject.transform.position, transform.rotation);
            soundController.PlayBurn();

            HitPlayer();
        }
        else if (collision.tag == "Point")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionLove, collision.gameObject.transform.position, transform.rotation);
            soundController.PlayCollect();

            points.value += lovePerHeart;
        }
    }

    void HitPlayer()
    {
        Instantiate(explosionBoom, this.gameObject.transform.position, transform.rotation);
        soundController.PlayOwcaDying();

        lives.value--;

        if (lives.value == 0)
        {
            Destroy(this.gameObject);
            victoryMenu.SetActive(true);
            heartSpawner.SetActive(true);
            soundController.PlayHappyBirthday();
        }
    }

}
