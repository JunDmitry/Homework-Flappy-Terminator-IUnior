using System;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    public override void Open()
    {
        CanvasGroup.interactable = true;
        CanvasGroup.alpha = 1f;
    }

    public override void Close()
    {
        CanvasGroup.interactable = false;
        CanvasGroup.alpha = 0f;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}