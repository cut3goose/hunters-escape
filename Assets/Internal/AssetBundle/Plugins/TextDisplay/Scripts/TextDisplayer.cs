using System;
using TMPro;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    [SerializeField] protected string prefix;
    
    protected TextMeshProUGUI _textLabel;

    public virtual void DisplayText(string textToDisplay)
    {
        var displayedText = prefix + textToDisplay;
        _textLabel.text = displayedText;
    }
    
    #region Initialization

    protected virtual void Awake()
    {
        _textLabel = GetComponentInChildren<TextMeshProUGUI>();
        
        if (!_textLabel)
        {
            TryGetComponent(out _textLabel);
        }
    }

    #endregion
}
