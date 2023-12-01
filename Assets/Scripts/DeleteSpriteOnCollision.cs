using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeleteSpriteOnCollision : MonoBehaviour
{
    public GameObject playerReference;
    public float radius = 1.5f;
    private HealthController healthController;
    private void Start()
    {
        playerReference = GameObject.Find("Player");
    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                healthController = playerReference.GetComponent<HealthController>();
                if (CompareTag("Ammo")) healthController.ammo += 10;
                Destroy(gameObject);
            }
        }
    }

}
