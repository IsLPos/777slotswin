using System;
using System.Collections;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public static Slot instance { get; private set; }

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _particles;
    
    [HideInInspector] public LineRenderer lineRenderer;

    public event Action<int> ComboFound; 

    private int _tempId;
    
    private bool _needToCheckCombo = true;
    private bool _foundCombo;
    
    private void Awake()
    {
        SetSingleton();
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CheckCombinations()
    {
        if (_needToCheckCombo)
        { 
            _needToCheckCombo = false;
            _foundCombo = false;
            for (int row = 0; row < 3; row++)
            {
                bool rowCombo = CheckAndDrawCombo(new Vector2Int(row, 0), new Vector2Int(row, 1), new Vector2Int(row, 2));
                if (rowCombo)
                {
                    break;
                }
            }

            for (int col = 0; col < 3; col++)
            { 
                bool colCombo = CheckAndDrawCombo(new Vector2Int(0, col), new Vector2Int(1, col), new Vector2Int(2, col)); 
                if (colCombo) 
                {
                    break;
                }
            }
            
            bool diagonalRight = CheckAndDrawCombo(new Vector2Int(0, 0), new Vector2Int(1, 1), new Vector2Int(2, 2));
            bool diagonalLeft = CheckAndDrawCombo(new Vector2Int(0, 2), new Vector2Int(1, 1), new Vector2Int(2, 0));
            bool halfTriangle = CheckAndDrawCombo(new Vector2Int(2, 0), new Vector2Int(1, 1), new Vector2Int(2, 2));
            bool lineCurve = CheckAndDrawCombo(new Vector2Int(2, 0), new Vector2Int(1, 1), new Vector2Int(1, 2));
            _needToCheckCombo = true;
        }
    }

    public void ClearLines()
    {
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
        lineRenderer.SetPosition(2, Vector3.zero);
    }
    
    private bool CheckAndDrawCombo(Vector2Int position1, Vector2Int position2, Vector2Int position3)
    {
        bool result = CheckRow(position1, position2, position3);
    
        if (result && !_foundCombo)
        {
            _foundCombo = true;
            ComboFound?.Invoke(_tempId);
            DrawCombo(new Vector3(position1.x, position1.y, -1), new Vector3(position2.x, position2.y, -1), new Vector3(position3.x, position3.y, -1));
        }

        return result;
    }
    
    private bool CheckRow(Vector2Int firstPos, Vector2Int secondPos, Vector2Int thirdPos)
    {
        Sign firstSign = GridCreator.instance._cellPositions[firstPos.x, firstPos.y].mySign;
        Sign SecondSign = GridCreator.instance._cellPositions[secondPos.x, secondPos.y].mySign;
        Sign ThirdSign = GridCreator.instance._cellPositions[thirdPos.x, thirdPos.y].mySign;

        if (firstSign.Id == SecondSign.Id && SecondSign.Id == ThirdSign.Id)
        {
            Debug.Log("Good Row");
            _tempId = firstSign.Id;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DrawCombo(Vector3 firstPos, Vector3 secondPos, Vector3 thirdPos)
    {
        StartCoroutine(LineFade(firstPos, secondPos, thirdPos));
        _winPanel.SetActive(true);

        Vector3 spawnPos = new Vector3(-0.02f, 1.46f, -2f);
        Quaternion rotatePos = Quaternion.Euler(0f, 180f, 0f);
        Instantiate(_particles, spawnPos, rotatePos);
    }

    private IEnumerator LineFade(Vector3 firstPos, Vector3 secondPos, Vector3 thirdPos)
    {
        firstPos.x -= 1;
        secondPos.x -= 1;
        thirdPos.x -= 1;
        for (int i = 0; i < 2; i++)
        {
            lineRenderer.SetPosition(0, firstPos);
            lineRenderer.SetPosition(1, secondPos);
            lineRenderer.SetPosition(2, thirdPos);

            yield return new WaitForSeconds(0.2f);

            ClearLines();

            yield return new WaitForSeconds(0.2f);
        }
        
        lineRenderer.SetPosition(0, firstPos);
        lineRenderer.SetPosition(1, secondPos);
        lineRenderer.SetPosition(2, thirdPos);
    }
    
    private void SetSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}


