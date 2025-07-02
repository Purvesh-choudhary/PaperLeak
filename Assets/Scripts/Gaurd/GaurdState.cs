public abstract class GaurdState
{

    protected GaurdAi gaurd;

    public GaurdState(GaurdAi gaurd)
    {
        this.gaurd = gaurd;
    }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
    }
    

}
