using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates objects in a line, designed to generate dangerous blocks
/// </summary>
public class DangerBlocksGeneration : MonoBehaviour
{
    /// <summary>
    /// prefab object reference
    /// </summary>
    public GameObject DangerBlockPrefab;

    /// <summary>
    /// If the property is true objects are generated
    /// </summary>
    public bool Generate = true;

    /// <summary>
    /// Range within which objects can be generated
    /// </summary>
    public float GenerateDistanceByZ = 30;

    /// <summary>
    /// Probability (intensity) of generating objects
    /// </summary>
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
            //Generating an object if the generated number is lower or equal to the probability
            if (Random.Range(1, 100) <= GenerationIntensity)
            {
                float distanceX = transform.position.x;
                float distanceY = transform.position.y;
                float distanceZ = (float)(int)transform.position.z + Random.Range(0, GenerateDistanceByZ);

                //Dynamic object generation
                Instantiate(DangerBlockPrefab, new Vector3(distanceX, distanceY, distanceZ), Quaternion.identity);
            }
        }
    }
}
