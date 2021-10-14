using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float movespeed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * movespeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "tank":
                {
                    collision.SendMessage("Die");
                }
                break;
            case "enemy":

                break;
            case "box":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "map":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
