using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

    [SerializeField] Image fadeImage;
    [SerializeField] GameObject fadeContainer;
    [SerializeField] float fadeDuration;

    private bool isActive;
    void Start()
    {
        gameObject.SetActive(false);
        isActive = true;
        fadeImage.color = new Color(fadeImage.color.r,fadeImage.color.g,fadeImage.color.b,0);
    }
    public void FadeIn()
    {
        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.Append(fadeImage.DOFade(0, fadeDuration)).
            AppendCallback(() => {fadeContainer.SetActive(true); });
        fadeInSequence.Play();
    }
    public void FadeYoyo()
    {
        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.Append(fadeImage.DOFade(1, fadeDuration)).
            AppendCallback(() => { fadeContainer.SetActive(true); }).
            Append(fadeImage.DOFade(0,fadeDuration));
        fadeInSequence.Play();
    }
    public void FadeOutYoyo()
    {

        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.Append(fadeImage.DOFade(1, fadeDuration)).
            AppendCallback(() => { fadeContainer.SetActive(false); }).
            Append(fadeImage.DOFade(0, fadeDuration));
        fadeInSequence.Play();
    }
}
