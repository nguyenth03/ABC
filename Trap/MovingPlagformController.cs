using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlagformController : MonoBehaviour
{
    //drag to MovingPlatform
    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2f;

    void Update()
    {

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        BossRation();
    }

    void BossRation()
    {
        if (gameObject.transform.position.x <= waypoints[0].transform.position.x)
        {
            Debug.Log("1");
            transform.localScale = transform.localScale;
        }

        if (gameObject.transform.position.x >= waypoints[1].transform.position.x)
        {
            Debug.Log("2");
            transform.localScale = -transform.localScale;

        }
    }
}
