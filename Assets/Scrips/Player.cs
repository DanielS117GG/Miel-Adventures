using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

     void Start()
    {
        
            InputManager.Instance.OnTapEvent += Tap;
        
    }

    private void Tap(bool isTapped)
    {
        spriteRenderer.color = isTapped ? Color.red : Color.white;
    }


}
