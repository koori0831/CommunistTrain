using TMPro;
using UnityEngine;
using System;
using System.Collections;

public class DirlogPrint : MonoBehaviour
{
    public event Action OnEndPrintText;
    [SerializeField]
    private ChatSO _dialLogSO;

    [SerializeField]
    private TextMeshProUGUI _textBox;
    [SerializeField]
    private TextMeshProUGUI _nameTag;

    int indexer = 0;

    [SerializeField]
    private float duration;

    private Coroutine printDuration;

    private void Start()
    {
        printText();
    }
    /// <summary>
    /// ���������� ��°������� Ȯ��
    /// </summary>
    private void printText()
    {
        if (indexer < _dialLogSO.DialLog.Count)
        {
            printDuration = StartCoroutine(PrintDuration(_dialLogSO.DialLog[indexer]));
        }
    }

    /// <summary>
    /// ���� �ΰ��� �ٹٲ����� ��ȯ
    /// </summary>
    /// <param name="printingText"></param>
    /// <returns></returns>
    private string SetString(string printingText)
    {
        if (printingText.Contains("  "))
        {
            printingText = printingText.Replace("  ", "\n");
        }
        return printingText;
    }

    /// <summary>
    /// ���� ������ ��ŵ/��¿Ϸ�� ��������/ �ܺ� ȣ��� �̰� ���
    /// </summary>
    public void PrintNextTextImmediately()
    {
        if (printDuration != null)
        {
            StopCoroutine(printDuration);
            printDuration = null;
            _textBox.text = SetString(_dialLogSO.DialLog[indexer]);
            indexer++;
        }
        else
        {
            printText();
        }

        OnEndPrintText?.Invoke();
    }


    /// <summary>
    /// ���� ������ ���
    /// </summary>
    public void NextText()
    {
        if (printDuration != null) return;

        printText();

        OnEndPrintText?.Invoke();
    }

    /// <summary>
    /// ���ȿ��, 
    /// </summary>
    /// <param name="rawText"></param>
    /// <returns></returns>
    private IEnumerator PrintDuration(string rawText)
    {
        _textBox.text = null;
        _nameTag.text = null;
        _nameTag.text = _dialLogSO.NameTag[indexer];
        string printingText = SetString(rawText);
        for (int i = 0; i < printingText.Length; i++)
        {
            yield return new WaitForSeconds(duration);
            _textBox.text += printingText[i];
        }
        printDuration = null;
        indexer++;
    }
}
