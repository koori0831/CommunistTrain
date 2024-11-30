using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class RemainTimeUI : MonoBehaviour
{
    [SerializeField] private GameObject timeIcon;
    private RectTransform _rectTransform;
    private HorizontalLayoutGroup _horizontalLayoutGroup;
    List<GameObject> icons = new List<GameObject>();

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _horizontalLayoutGroup = GetComponentInChildren<HorizontalLayoutGroup>();

        TimeManager.Instance.OnSpendTime += IconDelate;
        TimeManager.Instance.OnTimeAllUesd += UIexit;
    }

    private void UIexit()
    {
        _rectTransform.DOLocalMoveX(-1460f, 1f).SetEase(Ease.OutElastic);
    }

    private void Update()
    {
        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            TimeManager.Instance.SpendTime();
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        TimeManager.Instance.RestTime();
        _rectTransform.DOLocalMoveX(-900f, 1f).SetEase(Ease.OutElastic);
        IconCreate(TimeManager.Instance.Times);
    }

    private void IconDelate()
    {
        Destroy(icons[icons.Count-1]);
    }
    private void IconCreate(int times)
    {
        int amount = times - _horizontalLayoutGroup.transform.childCount;
        for (int i = 1; i <= amount; i++)
        {
            GameObject icon = Instantiate(timeIcon, _horizontalLayoutGroup.transform);
            icon.name = timeIcon.name;
        }
        for (int i = 0; i < _horizontalLayoutGroup.transform.childCount; i++)
        {
            icons.Add(_horizontalLayoutGroup.transform.GetChild(i).gameObject);
        }
    }
}
