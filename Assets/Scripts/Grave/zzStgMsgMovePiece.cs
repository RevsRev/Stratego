using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class StgMsgMovePiece : StgAbstractMsg
{
    private StgMsgResourcePiece piece;

    public const string ATTR_LOCATION_MOVE_TO = "LocationMoveTo";

    public StgMsgMovePiece(XmlElement element) : base(element)
    {
    }
    protected override void readFromXml(XmlElement element)
    {
        XmlNodeList piecesList = element.GetElementsByTagName(StgMsgResourcePiece.TAG_NAME);
        piece = new StgMsgResourcePiece((XmlElement)piecesList.Item(0));


    }

    protected override XmlElement writeToXml(XmlDocument parentDocument)
    {
        throw new NotImplementedException();
    }
}