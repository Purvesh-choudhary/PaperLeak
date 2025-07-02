using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GaurdAi : MonoBehaviour
{

    GaurdState currentGaurdState;

    public Transform[] patrolPoints;
    public Transform player;
    public float detectionRange = 5f;
    public NavMeshAgent agent;


    void Start()
    {
        SwitchState(GaurdPatrolState(this));
    }

    void Update()
    {
        currentGaurdState?.Update();
    }

    void SwitchState(GaurdState newState)
    {
        currentGaurdState?.Exit();
        currentGaurdState = newState;
        currentGaurdState?.Exit();
    }

    public bool CanSeePlayer()
    {
        // Simple range-based detection
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }
}
