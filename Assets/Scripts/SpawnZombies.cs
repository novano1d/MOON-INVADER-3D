using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    GameObject sp1, sp2, sp3;
    public GameObject Zombie;
    // Start is called before the first frame update
    void Start()
    {
        sp1 = GameObject.Find("SpawnPt1");
        sp2 = GameObject.Find("SpawnPt2");
        sp3 = GameObject.Find("SpawnPt3");
        for (int i = 0; i < 3; i++)
        {
            GameObject z = GameObject.Instantiate(Zombie);
            float r = Random.Range(0, 3);
            if (r == 0) z.transform.position = sp1.transform.position;
            if (r == 1) z.transform.position = sp2.transform.position;
            if (r == 2
                ) z.transform.position = sp3.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] getCount = GameObject.FindGameObjectsWithTag("Zombie");
        int count = getCount.Length;
        if ( count == 0 )
        {
            HealthController hc = GameObject.Find("Player").GetComponent<HealthController>();
            hc.wave += 1;
            for (int i = 0; i < 2 * Mathf.Pow(hc.wave, 2); i++)
            {
                GameObject z = GameObject.Instantiate(Zombie);
                float r = Random.Range(0, 3);
                if (r == 0) z.transform.position = sp1.transform.position;
                if (r == 1) z.transform.position = sp2.transform.position;
                if (r == 2
                    ) z.transform.position = sp3.transform.position;
            }
        }
    }
}
