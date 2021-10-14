using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Astar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    private object path;
    private int currentWaypoint;
    private bool reachedEndOfPath;
    private float nextWaypointDistance;
    private int speed = 3;
    private Vector3 nextTargetPosition;

    public void Start()
    {
        //获取到A*Pathfinding提供的路径计算接口所在的脚本。
        Seeker seeker = GetComponent<Seeker>();
        seeker.StartPath(enemyPrefab.transform.position, playerPrefab.transform.position, OnPathComplete);
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    //public void UpdatePath(Vector2 targetPosition)
    //{
    //    Seeker.StartPath(enemyPrefab.transform.position, targetPosition, OnPathComplete);
    //}
    //public void NextTarget()
    //{
    //    if (path == null) { return; }
    //    reachedEndOfPath = false;//标记是否已经到达目标点
    //    float distanceToWaypoint;
    //    while (true)
    //    {
    //        distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
    //        if (distanceToWaypoint < nextWaypointDistance)
    //        {
    //            if (currentWaypoint + 1 < path.vectorPath.Count) { currentWaypoint++; }
    //            else { reachedEndOfPath = true; break; }
    //        }
    //        else { break; }
    //    }
    //    var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
    //    if (!reachedEndOfPath)
    //    {
    //        nextTargetPosition = path.vectorPath[currentWaypoint];
    //        Vector3 dir = (nextTargetPosition - transform.position).normalized;
    //        Vector3 velocity = dir * speed * speedFactor;
    //        transform.position += velocity * Time.deltaTime;
    //    }
    //    else { path = null; }
    //}

}
