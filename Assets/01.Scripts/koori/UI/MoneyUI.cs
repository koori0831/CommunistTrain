using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoneyUI : MonoBehaviour
{
    private TMP_Text m_Text;
    private int m_UiValue = 0;
    private bool m_MinusPlag = false;

    private Coroutine m_CurrentCoroutine;

    private float baseDelay = 0.01f; // 기본 지연 시간

    private void Start()
    {
        m_Text = GetComponentInChildren<TMP_Text>();
        m_Text.text = m_UiValue.ToString();

        StartCoroutine(Counting());
    }

    private void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            ChangeMoney(50);
        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            ChangeMoney(-50);
        }
    }

    public void ChangeMoney(int Value)
    {
        if (m_CurrentCoroutine != null)
            StopCoroutine(m_CurrentCoroutine);

        DataManager.Instance.Money += Value;

        if (Value < 0)
            m_MinusPlag = true;
        else if (Value == 0) return;
        else
            m_MinusPlag = false;

        m_CurrentCoroutine = StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        int difference = Mathf.Abs(m_UiValue - DataManager.Instance.Money);
        float delay = Mathf.Clamp(baseDelay / difference, 0.0005f, baseDelay); // 최소 0.005초, 최대 baseDelay

        if (!m_MinusPlag)
        {
            WaitForSeconds delayTime = new WaitForSeconds(delay);
            while (m_UiValue < DataManager.Instance.Money)
            {
                m_UiValue++;
                m_Text.text = m_UiValue.ToString();

                yield return delayTime;
            }
        }
        else
        {
            WaitForSeconds delayTime = new WaitForSeconds(delay);
            while (m_UiValue > DataManager.Instance.Money)
            {
                m_UiValue--;
                m_Text.text = m_UiValue.ToString();

                yield return delayTime;
            }
        }

        m_CurrentCoroutine = null;

        yield return null;
    }
}