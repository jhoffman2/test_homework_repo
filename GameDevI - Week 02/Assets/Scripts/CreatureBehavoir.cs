using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureBehavoir : MonoBehaviour
{
    #region Variables

    [Header ("References")]
    public NavMeshAgent agent;
    public Transform destination;

    [Header("Hunger Values")]

    [Range (0, 100)]
    public float currentSatiation;
    public float hungerRate;
    public float feedRate;
    public float normalMoveSpeed = 3.5f;
    public float hungryMoveSpeed = 7;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSatiation < 50)
        {
            agent.SetDestination(destination.position);
        }

        SetAgentSpeed();

        if (Vector3.Distance(destination.position, transform.position) < 1)
        {
            if (currentSatiation < 100)
            {
                currentSatiation += Time.deltaTime * feedRate;
            }
        }
        else
        {
            if (currentSatiation > 0)
            {
                currentSatiation -= Time.deltaTime * hungerRate;
            }
        } 

    }

    void SetAgentSpeed()
    {
        if (currentSatiation < 20)
        {
            agent.speed = hungryMoveSpeed;
        }
        else
        {
            agent.speed = normalMoveSpeed;
        }
    }

}
