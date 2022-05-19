using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State<BlueWizardController>
{
    private Rigidbody2D mRigidBody;
    private Transform mTransform;
    private Animator mAnimator;
    private bool mFirstJump = true;

    public JumpingState(BlueWizardController mController, 
        FiniteStateMachine<BlueWizardController> mFSM) : base(mController, mFSM)
    {
        mRigidBody = mController.GetComponent<Rigidbody2D>();
        mTransform = mController.transform;
        mAnimator = mController.GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entrando al estado JUMPINGSTATE");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Saliendo del estado JUMPINGSTATE");
        mFirstJump = true;
    }

    public override void OnHandleInput()
    {
        base.OnHandleInput();
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
        if (mFirstJump)
        {
            mRigidBody.AddForce(Vector2.up * mController.jumpForce, ForceMode2D.Impulse);
            mFirstJump = false;
        }
        if (mRigidBody.velocity.y < 0)
        {
            // Esta cayendo
            mRigidBody.velocity += (mController.fallMultiplier - 1) *
                Time.fixedDeltaTime * Physics2D.gravity;
        }
        if (!IsOnAir() && mRigidBody.velocity.y == 0f)
        {
            mFSM.ChangeState(mController.IdleState);
        }
    }

    private bool IsOnAir()
    {
        Transform rayCastOrigin = mTransform.Find("RaycastPoint");
        RaycastHit2D hit = Physics2D.Raycast(
            rayCastOrigin.position,
            Vector2.down,
            mController.raycastDistance
        );
        Debug.Log(!hit);
        mAnimator.SetBool("IsJumping", !hit);

        /*Color rayColor;
        if (hit)
        {
            rayColor = Color.red;
        }else
        {
            rayColor = Color.blue;
        }
        Debug.DrawRay(rayCastOrigin.position, Vector2.down * raycastDistance, rayColor);*/

        return !hit;
        //return hit == null ? true : false;

    }
}
