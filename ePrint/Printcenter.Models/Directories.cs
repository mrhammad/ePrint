using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;
using Telerik.Web.UI;

[ScriptService]
[WebService(Namespace="http://tempuri.org/")]
[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
public class Directories : WebService
{
	public Directories()
	{
	}

	public List<Directories.NodeData> BindDirectory(string dirPath)
	{
		List<Directories.NodeData> nodeDatas = new List<Directories.NodeData>();
		string[] directories = Directory.GetDirectories(dirPath);
		for (int i = 0; i < (int)directories.Length; i++)
		{
			string str = directories[i];
			Directories.NodeData nodeDatum = new Directories.NodeData()
			{
				Text = Path.GetFileName(str),
				Value = str
			};
			if ((int)Directory.GetDirectories(str).Length > 0)
			{
				nodeDatum.ExpandMode = TreeNodeExpandMode.WebService;
			}
			nodeDatum.ImageUrl = "Img/mailfolder.gif";
			nodeDatas.Add(nodeDatum);
		}
		return nodeDatas;
	}

	[WebMethod]
	public Directories.NodeData[] GetDirectories(RadTreeNodeData node)
	{
		return this.BindDirectory(node.Value).ToArray();
	}

	[WebMethod]
	public List<Directories.Info> GetFilesAndFolders(string dirPath)
	{
		List<Directories.Info> infos = new List<Directories.Info>();
		string[] directories = Directory.GetDirectories(dirPath);
		for (int i = 0; i < (int)directories.Length; i++)
		{
			string str = directories[i];
			Directories.Info info = new Directories.Info()
			{
				Name = Path.GetFileName(str)
			};
			infos.Add(info);
		}
		FileInfo[] files = (new DirectoryInfo(dirPath)).GetFiles();
		for (int j = 0; j < (int)files.Length; j++)
		{
			FileInfo fileInfo = files[j];
			Directories.Info info1 = new Directories.Info()
			{
				Name = fileInfo.Name,
				Size = new long?(fileInfo.Length)
			};
			infos.Add(info1);
		}
		return infos;
	}

	public class Info
	{
		private string _name;

		private long? _size;

		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public long? Size
		{
			get
			{
				return this._size;
			}
			set
			{
				this._size = value;
			}
		}

		public Info()
		{
		}
	}

	[Serializable]
	public class NodeData
	{
		private string _text;

		private string _value;

		private string _imageurl;

		private TreeNodeExpandMode _expandMode;

		public TreeNodeExpandMode ExpandMode
		{
			get
			{
				return this._expandMode;
			}
			set
			{
				this._expandMode = value;
			}
		}

		public string ImageUrl
		{
			get
			{
				return this._imageurl;
			}
			set
			{
				this._imageurl = value;
			}
		}

		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
			}
		}

		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		public NodeData()
		{
		}
	}
}