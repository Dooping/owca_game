using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHealth : MonoBehaviour
{
    public int lives = 3;
    private SoundController soundController;
    public GameObject animationAvocado;
    public GameObject animationObstacle;

    private void Start()
    {
        GameObject sounds = GameObject.Find("Sounds");
        soundController = sounds.GetComponent<SoundController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Instantiate(animationAvocado, collision.gameObject.transform.position, transform.rotation);
            Instantiate(animationObstacle, gameObject.transform.position, transform.rotation);
            
            soundController.PlayAvocado();

            lives--;
            Destroy(collision.gameObject);
            if (lives <= 0)
            {
                if (gameObject.tag == "Enemy")
                {
                    soundController.PlayUnicornDying();
                } else
                {
                    soundController.PlayExplosion();
                }
                Destroy(gameObject);
            }

        } 
    }
}
