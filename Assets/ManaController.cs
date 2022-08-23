using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{

    [SerializeField] float manaAmount = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickUp()
    {
        GameManager.instance.IncreaseMana(manaAmount);
        Destroy(gameObject);
    }
}
