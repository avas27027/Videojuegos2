
public class FiniteStateMachine<T>
{
    private State<T> mCurrentState;

    public State<T> GetCurrentState()
    {
        return mCurrentState;
    }

    public void Start(State<T> initialState)
    {
        mCurrentState = initialState;
        mCurrentState.OnEnter();
    }

    public void ChangeState(State<T> newState)
    {
        mCurrentState.OnExit();
        mCurrentState = newState;
        mCurrentState.OnEnter();
    }
}
