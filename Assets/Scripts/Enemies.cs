
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int moneyReward = 50;

    public GameObject deathEffect;

    private MoneyUI moneyui;

    private Transform target;
    private int waypointindex = 0;

    private void Start()
    {
        moneyui = MoneyUI.instance;
        target = Waypoints.points[0];
    }

    public void TakeDammage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {

        PlayerStats.money += moneyReward;
        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 7.5f);

        Destroy(gameObject);
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
            endPath();
            return;
        }
        else {
            waypointindex++;
            target = Waypoints.points[waypointindex];
        }
    }

    private void endPath()
    {
        Destroy(gameObject);
        PlayerStats.lives--;
    }

}
