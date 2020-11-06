using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moving block object control
/// </summary>
public class MoveBlock : MonoBehaviour
{
    /// <summary>
    /// Should the object move
    /// </summary>
    public bool Move = true;

    /// <summary>
    /// Position of the target to the cortex the object is moving
    /// </summary>
    private Transform _targetPosition;

    /// <summary>
    /// Object movement speed
    /// </summary>
    public float Speed = 1;

    /// <summary>
    /// Self-destruction of an object
    /// </summary>
    public bool SelfDestroyByTime = true;

    /// <summary>
    /// Time after which the object will self-destruct
    /// </summary>
    public int SelfDestroyTime = 20;

    // Start is called before the first frame update
    void Start()
    {
        //checking for the presence of a child point (object) to which the object should move
        if (transform.childCount == 0)
        {
            throw new System.Exception("No target child in DangerBlock!");
        }

        //If there is a child object, then we save its position
        _targetPosition = transform.GetChild(0).transform;

        //self-destruct launch
        if (SelfDestroyByTime)
        {
            Destroy(gameObject, SelfDestroyTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPosition != null && Move)
        {//If there is a goal, we move the object towards it
            MoveObjectToTarget();
        }
    }

    float MoveObjectToTarget()
    {
        //the position of the object to which the script is attached
        Vector3 positionFrom = transform.position;
        //target position
        Vector3 positionTo = _targetPosition.position;
        //calculation of object speed relative to frame rate
        float currentSpeed = Time.deltaTime * Speed;

        //Moving an object to a goal
        transform.position = Vector3.MoveTowards(
            positionFrom, positionTo, currentSpeed);

        //distance between object and target
        return Vector3.Distance(positionFrom, positionTo);
    }
}
