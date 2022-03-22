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
    public const string TAG_NAME = "ResourcePiece";

    public const string ATTRIBUTE_LOCATION = "Location";
    public const string ATTRIBUTE_TYPE = "Type";

    Vector2Int ?location = null;
    String type = null;

    public StgMsgResourcePiece(XmlElement element) : base(element)
    {
        
    }
    protected override void readFromXml(XmlElement element)
    {
        XmlAttribute attrLocation = StgXmlUtils.getAttributeForName(ATTRIBUTE_LOCATION, element);
        XmlAttribute attrType = StgXmlUtils.getAttributeForName(ATTRIBUTE_TYPE, element);

        location = StgVector2Utils.parseFromString(attrLocation.Value);
        type = attrType.Value;
    }

    protected override XmlElement writeToXml(XmlDocument parentDocument)
    {
        XmlElement retval = parentDocument.CreateElement(TAG_NAME);
        retval.SetAttribute(ATTRIBUTE_LOCATION, StgVector2Utils.parseToString((Vector2Int)location));
        retval.SetAttribute(ATTRIBUTE_TYPE, type);

        return retval;
    }
}