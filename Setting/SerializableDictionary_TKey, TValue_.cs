using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Setting
{
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
	{
		public SerializableDictionary()
		{
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			bool isEmptyElement = reader.IsEmptyElement;
			reader.Read();
			if (isEmptyElement)
			{
				return;
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TKey));
			XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(TValue));
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				reader.ReadStartElement("KeyValuePair");
				reader.ReadStartElement("Key");
				TKey tKey = (TKey)xmlSerializer.Deserialize(reader);
				reader.ReadEndElement();
				reader.ReadStartElement("Value");
				TValue tValue = (TValue)xmlSerializer1.Deserialize(reader);
				reader.ReadEndElement();
				reader.ReadEndElement();
				base.Add(tKey, tValue);
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TKey));
			XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(TValue));
			foreach (TKey key in base.Keys)
			{
				writer.WriteStartElement("KeyValuePair");
				writer.WriteStartElement("Key");
				xmlSerializer.Serialize(writer, key);
				writer.WriteEndElement();
				writer.WriteStartElement("Value");
				xmlSerializer1.Serialize(writer, base[key]);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
	}
}