using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target { Player, PlayerOrigin, Enemy, Freeroam };

public class MovingObject : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] Target target;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (target == Target.Player)
        {
            MoveTowardsPlayer();
        }
        else if (target == Target.PlayerOrigin)
        {
            MoveTowardsPlayerOrigin();
        }
        else if (target == Target.Enemy)
        {
            MoveTowardsEnemy();
        }
        else if (target == Target.Freeroam)
        {
            MoveTowardsFreeroam();
        }

    }

    public void MoveTowardsPlayer()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 direction = playerPos - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void MoveTowardsPlayerOrigin()
    {
        // GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        transform.Translate(player.transform.position * speed * Time.deltaTime);
    }

    public void MoveTowardsEnemy()
    {
        Vector3 enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
        Vector3 direction = enemyPos - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void MoveTowardsFreeroam()
    {
        transform.Translate(0, speed, 0);
    }
}
