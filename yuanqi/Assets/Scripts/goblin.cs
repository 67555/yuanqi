using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class goblin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject player;
    private GameObject enemygun;
    public AIPath p;
    public SpriteRenderer sr;
    public SpriteRenderer gunsr;

    private float timeVal = 4f;
    private float timeVal2 = 0;
    public Vector3 point;

    private int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        p.canSearch = false;
        sr = GetComponent<SpriteRenderer>();
        gunsr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((enemy.transform.position - player.transform.position).sqrMagnitude < 8)
        {
            if (timeVal2 > 1)
            {
                GameObject.Find("gun").SendMessage("attack");
            }
            else
            {
                timeVal2 += Time.deltaTime;
            }
        }
        else if ((enemy.transform.position - player.transform.position).sqrMagnitude < 20)
        {
            p.canSearch = true;
            GunDirection();
        }
        else
        {
            p.canSearch = false;
            if (timeVal > 1)
            {
                point = RandomPath();
                timeVal = 0;
                transform.Translate(point * speed * Time.deltaTime, Space.World);
                if (point.x < 0)
                {
                    sr.flipX = true;
                    gunsr.flipY = true;
                }
                else
                {
                    sr.flipX = false;
                    gunsr.flipY = false;
                }
            }
            else
            {
                timeVal += Time.deltaTime;
                transform.Translate(point * speed * Time.deltaTime, Space.World);
            }
        }

    }
    public Vector3 RandomPath()
    {
        var point = Random.insideUnitSphere;
        point.z = 0;
        point = point.normalized;
        return point;
    }
    private void GunDirection()
    {
        Vector3 direction = player.transform.position - enemygun.transform.position;
        direction.z = 0f;
        direction = direction.normalized;
        enemygun.transform.up = direction;
        enemygun.transform.right = direction;
    }
}