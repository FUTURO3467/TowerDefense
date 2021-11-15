
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointindex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {

        if(waypointindex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else {
            waypointindex++;
            target = Waypoints.points[waypointindex];
        }
    }
}
