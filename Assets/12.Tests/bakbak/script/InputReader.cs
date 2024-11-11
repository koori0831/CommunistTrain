using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action OnInteraction;
    public event Action OnClick;

    private InputSystem_Actions _inputReader;

    private void OnEnable()
    {
        if(_inputReader == null)
        {
            _inputReader = new InputSystem_Actions();
            _inputReader.Player.SetCallbacks(this);
        }
        _inputReader.Player.Enable();
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.Player.Disable();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnMoveRequest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnClick?.Invoke();
        }
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }

    /// <summary>
    /// 인터렉션
    /// </summary>
    /// <param name="context"></param>
    public void OnTryToInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInteraction?.Invoke();
        }
    }
}
