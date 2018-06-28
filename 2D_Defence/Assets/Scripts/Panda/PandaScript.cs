using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour {

    public float speed;
    public float health;
    
    private Animator animator;
    private int AnimDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int AnimHitTriggerHash = Animator.StringToHash("HitTrigger");
    private int AnimEatTriggerHash = Animator.StringToHash("EatTrigger");

    private Rigidbody2D rb2D;
    //private int currentWaypointNumber;
    private const float changeDist = 0.02f;
    private static GameManagerScript gameManager;
    private Waypoint currentWaypoint;

    // Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        if (gameManager == null) {
            gameManager = FindObjectOfType<GameManagerScript>();
        }
        currentWaypoint = gameManager.firstWaypoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentWaypoint == null)
        {
            animator.SetTrigger(AnimEatTriggerHash);
            Destroy(this);
            return;
        }
        float dist = Vector2.Distance(transform.position, currentWaypoint.Getposition());
        //Debug.Log("Dist : " + dist);
        if (dist <= changeDist)
        {
            Debug.Log("도착 : " + dist);
            currentWaypoint = currentWaypoint.GetNextWaypoint();
        }
        else
        {
            MoveTowards(currentWaypoint.Getposition());
        }
        /*
        if (currentWaypointNumber == gameManager.waypoints.Length)
        {
            animator.SetTrigger(AnimEatTriggerHash);
            Destroy(this);
            return;
        }
        float dist = Vector2.Distance(transform.position, gameManager.waypoints[currentWaypointNumber]);
        if(dist <= changeDist)
        {
            currentWaypointNumber++;
        }
        else
        {
            MoveTowards(gameManager.waypoints[currentWaypointNumber]);
        }
        */
    }
    private void MoveTowards(Vector3 destination)
    {
        // step 을 만든다음, 판단를 그 만큼 목표 지점으로 이동 시킨다.
        float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, destination, step);
        rb2D.MovePosition(Vector3.MoveTowards(transform.position, destination, step));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Projectile")
        {
            Hit(other.GetComponent<ProjectileScript>().damage);
        }
    }

    private void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            animator.SetTrigger(AnimDieTriggerHash);

        }
        else
        {
            animator.SetTrigger(AnimHitTriggerHash);
        }
    }
    private void Eat()
    {
        animator.SetTrigger(AnimEatTriggerHash);
    }
}
