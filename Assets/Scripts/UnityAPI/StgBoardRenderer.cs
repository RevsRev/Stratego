using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBoardRenderer : MonoBehaviour
{
    private StgBoard board;
    public GameObject tileHighlightPrefab;
    public GameObject tileHighlight { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initing board renderer");
        initTileHighlight();
    }

    private void initTileHighlight()
    {
        Vector2Int gridPoint = GridGeometry.GridPoint(0, 0);
        Vector3 point = GridGeometry.PointFromGrid(gridPoint);
        tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
        tileHighlight.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        updateTileHighlight();
    }

    private void updateTileHighlight()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            tileHighlight.active = true;
            tileHighlight.transform.position =  GridGeometry.GridPointFromPoint(hit.point);
        }
        else
        {
            tileHighlight.active = false;
        }
    }
}
