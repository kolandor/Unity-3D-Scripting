using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveObject : MonoBehaviour
{
    private GameObject MovedObject;

    public Transform TargetPosition;

    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        MovedObject = base.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObjectToTarget();
    }

    void MoveObjectToTarget()
    {
        Vector3 positionFrom = MovedObject.transform.position;
        Vector3 positionTo = TargetPosition.position;
        float currentSpeed = Time.deltaTime * Speed;
        MovedObject.transform.position = Vector3.MoveTowards(
            positionFrom, positionTo, currentSpeed);
    }
}
