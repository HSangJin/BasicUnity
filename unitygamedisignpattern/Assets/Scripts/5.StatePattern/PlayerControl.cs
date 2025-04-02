using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private StateMachine stateMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(new JumpState());
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stateMachine.ChangeState(new JumpState());
        }
        else if(!Input.anyKey)
        {
            stateMachine.ChangeState(new IdleState());
        }
    }
}
