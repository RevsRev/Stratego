using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class StgXml : XmlDocument
{

    public XmlAttribute getAttributeForName(String attributeName)
    {
        List<XmlAttribute> attributesForName = getAttributesForName(attributeName);
        
        //TODO - error handling if there is more than one...

        if (attributesForName.Count == 0)
        {
            return null;
        }
        return attributesForName[0];
    }
    public List<XmlAttribute> getAttributesForName(String attributeName)
    {
        List<XmlAttribute> retval = new List<XmlAttribute>();

        for (int i = 0; i<Attributes.Count; i++)
        {
            XmlAttribute attribute = Attributes[i];
            if (String.Equals(attribute.Name, attributeName))
            {
                retval.Add(attribute);
            }
        }
        return retval;
    }

    public XmlNode getChildForName(String childName)
    {
        List<XmlNode> childrenForName = getChildrenForName(childName);

        //TODO - error handling if there is more than one...

        if (childrenForName.Count == 0)
        {
            return null;
        }
        return childrenForName[0];
    }
    public List<XmlNode> getChildrenForName(String childName)
    {
        List<XmlNode> retval = new List<XmlNode>();

        for (int i = 0; i < ChildNodes.Count; i++)
        {
            XmlNode xmlNode = ChildNodes[i];
            if (String.Equals(xmlNode.Name, childName))
            {
                retval.Add(xmlNode);
            }
        }
        return retval;
    }
}
