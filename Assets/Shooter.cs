using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletInterval = 3f;
    [SerializeField] float bulletDamage = 10f;
    [SerializeField] float bulletLifeTime = 2f;
    [SerializeField] float bulletSize = 0.5f;
    [SerializeField] float bulletSpeedVariance = 0.5f;
    [SerializeField] float timeBetweenShots = 3f;
    [SerializeField] float timeBetweenShotsCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenShotsCounter += Time.deltaTime;
        if (timeBetweenShotsCounter >= timeBetweenShots)
        {
            timeBetweenShotsCounter = 0;
            Shoot();
        }


    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
        Destroy(newBullet, bulletLifeTime);
    }
}
