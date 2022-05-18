using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHealth : MonoBehaviour
{
    public int lives = 3;
    public AudioSource audioSourceAvocado;
    public AudioSource audioSourceObstacle;
    //public GameObject animationAvocado;
    public GameObject animationObstacle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            //Instantiate(animationAvocado, collision.gameObject.transform.position, transform.rotation);
            Instantiate(animationObstacle, gameObject.transform.position, transform.rotation);
            
            audioSourceAvocado.Play();
            audioSourceObstacle.Play();

            lives--;
            Destroy(collision.gameObject);
            if (lives <= 0)
            {
                Destroy(gameObject);
            }

        } 
    }
}
