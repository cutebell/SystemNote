using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Config = NoteBook.Properties.Settings;

namespace NoteBook
{
    internal class XMLAccess
    {
        /// <summary>
        /// 初期化成功フラグ
        /// </summary>
        private bool _InitSuccessFlg;

        private XmlDocument XML;

        /// <summary>
        /// 初期化成功フラグを取得します
        /// </summary>
        internal bool InitSuccessFlg
        {
            get { return _InitSuccessFlg; }
        }

        /// <summary>
        /// <para>XMLAccessクラスを初期化します</para>
        /// <para>InitSuccessFlgを取得して初期化が成功したかどうか確認して下さい</para>
        /// <para>InitSuccessFlg bool</para>
        /// <para>true=初期化成功</para>
        /// <para>false=初期化失敗</para>
        /// </summary>
        /// <param name="XMLFilePath">XMLファイルのパス</param>
        internal XMLAccess(String XMLFilePath)
        {
            if (!File.Exists(XMLFilePath))
            {
                _InitSuccessFlg = false;
                return;
            }
            XML = new XmlDocument();
            XML.Load(XMLFilePath);
            _InitSuccessFlg = true;
        }

        /// <summary>
        /// インデックス名を全て取得する
        /// </summary>
        /// <returns></returns>
        internal String[] getAllIndex()
        {
            XmlNode root = XML.DocumentElement;
            XmlNodeList indexList = root.ChildNodes;

            List<String> IndexNames = new List<string>();
            foreach (XmlNode node in indexList)
            {
                if (0 > IndexNames.IndexOf(node.Attributes[0].Value))
                {
                    IndexNames.Add(node.Attributes[0].Value);
                }
            }

            return getStringArray(IndexNames);
        }

        internal String[] getValue(String AttributeName)
        {
            XmlNode root = XML.DocumentElement;
            XmlNodeList indexList = root.ChildNodes;
            List<String> values = new List<string>();
            foreach (XmlNode node in indexList)
            {
                if (0 == AttributeName.CompareTo(node.Attributes[0].Value))
                {
                    values.Add(node.InnerText);
                }
            }

            return getStringArray(values);
        }

        internal bool appendXML(String Attribute, String val)
        {
            XmlNode root = XML.DocumentElement;
            XmlNode node = XML.CreateElement("data");
            XmlAttribute a = XML.CreateAttribute("name");
            a.Value = Attribute;
            node.Attributes.Append(a);
            node.InnerText = val;
            root.AppendChild(node);

            return false;
        }

        internal bool deleteXML(String Attribute)
        {
            XmlNode root = XML.DocumentElement;
            XmlNodeList indexList = root.ChildNodes;
            List<String> values = new List<string>();
            List<XmlNode> delList = new List<XmlNode>();
            foreach (XmlNode node in indexList)
            {
                if (0 == Attribute.CompareTo(node.Attributes[0].Value))
                {
                    delList.Add(node);
                }
            }

            foreach (XmlNode node in delList)
            {
                root.RemoveChild(node);
            }

            return false;
        }

        internal bool saveXML()
        {
            XML.Save(Config.Default.noteXMLPath);
            return true;
        }


        /// <summary>
        /// List&lt;String&gt;をString[]に変換する
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        internal String[] getStringArray(List<String> list)
        {
            String[] ret = new String[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                ret[i] = list[i];
            }

            return ret;
        }
    }
}
