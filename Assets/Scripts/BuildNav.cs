using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEditor.AI;
public class BuildNav : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NavMeshBuilder.ClearAllNavMeshes();
        NavMeshBuilder.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
