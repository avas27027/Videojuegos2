
public abstract class State<T>
{
    protected T mController;
    protected FiniteStateMachine<T> mFSM;

    public State(T mController, FiniteStateMachine<T> mFSM)
    {
        this.mController = mController;
        this.mFSM = mFSM;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnHandleInput() { }
    public virtual void OnLogicUpdate() { }
    public virtual void OnPhysicsUpdate() { }
}
