using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LoadingWindow : MonoBehaviour, ILoadingWindow
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeInDuration;
    [SerializeField] private float _fadeOutDuration;

    public void Load(Action loaded)
    {
        StartCoroutine(Loading(loaded));
    }

    private IEnumerator Loading(Action loaded)
    {
        /*Just for visual demonstration, very bad algorithm I know.
         * One of the best implementation in this case would be the Tween events */

        FadeIn();
        yield return new WaitForSeconds(_fadeInDuration);
        FadeOut();
        yield return new WaitForSeconds(_fadeOutDuration);
        loaded?.Invoke();
    }

    private void FadeIn()
    {
        _canvasGroup.DOFade(1, _fadeInDuration);
    }

    private void FadeOut()
    {
        _canvasGroup.DOFade(0, _fadeOutDuration);
    }

}
