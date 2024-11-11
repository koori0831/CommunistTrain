using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class DayData
{
    public int Month;
    public int Day;
    public Week DayOfWeek;

    public DayData(int month, int day, Week dayOfWeek)
    {
        Month = month;
        Day = day;
        DayOfWeek = dayOfWeek;
    }
}
public class CalenderManager : MonoBehaviour 
{
    [SerializeField] private TMP_Text _month, _day;

    void Awake()
    {
        LoadCalendarData();
        DataManager.Instance.DayData = DataManager.Instance.calendarData[0];

        _month.text = DataManager.Instance.DayData.Month.ToString();
        _day.text = DataManager.Instance.DayData.Day.ToString();
    }

    private void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            DayChange();
        }
    }

    private void DayChange()
    {
        DataManager.Instance.DayData = GetNextDay(DataManager.Instance.DayData);

        _month.text = DataManager.Instance.DayData.Month.ToString();
        _day.text = DataManager.Instance.DayData.Day.ToString();
    }

    private void LoadCalendarData()
    {
        string[] lines = Resources.Load<TextAsset>("Data/1971").text.Split('\n');

        for (int i = 1; i < lines.Length; i++) // ��� ��ŵ
        {
            string[] data = lines[i].Split(',');
            if (data.Length == 3)
            {
                try
                {
                    int month = int.Parse(data[0]);
                    int day = int.Parse(data[1]);
                    int dayOfWeekInt = int.Parse(data[2]); // CSV���� ���ڷ� ����
                    Week dayOfWeek = (Week)(dayOfWeekInt - 1); // Week enum���� ��ȯ
                    DataManager.Instance.calendarData.Add(new DayData(month, day, dayOfWeek));
                }
                catch (FormatException)
                {
                    Debug.LogError($"CSV ������ �Ľ� ����: {lines[i]}");
                }
            }
        }
    }
    public DayData GetNextDay(DayData currentDayData)
    {
        if (currentDayData == null)
        {
            return null; // �Ǵ� ���� ó��
        }

        int currentIndex = DataManager.Instance.calendarData.IndexOf(currentDayData);
        if (currentIndex == -1)
        {
            return null; // ���� ��¥ �����Ͱ� ����Ʈ�� ���� ���
        }

        int nextIndex = (currentIndex + 1) % DataManager.Instance.calendarData.Count;
        return DataManager.Instance.calendarData[nextIndex];
    }
}
