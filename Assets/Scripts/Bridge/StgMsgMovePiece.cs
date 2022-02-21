using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class StgMsgMovePiece : StgAbstractMsg
{
    public StgMsgMovePiece(XmlDocument data) : base(data)
    {
    }
}