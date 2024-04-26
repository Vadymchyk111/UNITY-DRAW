using UnityEngine;

public class DrawingScript : MonoBehaviour
{
   [Header("Main Components")]
   [Range(2,512)]
   [SerializeField] private int _textureSize = 128;
   [SerializeField] private TextureWrapMode _textureWrapMode;
   [SerializeField] private FilterMode _filterMode;
   [SerializeField] private Texture2D _texture2D;
   [SerializeField] private Material _material;
   [SerializeField] private Camera _camera;
   [SerializeField] private Collider _collider;
   [SerializeField] private ColorPicker _colorPicker;

   [Header("Paint Utility")] 
   [SerializeField] private Color32 _color;
   [SerializeField] private float _brushSize;

   private void OnEnable()
   {
      _colorPicker.OnChanged += ChangeBrush;
   }

   private void OnDisable()
   {
      _colorPicker.OnChanged -= ChangeBrush;
   }

   private void Start()
   {
      _texture2D = new Texture2D(_textureSize, _textureSize)
      {
         wrapMode = _textureWrapMode,
         filterMode = _filterMode
      };
      
      _material.mainTexture = _texture2D;
      _texture2D.Apply();
   }

   private void Update()
   {
      if (!Input.GetMouseButton(0))
      {
         return;
      }
      
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

      if (!_collider.Raycast(ray, out RaycastHit raycastHit, 100f))
      {
         return;
      }
      
      int rayX = (int)(raycastHit.textureCoord.x * _textureSize);
      int rayY = (int)(raycastHit.textureCoord.y * _textureSize);
      DrawOnTexture(rayX, rayY, _color);
   }

   private void DrawOnTexture(int x, int y, Color32 color)
   {
      int brushSizeInt = Mathf.FloorToInt(_brushSize);

      for (int i = x - brushSizeInt; i < x + brushSizeInt; i++)
      {
         for (int j = y - brushSizeInt; j < y + brushSizeInt; j++)
         {
            if (i >= 0 && i < _textureSize && j >= 0 && j < _textureSize)
            {
               _texture2D.SetPixel(i, j, color);
            }
         }
      }

      _texture2D.Apply();
   }

   private void ChangeBrush(Color32 color, float brushSize)
   {
      _color = color;
      _brushSize = brushSize;
   }
}