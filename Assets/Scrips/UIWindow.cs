using DG.Tweening;
using UnityEngine;
using NaughtyAttributes;
public class UIWindow : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRecTransform;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private bool _hideOnStart;
    [Header("  Animation Settings ")]
    [SerializeField] private float showDuration = 0.5f; 
    [SerializeField] private float hideDuration = 0.5f;

    [SerializeField] private 
    void Start()
    {
        Initialize();
    }


    public virtual void Initialize()
    {
        if (_hideOnStart)
        {
            Show();
        }
    }
    public virtual void Show( bool instant = false)
    {
        if (instant)
        {
            _canvasRecTransform.gameObject.SetActive(true);
        }

        else
        {
            RectTransform rectTransform = _canvasGroup.GetComponent<RectTransform>();
            rectTransform.DOScale(Vector3.one, duration: 0.5f).SetEase(Ease.OutBack);
        }
    }

    public virtual void Hide( bool instant = false)
    {
        if (instant)
        {
            _canvasRecTransform.gameObject.SetActive(false);

        }

        else
        {
            RectTransform rectTransform = _canvasGroup.GetComponent<RectTransform>();
            rectTransform.DOScale(Vector3.zero, duration: 0.5f).SetEase(Ease.InBack);
        }
    }


    #region Test
    [Button]
    private void ShowTest()
    {
        Show();
    }

    [Button]

    private void HideTest()
    {
        Hide();
    }

    #endregion
}
