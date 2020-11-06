using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// This script allows you to control 
/// the movement of an object associated with it
/// </summary>
public class MoveObject : MonoBehaviour
{
    /// <summary>
    /// Target position to which the object is moving
    /// </summary>
    public Transform TargetPosition;

    /// <summary>
    /// Automatic object movement
    /// </summary>
    public bool Move = false;

    /// <summary>
    /// Object movement by pressing the space bar
    /// </summary>
    public bool MoveByKeySpace = true;

    /// <summary>
    /// Object speed
    /// </summary>
    public float Speed = 1;

    /// <summary>
    /// Self-destruct upon reaching the target
    /// </summary>
    public bool SelfDeleteObjectByGoalTrget = false;

    /// <summary>
    /// Distance to the object upon reaching 
    /// which the object will self-destruct
    /// </summary>
    public float SelfDeleteDistanceFromTarget = 0.5f;

    /// <summary>
    /// Time after which the object will self-destruct
    /// </summary>
    public float SelfDeleteTimeByGoalTrget = 0f;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (TargetPosition != null)
        {
            //The condition is true if
            if (Move //The object moves automatically
                ^ (MoveByKeySpace //Or allowed movement by pressing the spacebar
                && Input.GetKey(KeyCode.Space)))//And the spacebar is pressed
            {//If movement is allowed and movement is allowed by pressing the spacebar, 
             //then the object moves until the spacebar is pressed according to the XOR condition

                //turn to the object face (along the Z axis)
                ExpandToTarget();

                if (MoveObjectToTarget() <= SelfDeleteDistanceFromTarget && SelfDeleteObjectByGoalTrget)
                {
                    Destroy(gameObject, SelfDeleteTimeByGoalTrget);
                    SceneManager.LoadScene("GoodGame");
                }
            }
        }
    }

    private void ExpandToTarget()
    {
        //turn to the object face (along the Z axis)
        transform.LookAt(TargetPosition);
    }

    private float MoveObjectToTarget()
    {
        //the position of the object to which the script is attached
        Vector3 positionFrom = transform.position;
        //target position
        Vector3 positionTo = TargetPosition.position;
        //calculation of object speed relative to frame rate
        float currentSpeed = Time.deltaTime * Speed;

        //Moving an object to a goal
        transform.position = Vector3.MoveTowards(
            positionFrom, positionTo, currentSpeed);

        //distance between object and target
        return Vector3.Distance(positionFrom, positionTo);
    }
}