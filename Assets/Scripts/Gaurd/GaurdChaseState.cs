public class GaurdChaseState : GaurdState
{
    public GaurdChaseState(GaurdAi gaurd) : base(gaurd) { }

    public override void Enter()
    {
        gaurd.agent.isStopped = false;
        gaurd.agent.speed = gaurd.chaseSpeed;
    }

    public override void Update()
    {
        gaurd.agent.SetDestination(gaurd.player.position);

        if (!gaurd.CanSeePlayer())
        {
            gaurd.SwitchState(new GaurdSearchState(gaurd));
        }
    }
}
