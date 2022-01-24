using UnityEngine;

public class GridGeometry
{
    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        float x = 10.0f * (gridPoint.x + 0.5f);
        float y = 10.0f * (gridPoint.y + 0.5f);
        return new Vector3(x, y, 0);
    }

    static public Vector2Int GridPoint(int col, int row)
    {
        return new Vector2Int(col, row);
    }

    static public Vector2Int GridFromPoint(Vector3 point)
    {
        int col = Mathf.FloorToInt(point.x/10.0f);
        int row = Mathf.FloorToInt(point.y/10.0f);
        return new Vector2Int(col, row);
    }

    public static Vector3 GridPointFromPoint(Vector3 point)
    {
        return PointFromGrid(GridFromPoint(point));
    }
}
