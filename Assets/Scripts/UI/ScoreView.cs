using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _format;

    private void OnEnable()
    {
        _scoreCounter.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.Changed -= OnChanged;
    }

    private void OnChanged(float score)
    {
        _text.text = string.Format(_format, score);
    }
}