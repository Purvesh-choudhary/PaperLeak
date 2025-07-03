using UnityEngine;

public class GaurdSearchState : GaurdState
{
    float searchTime = 3f;
    float timer = 0f;
    
    public GaurdSearchState(GaurdAi gaurd) : base(gaurd) { }
  
    public override void Enter()
    {
        searchTime = gaurd.searchTime;
        gaurd.agent.isStopped = true;
        timer = 0f;
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= searchTime)
        {
            gaurd.SwitchState(new GaurdPatrolState(gaurd));
        }
    }

}
