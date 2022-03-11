using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport : MonoBehaviour, IViewport
{
    [SerializeField] private PlayWindow _playWindow;
    [SerializeField] private FinishWindow _finishWindow;
    [SerializeField] private LoadingWindow _loadingWindow;

    public IPlayWindow GetPlayWindow() => _playWindow;
    public IFinishWindow GetFinishWindow() => _finishWindow;
    public ILoadingWindow GetLoadingWindow() => _loadingWindow;
}
