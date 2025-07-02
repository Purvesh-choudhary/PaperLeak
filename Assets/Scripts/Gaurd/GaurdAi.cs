using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GaurdAi : MonoBehaviour
{

    GaurdState currentState;

    public Transform[] patrolPoints;
    public Transform player;
    public float detectionRange = 5f;
    public NavMeshAgent agent;


    void Start()
    {
        SwitchState(new GaurdPatrolState(this));
    }

    void Update()
    {
        currentState?.Update();
    }

    public void SwitchState(GaurdState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Exit();
    }

    public bool CanSeePlayer()
    {
        // Simple range-based detection
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }
}
