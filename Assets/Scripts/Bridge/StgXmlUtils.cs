using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public static class StgXmlUtils
{
    public static XmlAttribute getAttributeForName(String attributeName, XmlElement element)
    {
        List<XmlAttribute> attributesForName = getAttributesForName(attributeName, element);
        
        //TODO - error handling if there is more than one...

        if (attributesForName.Count == 0)
        {
            return null;
        }
        return attributesForName[0];
    }
    public static List<XmlAttribute> getAttributesForName(String attributeName, XmlElement element)
    {
        List<XmlAttribute> retval = new List<XmlAttribute>();
        XmlAttributeCollection attributes = element.Attributes;

        for (int i = 0; i< attributes.Count; i++)
        {
            XmlAttribute attribute = attributes[i];
            if (String.Equals(attribute.Name, attributeName))
            {
                retval.Add(attribute);
            }
        }
        return retval;
    }

    public static XmlNode getChildForName(String childName, XmlElement element)
    {
        List<XmlNode> childrenForName = getChildrenForName(childName, element);

        //TODO - error handling if there is more than one...

        if (childrenForName.Count == 0)
        {
            return null;
        }
        return childrenForName[0];
    }
    public static List<XmlNode> getChildrenForName(String childName, XmlElement element)
    {
        List<XmlNode> retval = new List<XmlNode>();
        XmlNodeList childNodes = element.ChildNodes;

        for (int i = 0; i < childNodes.Count; i++)
        {
            XmlNode xmlNode = childNodes[i];
            if (String.Equals(xmlNode.Name, childName))
            {
                retval.Add(xmlNode);
            }
        }
        return retval;
    }
}
