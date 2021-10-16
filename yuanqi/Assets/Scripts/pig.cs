using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class pig : MonoBehaviour
{
    public GameObject enemy;
    public AIPath p;
    public GameObject player;
    public float timeVal = 4f;
    public SpriteRenderer sr;
    public Vector3 point;

    private int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        p.canSearch = false;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if((enemy.transform.position - player.transform.position).sqrMagnitude < 20)
        {
            p.canSearch = true;
        }
        else
        {
            p.canSearch = false;
            if (timeVal > 1)
            {
                point = RandomPath();
                timeVal = 0;
                transform.Translate(point * speed * Time.deltaTime, Space.World);
                if(point.x<0)
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
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
        var point= Random.insideUnitSphere;
        point.z = 0;
        point = point.normalized;
        return point;
    }
}
