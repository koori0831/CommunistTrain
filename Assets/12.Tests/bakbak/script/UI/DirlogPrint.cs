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
    /// 다음내용을 출력가능한지 확인
    /// </summary>
    private void printText()
    {
        if (indexer < _dialLogSO.DialLog.Count)
        {
            printDuration = StartCoroutine(PrintDuration(_dialLogSO.DialLog[indexer]));
        }
    }

    /// <summary>
    /// 공백 두개를 줄바꿈으로 변환
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
    /// 현재 내용을 스킵/출력완료시 다음내용/ 외부 호출시 이거 사용
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
    /// 다음 내용을 출력
    /// </summary>
    public void NextText()
    {
        if (printDuration != null) return;

        printText();

        OnEndPrintText?.Invoke();
    }

    /// <summary>
    /// 출력효과, 
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
