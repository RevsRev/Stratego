using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

/*
 * Xml representing a piece, which will be written to a msg.
 * Responses to and from the server will (usually) not require the actual type of piece to be contained in the message,
 * the exception being when the user initialises their piece selection.
 */
public class StgMsgResourcePiece : StgAbstractMsg
{
    public const string ATTRIBUTE_LOCATION = "Location";
    public const string ATTRIBUTE_TYPE = "Type";

    Vector2Int ?location = null;
    String type = null;

    public StgMsgResourcePiece(StgXml data) : base(data)
    {
        
    }
    protected override void readFromXml()
    {
        XmlAttribute attrLocation = data.getAttributeForName(ATTRIBUTE_LOCATION);
        XmlAttribute attrType = data.getAttributeForName(ATTRIBUTE_TYPE);

        location = StgVector2Utils.parseFromString(attrLocation.Value);
        type = attrType.Value;
    }

    protected override StgXml writeToXml()
    {
        StgXml xml = new StgXml();
        xml.CreateAttribute(ATTRIBUTE_TYPE, type);
        xml.CreateAttribute(ATTRIBUTE_LOCATION, StgVector2Utils.parseToString((Vector2Int)location));

        return xml;
    }
}