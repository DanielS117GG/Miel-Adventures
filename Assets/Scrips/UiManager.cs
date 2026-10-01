using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class UiManager : MonoBehaviour
{

    public static UiManager Instance { get; private set; }
    [SerializeField] private List<UIWindow> _uiWindows;

   void Start()
    {
        
    }

    public void ShowWindow(string windowName)
    {
        foreach (var window in _uiWindows)
        {
            if (window.Id == windowName)
            {
                Debug.Log($"Showing window : {windowName}");
                window.Show();
                break;
            }
            Debug.LogError("Window not found : " + windowName);
        }
    }

    public void HideWindow(string windowName)
    {

    }


    private void Awake()
    {
        if( Instance != null && Instance != this )
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    } 

}
