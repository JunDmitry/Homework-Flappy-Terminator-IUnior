using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;

    protected CanvasGroup CanvasGroup => _canvasGroup;
    protected Button Button => _button;

    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(OnButtonClick);
    }

    public abstract void Open();

    public abstract void Close();

    protected abstract void OnButtonClick();
}