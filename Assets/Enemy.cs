using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // [SerializeField] float speed = 2;
    [SerializeField] float health = 100;

    // [SerializeField] float switchMovementSpeedTimer = 0.5f;
    // float switchMovementSpeedTimerCounter = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // switchMovementSpeedTimerCounter += Time.deltaTime;
        // if (switchMovementSpeedTimerCounter >= switchMovementSpeedTimer)
        // {
        //     speed = -speed;
        //     switchMovementSpeedTimerCounter = 0;
        // }
        // Move();

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // public void Move()
    // {
    //     transform.Translate(speed, 0, 0);
    // }
}
