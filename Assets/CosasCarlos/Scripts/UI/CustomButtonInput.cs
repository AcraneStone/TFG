using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomButtonInput : CustomUIComponent
{
    public ThemeSO theme;
    public EnumStyle style;
    public UnityEvent<string> onClick;

    private Button button;
    private TextMeshProUGUI buttonText;

    public override void Setup()
    {
        button = GetComponentInChildren<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void Configure()
    {
        if (button != null)
        {
            ColorBlock cb = button.colors;
            cb.normalColor = theme.GetBackgroundColor(style);
            button.colors = cb;

            buttonText.color = theme.GetTextColor(style);
        }

    }

    public void OnClick(string text)
    {
        onClick.Invoke(text);
    }
}