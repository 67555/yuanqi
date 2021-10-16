using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void attack()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
