using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class StgVector2Utils
{
    public static string parseToString(Vector2Int vector2)
    {
        return ""+ '(' + vector2.x + ',' + vector2.y + ')';
    }
    public static Vector2Int parseFromString(String str)
    {
        //Not going to do anything clever here, we know what format it will be in from the above method.
        str = str.Substring(1, str.Length - 2);

        int seperatorIndex = str.IndexOf(',');
        String xStr = str.Substring(0, seperatorIndex);
        String yStr = str.Substring(seperatorIndex + 1, str.Length - seperatorIndex - 1);

        int x = int.Parse(xStr);
        int y = int.Parse(yStr);
        return new Vector2Int(x, y);
    }

}
