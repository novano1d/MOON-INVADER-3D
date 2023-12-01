using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5);
    }
}
