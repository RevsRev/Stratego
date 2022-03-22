using System;
using System.Text.Json;

public class StgJsonMsg
{
    public String msgType = "";
    public StgAbstractJsonMsgContent content = null;

    /*
     * This method will only be used when deserialising messages.
     */
    public StgJsonMsg(String msgType, StgAbstractJsonMsgContent content)
    {
        this.msgType = msgType;
        this.content = content;
    }

    /*
     * The method we should always be using for creating messages.
     */
    public StgJsonMsg(StgAbstractJsonMsgContent content)
    {
        this.msgType = getMsgTypeForContent(content);
        this.content = content;
    }

    private string getMsgTypeForContent(StgAbstractJsonMsgContent content)
    {
        throw new NotImplementedException();
    }

    public string toJson()
    {
        return JsonSerializer.Serialize(this);
    }
    public static StgJsonMsg fromJson(String json)
    {
        return JsonSerializer.Deserialize<StgJsonMsg>(json);
    }
}
