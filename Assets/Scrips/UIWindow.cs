using DG.Tweening;
using UnityEngine;
using NaughtyAttributes;
using System;
public class UIWindow : MonoBehaviour


{
    [Header("Data")]
    [SerializeField] private string _id;

    [Header("UI Settings ")]
    
    [SerializeField] private RectTransform _canvasRecTransform;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private bool _hideOnStart;

    [Header("  Animation Settings ")]
    [SerializeField] private float showDuration = 0.5f; 
    [SerializeField] private float hideDuration = 0.5f;

    [SerializeField] private Ease showEase = Ease.OutBack;
    [SerializeField] private Ease hideEase = Ease.InBack;

    public CanvasGroup CanvasGroup => _canvasGroup;

    public RectTransform CanvasRectTransform => _canvasRecTransform;

    public string Id =>_id;

    //[SerializeField] private 
    void Start()
    {
        Initialize();
    }
    public virtual void Initialize()
    {
        if (_hideOnStart)
        {
            Hide(instant: true);
        }
    }
    public virtual void Show(bool instant = false)
    {
        if (instant)
        {
            _canvasRecTransform.gameObject.SetActive(true);
        }

        else
        {
            _canvasRecTransform.gameObject.SetActive(true);
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
            rectTransform.DOScale(Vector3.zero, hideDuration).SetEase(hideEase).OnComplete(() =>
            {
                _canvasRecTransform.gameObject.SetActive(false);
                RectTransform rectTransform = _canvasGroup.GetComponent<RectTransform>();
                rectTransform.DOScale(Vector3.one, duration: 0.5f).SetEase(Ease.OutBack);
            });
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
