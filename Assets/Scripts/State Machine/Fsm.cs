using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Fsm
{
    public GameManager GameManager;
    private IState currentState;


    public Fsm(GameManager gameManager)
    {
        GameManager = gameManager;
    }



    public void UpdateState()
    {
        currentState?.Stay();
    }


    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
