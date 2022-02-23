using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class StgMsgDeletePiece : StgAbstractMsg
{
    public StgMsgDeletePiece(StgXml data) : base(data)
    {

    }

    protected override void readFromXml()
    {
        throw new NotImplementedException();
    }

    protected override StgXml writeToXml()
    {
        throw new NotImplementedException();
    }
}