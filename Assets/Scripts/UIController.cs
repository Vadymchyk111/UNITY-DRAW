using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIControllerView _uiControllerView;
    [SerializeField] private TexturePainting _texturePainting;

    private void OnEnable()
    {
        _uiControllerView.SaveButton.onClick.AddListener(SaveTexture);
        _uiControllerView.LoadButton.onClick.AddListener(LoadTexture);
        _uiControllerView.ClearButton.onClick.AddListener(ClearTexture);
    }

    private void OnDisable()
    {
        _uiControllerView.SaveButton.onClick.RemoveListener(SaveTexture);
        _uiControllerView.LoadButton.onClick.RemoveListener(LoadTexture);
        _uiControllerView.ClearButton.onClick.RemoveListener(ClearTexture);
    }

    private void SaveTexture()
    {
        FileTextureSaver.SaveTextureToFile(_texturePainting.Texture.EncodeToPNG());
    }

    private void LoadTexture()
    {
        _texturePainting.SetTexture(FileTextureSaver.LoadTextureFromFile());
    }

    private void ClearTexture()
    {
        _texturePainting.ClearTexture();
    }
}