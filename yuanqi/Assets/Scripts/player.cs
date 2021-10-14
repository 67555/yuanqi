using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int moveSpeed = 3;

    private SpriteRenderer gunsr;
    private SpriteRenderer playersr;
    public GameObject playerprefab;
    public GameObject gunprefab;
    public GameObject bulletPrefab;

    Vector3 mousePositionInWorld;//鼠标的世界坐标

    // Start is called before the first frame update
    private void Awake()
    {
        playersr = GetComponent<SpriteRenderer>();
        gunsr = gunprefab.GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection();
        GunDirection();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
    }
    private void PlayerDirection()
    {
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (playerprefab.transform.position.x > mousePositionInWorld.x)
        {
            playersr.flipX = true;
            gunsr.flipY = true;
        }
        else
        {
            playersr.flipX = false;
            gunsr.flipY = false;

        }
    }
    private void GunDirection()
    {
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     
        Vector3 direction = mousePositionInWorld - gunprefab.transform.position;
        direction.z = 0f;
        direction = direction.normalized;
        gunprefab.transform.up = direction;
        gunprefab.transform.right = direction;
    }
}