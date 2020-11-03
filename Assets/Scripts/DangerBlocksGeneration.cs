using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBlocksGeneration : MonoBehaviour
{
    public GameObject DangerBlockPrefab;

    public bool Generate = true;

    public float GenerateDistanceByZ = 30;

    public int GenerationIntensity = 50;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (DangerBlockPrefab == null)
        {
            throw new System.Exception("DangerBlockPrefab link not found!");
        }

        if (Generate)
        {
            if (Random.Range(1, 100) <= GenerationIntensity)
            {
                float distanceX = transform.position.x;
                float distanceY = transform.position.y;
                float distanceZ = (float)(int)transform.position.z + Random.Range(0, GenerateDistanceByZ);

                Instantiate(DangerBlockPrefab, new Vector3(distanceX, distanceY, distanceZ), Quaternion.identity);
            }
        }
    }
}
