using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public static TowerController instance;
    public float speed = 0.5f;

    private float moveTimer = 0;
    [SerializeField] float moveDelay = 0.5f;

    private float start = 0;
    private Vector2 offset = new Vector2(0, 0);
    private Material material;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        offset.y = start + Time.time * speed;
        material.mainTextureOffset = new Vector2(0, offset.y);
    }
}


