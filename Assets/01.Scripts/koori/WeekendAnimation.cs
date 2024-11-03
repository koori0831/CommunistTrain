using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Week
{
    Sun,
    Mon,
    Tue,
    Wed,
    Thu,
    Fri,
    Sat
}
public class WeekendAnimation : MonoBehaviour
{
    private Week _nowWeek;
    [SerializeField] private TMP_Text _text1, _text2;
    private Vector3 _nowWeekPos, _nextWeekPos, _upPos;
    [SerializeField] private float _moveDuratiuon = 1f;

    private void Start()
    {
        WeekSystemInit();
        _text1.text = _nowWeek.ToString();
    }

    private void WeekSystemInit()
    {
        _nowWeek = DataManager.Instance.DayData.DayOfWeek;
        _nowWeekPos = _text1.rectTransform.position;
        _nextWeekPos = _text2.rectTransform.position;
        _upPos = new Vector2(_nowWeekPos.x, _nowWeekPos.y + Mathf.Abs(_nowWeekPos.y - _nextWeekPos.y));
    }

    public void ChangeWeek(Week yesterDay)
    {
        _nowWeek = GetNext(yesterDay);

        if (_text1.rectTransform.position == _nextWeekPos)
        {
            Sequence _changeWeekMove = DOTween.Sequence();
            _text1.text = _nowWeek.ToString();
            _changeWeekMove.Append(_text2.rectTransform.DOMove(_upPos, _moveDuratiuon).SetEase(Ease.InOutElastic))
            .Join(_text1.rectTransform.DOMove(_nowWeekPos, _moveDuratiuon).SetEase(Ease.InOutElastic))
            .OnComplete(() => { _text2.rectTransform.position = _nextWeekPos; });
        }
        else
        {
            Sequence _changeWeekMove = DOTween.Sequence();
            _text2.text = _nowWeek.ToString();
            _changeWeekMove.Append(_text1.rectTransform.DOMove(_upPos, _moveDuratiuon).SetEase(Ease.InOutElastic))
            .Join(_text2.rectTransform.DOMove(_nowWeekPos, _moveDuratiuon).SetEase(Ease.InOutElastic))
            .OnComplete(() => { _text1.rectTransform.position = _nextWeekPos; });
        }
        Debug.Log($"어제 요일은 {yesterDay}였고, 오늘은 {_nowWeek}입니다.");
    }

    public static T GetNext<T>(T enumValue) where T : Enum
    {
        Array array = System.Enum.GetValues(typeof(T));
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (enumValue.Equals(array.GetValue(i)))
                return (T)array.GetValue(i + 1);
        }
        return (T)array.GetValue(0);
    }

    private void Update()
    {
        if(Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            ChangeWeek(_nowWeek);
        }
    }
}
