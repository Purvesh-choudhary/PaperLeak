using UnityEngine;

public class GaurdPatrolState : GaurdState
{
    int currentWaypoint = 0;
    public GaurdPatrolState(GaurdAi gaurd) : base(gaurd) { }

    public override void Enter()
    {
        gaurd.agent.isStopped = false;
        gaurd.agent.speed = gaurd.patrolSpeed;
        gaurd.agent.SetDestination(gaurd.patrolPoints[currentWaypoint].position);
    }

    public override void Update()
    {
        if (gaurd.CanSeePlayer())
        {
            gaurd.SwitchState(new GaurdChaseState(gaurd));
            return;
        }

        // Move to next waypoint if reached
        if (!gaurd.agent.pathPending && gaurd.agent.remainingDistance < 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % gaurd.patrolPoints.Length;
            gaurd.agent.SetDestination(gaurd.patrolPoints[currentWaypoint].position);
        }
    }


}
