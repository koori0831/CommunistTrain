using UnityEngine;
using DG.Tweening;

public class RemainTimeUI : MonoBehaviour
{
    [SerializeField] private GameObject timeIcon;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        rectTransform.DOLocalMoveX(-900f, 1f).SetEase(Ease.OutElastic);
    }


}
