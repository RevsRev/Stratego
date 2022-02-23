using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class StgMsgMovePiece : StgAbstractMsg
{
    private StgMsgResourcePiece piece;

    public const string NODE_PIECE = "Piece";
    public const string ATTR_LOCATION_MOVE_TO = "LocationMoveTo";

    public StgMsgMovePiece(StgXml data) : base(data)
    {
    }

    protected override void readFromXml()
    {
        XmlNode xmlNode = data.getChildForName(NODE_PIECE);
    }

    protected override StgXml writeToXml()
    {
        throw new NotImplementedException();
    }
}