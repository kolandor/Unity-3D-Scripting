using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the logic of destruction of the enemy object
/// </summary>
public class EnemyObjectDestroyer : MonoBehaviour
{
    /// <summary>
    /// The name of the target object, the object on the scene 
    /// with this designation is tracked by the object to which 
    /// this script is attached
    /// </summary>
    public string TargetObjectName;

    /// <summary>
    /// Target reference
    /// </summary>
    private GameObject _targetObject;

    /// <summary>
    /// Whether to destroy the target on collision
    /// </summary>
    public bool TargetDestroyObjectByGoalTrget = true;

    /// <summary>
    /// Whether to destroy the script media object when the target is reached
    /// </summary>
    public bool SelfDestroyObjectByGoalTrget = false;

    /// <summary>
    /// The length of the radius at entry which the target will be destroyed
    /// </summary>
    public float DestroyDistanceFromTarget = 0.5f;

    /// <summary>
    /// The time after which the target and the object and the script media 
    /// object will be destroyed after a collision
    /// </summary>
    public float DestroyTimeByGoalTrget = 0f;
    // Start is called before the first frame update

    /// <summary>
    /// Go to the game over screen
    /// </summary>
    public bool GoToGameOverByGoalTrget = true;
    void Start()
    {
        if (!string.IsNullOrEmpty(TargetObjectName))
        {
            //Find and save a reference to a target
            _targetObject = GameObject.Find(TargetObjectName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checking the radius for a target object
        if (_targetObject != null
            && Vector3.Distance(transform.position, _targetObject.transform.position) <= DestroyDistanceFromTarget)
        {
            if (TargetDestroyObjectByGoalTrget)
            {
                Destroy(_targetObject, DestroyTimeByGoalTrget);
            }

            if (SelfDestroyObjectByGoalTrget)
            {
                Destroy(gameObject, DestroyTimeByGoalTrget);
            }

            if (GoToGameOverByGoalTrget)
            {
                Invoke("GameOver", DestroyTimeByGoalTrget);
            }
        }
    }

    void GameOver()
    {
        //Go to the game over screen
        SceneManager.LoadScene("GameOver");
    }
}
