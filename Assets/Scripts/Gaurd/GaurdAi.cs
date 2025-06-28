using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GaurdAi : MonoBehaviour
{

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float chaseSpeed = 5f;
    [SerializeField] float distanceToReachBeforeChangingPoint = 2f;

    [SerializeField] Transform[] patrolPoints;
    [SerializeField] Transform currentPointToGo;

    [SerializeField] bool isPatrolling;

    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPointToGo = patrolPoints[0];
        agent.SetDestination(currentPointToGo.position);
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, currentPointToGo.position) < distanceToReachBeforeChangingPoint)
        {
            currentPointToGo = patrolPoints[Random.Range(0, patrolPoints.Length)];
            agent.SetDestination(currentPointToGo.position);
        }
    }

    void Chase()
    {

    }

}
