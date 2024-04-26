using System;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerView : MonoBehaviour
{
    public event Action<bool> OnPaletteOpen;
    
    [SerializeField] private Button _colorPaletteButton;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _clearButton;
    [SerializeField] private GameObject _palettePanel;
    [SerializeField] private Button _closePalettePanel;

    public Button ColorPaletteButton => _colorPaletteButton;
    public Button SaveButton => _saveButton;
    public Button LoadButton => _loadButton;
    public Button ClearButton => _clearButton;
    
    private bool IsPaletteOpen { get; set; }

    private void ActivatePalette()
    {
        IsPaletteOpen = !IsPaletteOpen;
        _palettePanel.SetActive(IsPaletteOpen);
        OnPaletteOpen?.Invoke(IsPaletteOpen);
    }

    private void OnEnable()
    {
        _closePalettePanel.onClick.AddListener(() =>
        {
            _palettePanel.SetActive(false);
            IsPaletteOpen = false;
            OnPaletteOpen?.Invoke(false);
        });
        _colorPaletteButton.onClick.AddListener(ActivatePalette);
    }
}