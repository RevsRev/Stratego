using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class StgMsgDeletePiece : StgAbstractMsg
{
    public StgMsgDeletePiece(XmlElement element) : base(element)
    {
    }

    protected override void readFromXml(XmlElement element)
    {
        throw new NotImplementedException();
    }

    protected override XmlElement writeToXml(XmlDocument parentDocument)
    {
        throw new NotImplementedException();
    }
}