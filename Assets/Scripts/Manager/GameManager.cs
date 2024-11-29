using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanCrasherSetting Setting;
    public InputManager InputManager;
    public UIManager UIManager;

    private Fsm gameFsm;
    private int score;


    private void OnEnable()
    {
        Setting.CreateCanItemDictionary();
        
    }


    private void Start()
    {
        gameFsm = new Fsm(this);
        gameFsm.ChangeState(new StartState(gameFsm));
    }


    private void Update()
    {
        gameFsm.UpdateState();        
    }


    
}
