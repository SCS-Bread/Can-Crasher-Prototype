using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanCrasherSetting setting;

    [SerializeField] private InputManager inputManager;
    [SerializeField] private UIManager UIManager;

    private Countdown countdown;

    
    private void OnEnable()
    {
            
    }


}
