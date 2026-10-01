using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
  public static InputManager Instance { get; private set; }

    #region Tap
    public event Action<bool> OnTapEvent;
    private bool _isTouching = false;

    #endregion

    public void OnTap(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _isTouching = true;
            OnTapEvent?.Invoke( true) ;
            Debug.Log("Touch Started");


        }

        else if ( context.canceled)
        {

            _isTouching = true;
            OnTapEvent?.Invoke(false);
            Debug.Log("Touch Started");
        }


    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


}
