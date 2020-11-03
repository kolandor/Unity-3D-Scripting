using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public bool Move = true;

    private Transform _targetPosition;

    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.childCount == 0)
        {
            throw new System.Exception("No target child in DangerBlock!");
        }
        _targetPosition = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPosition != null)
        {
            MoveObjectToTarget();
        }
    }

    float MoveObjectToTarget()
    {
        Vector3 positionFrom = transform.position;
        Vector3 positionTo = _targetPosition.position;
        float currentSpeed = Time.deltaTime * Speed;
        transform.position = Vector3.MoveTowards(
            positionFrom, positionTo, currentSpeed);

        return Vector3.Distance(positionFrom, positionTo);
    }
}
