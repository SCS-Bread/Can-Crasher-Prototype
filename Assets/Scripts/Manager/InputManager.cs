
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameInput input;


    public bool Tap => input.CanCrasher.Tap.WasPerformedThisFrame();


    private void Awake()
    {
        input = new GameInput();
    }


    private void OnEnable()
    {
        input.Enable();
        input.CanCrasher.Enable();
    }



    private void OnDisable()
    {
        input.CanCrasher.Disable();
        input.Disable();
    }
}
