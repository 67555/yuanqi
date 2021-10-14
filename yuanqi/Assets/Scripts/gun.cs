using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    private float timeVal;

    public GameObject gunprefab;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (timeVal >= 0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }
    private void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(bulletPrefab, transform.position, gunprefab.transform.rotation);
            timeVal = 0;
        }
    }
}
