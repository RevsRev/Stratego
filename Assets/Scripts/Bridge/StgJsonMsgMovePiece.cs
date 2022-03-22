using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StgJsonMsgMovePiece : StgAbstractJsonMsgContent
{
    public int pieceId;
    public Tuple<int, int> pos;

    public StgJsonMsgMovePiece(int pieceId, Tuple<int,int> pos)
    {
        this.pieceId = pieceId;
        this.pos = pos;
    }
}