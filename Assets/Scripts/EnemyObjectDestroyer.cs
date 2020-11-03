using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectDestroyer : MonoBehaviour
{
    public GameObject TargetObject;

    public bool TargetDestroyObjectByGoalTrget = true;

    public bool SelfDestroyObjectByGoalTrget = false;

    public float DestroyDistanceFromTarget = 0.5f;

    public float DestroyTimeByGoalTrget = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
