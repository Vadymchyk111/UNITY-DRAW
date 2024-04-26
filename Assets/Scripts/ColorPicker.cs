using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public event Action<Color32, float> OnChanged;

    [SerializeField] private Slider _redSlider;
    [SerializeField] private Slider _greenSlider;
    [SerializeField] private Slider _blueSlider;
    [SerializeField] private Slider _brushSizeSlider;
    [SerializeField] private Image _colorPreview;

    private Color32 _selectedColor;

    private void OnEnable()
    {
        _redSlider.onValueChanged.AddListener(UpdateColor);
        _greenSlider.onValueChanged.AddListener(UpdateColor);
        _blueSlider.onValueChanged.AddListener(UpdateColor);
        _brushSizeSlider.onValueChanged.AddListener(UpdateColor);
    }

    private void OnDisable()
    {
        _redSlider.onValueChanged.RemoveListener(UpdateColor);
        _greenSlider.onValueChanged.RemoveListener(UpdateColor);
        _blueSlider.onValueChanged.RemoveListener(UpdateColor);
        _brushSizeSlider.onValueChanged.RemoveListener(UpdateColor);
    }

    private void UpdateColor(float value)
    {
        byte r = (byte)_redSlider.value;
        byte g = (byte)_greenSlider.value;
        byte b = (byte)_blueSlider.value;

        _selectedColor = new Color32(r, g, b, 255);
        _colorPreview.color = _selectedColor;

        OnChanged?.Invoke(_selectedColor, _brushSizeSlider.value);
    }
}
