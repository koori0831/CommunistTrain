using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Warning : MonoBehaviour
{
    Image panel;

    private void Awake()
    {
        panel = GetComponent<Image>();
    }
    public void WarningSign()
    {
        panel.DOColor(new Color (255,255,255,0), 0.2f).SetEase(Ease.InOutQuint).SetLoops(4,LoopType.Yoyo);
    }
}
