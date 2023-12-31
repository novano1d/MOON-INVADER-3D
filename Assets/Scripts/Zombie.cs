using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private const float RANGE = 0.2f;
    public GameObject rayStartPt;
    public int health = 100;
    public GameObject player;
    public NavMeshAgent Agent;
    private bool ready = true;
    public float attackCoolDown = 0.3f;

    private void Start()
    {
        Agent.enabled = false;
        player = GameObject.Find("Player");
    }

    void resetAttack()
    {
        ready = true;
    }

    private void attack()
    {
        Vector3 orig = rayStartPt.transform.position;
        RaycastHit hit;
        if (ready && Physics.Raycast(orig, rayStartPt.transform.forward, out hit, RANGE))
        {
            if (hit.transform.CompareTag("Player"))
            {
                hit.transform.GetComponent<HealthController>().health -= 10;
                ready = false;
                Invoke(nameof(resetAttack), attackCoolDown);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > .1f) // let navmesh generate
        {
            Agent.enabled = true;
        }

        attack();
        if (Agent.enabled)
        {
            Agent.SetDestination(player.transform.position);
        }
    }
}
