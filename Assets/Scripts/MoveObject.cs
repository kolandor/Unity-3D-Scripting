using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveObject : MonoBehaviour
{
    public Transform TargetPosition;

    public float Speed = 1;

    public bool SelfDeleteObjectByGoalTrget = false;

    public float SelfDeleteDistanceFromTarget = 0.5f;

    public float SelfDeleteTimeByGoalTrget = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ExpandToTarget();

        if (MoveObjectToTarget() <= SelfDeleteDistanceFromTarget && SelfDeleteObjectByGoalTrget)
        {
            Destroy(gameObject, SelfDeleteTimeByGoalTrget);
        }
    }

    void ExpandToTarget()
    {
        transform.LookAt(TargetPosition);
    }

    float MoveObjectToTarget()
    {
        Vector3 positionFrom = transform.position;
        Vector3 positionTo = TargetPosition.position;
        float currentSpeed = Time.deltaTime * Speed;
        transform.position = Vector3.MoveTowards(
            positionFrom, positionTo, currentSpeed);

        return Vector3.Distance(positionFrom, positionTo);
    }
}