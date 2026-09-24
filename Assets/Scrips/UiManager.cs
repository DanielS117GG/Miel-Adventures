using NUnit.Framework;
using UnityEngine;

public class UiManager : MonoBehaviour
{
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
}
