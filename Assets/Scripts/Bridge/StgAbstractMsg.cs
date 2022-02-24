using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public abstract class StgAbstractMsg
{
    public const string MESSAGE_MOVE_PIECE = "MovePiece";
    public const string MESSAGE_REMOVE_PIECE = "RemovePiece";

    public const string TAG_NAME_MSG_TYPE = "MsgType";

    public StgAbstractMsg(XmlElement element)
    {
        readFromXml(element);
    }
    protected abstract void readFromXml(XmlElement element);

    protected abstract XmlElement writeToXml(XmlDocument parentDocument);
    public static StgAbstractMsg factoryForData(String data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);

        XmlElement element = (XmlElement)doc.FirstChild;

        XmlNodeList xmlNodeList = doc.GetElementsByTagName(TAG_NAME_MSG_TYPE);
        string msgType = xmlNodeList.Item(0).InnerText;

        if (String.Equals(msgType, MESSAGE_MOVE_PIECE))
        {
            return new StgMsgMovePiece(element);
        }

        if (String.Equals(msgType, MESSAGE_REMOVE_PIECE))
        {
            return new StgMsgDeletePiece(element);
        }

        throw new NotImplementedException();
    }
}