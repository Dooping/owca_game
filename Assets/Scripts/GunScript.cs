using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    GameObject spawnPoint;
    [SerializeField]
    GameObject projectile;
    public float minTimeBetweenShots = 1f;
    private double timeOfNextShot;
    // Start is called before the first frame update
    void Start()
    {
        timeOfNextShot = Time.timeAsDouble;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeAsDouble > timeOfNextShot)
        {
            Instantiate(projectile, spawnPoint.transform.position, transform.rotation);
            timeOfNextShot = Time.timeAsDouble + minTimeBetweenShots;
        }
    }
}
