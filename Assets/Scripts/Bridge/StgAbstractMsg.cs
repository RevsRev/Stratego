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

    protected StgXml data;

    public StgAbstractMsg(StgXml data)
    {
        this.data = data;
        readFromXml();
    }
    protected abstract void readFromXml();

    protected abstract StgXml writeToXml();
    public static StgAbstractMsg factoryForData(String data)
    {
        StgXml doc = new StgXml();
        doc.LoadXml(data);

        XmlNodeList xmlNodeList = doc.GetElementsByTagName(TAG_NAME_MSG_TYPE);
        string msgType = xmlNodeList.Item(0).InnerText;

        if (String.Equals(msgType, MESSAGE_MOVE_PIECE))
        {
            return new StgMsgMovePiece(doc);
        }

        if (String.Equals(msgType, MESSAGE_REMOVE_PIECE))
        {
            return new StgMsgDeletePiece(doc);
        }

        throw new NotImplementedException();
    }
}