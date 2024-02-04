using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public static GridCreator instance { get; private set; }
    
    [SerializeField] private int _width, _height;
    
    [SerializeField] private Cell _tilePrefab;
    
    [SerializeField] private Transform _cam;

    public Cell[,] _cellPositions { get; private set; }
    
    public int Width
    {
        get => _width;
    }
    public int Height
    {
        get => _height;
    }

    private void Awake()
    {
        SetSingleton();
    }

    private void Start() 
    {
        GenerateGrid();
    }
 
    private void GenerateGrid() {
        _cellPositions = new Cell[_width, _height];

        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                Cell spawnedTile = Instantiate(_tilePrefab, new Vector3(x - 1, y), Quaternion.identity, gameObject.transform);
                SpinInvoker.instance.SpinStart += spawnedTile.Spin;
                
                spawnedTile.name = $"Cell X: {x}, Y: {y}";

                _cellPositions[x, y] = spawnedTile;
            }
        }

        //_cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
 
    public Cell GetTileAtPosition(Vector2 pos) {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);

        if (x >= 0 && x < _width && y >= 0 && y < _height) {
            return _cellPositions[x, y];
        }

        return null;
    }
    
    private void SetSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
}
