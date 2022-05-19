using UnityEngine;

public class RunningState : State<BlueWizardController>
{
    private float mMovement;
    private Rigidbody2D mRigidBody;

    public RunningState(BlueWizardController mController, 
        FiniteStateMachine<BlueWizardController> mFSM) : base(mController, mFSM)
    {
        mRigidBody = mController.GetComponent<Rigidbody2D>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entrando al estado RUNNINGSTATE");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Saliendo del estado RUNNINGSTATE");
    }

    public override void OnHandleInput()
    {
        base.OnHandleInput();
        mMovement = Input.GetAxis("Horizontal");
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        if (mMovement == 0f)
        {
            mFSM.ChangeState(mController.IdleState);
        }
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
        Move();
    }

    private void Move()
    {
        float targetSpeed = mMovement * mController.moveSpeed;
        float speedDif = targetSpeed - mRigidBody.velocity.x;
        float accelRate = Mathf.Abs(
            targetSpeed) > 0.01f ? mController.accel : mController.deccel;
        float movement = Mathf.Pow(
            accelRate * Mathf.Abs(speedDif),
            mController.speedExp
        ) * Mathf.Sign(speedDif);

        mRigidBody.AddForce(movement * Vector2.right);
    }
}
