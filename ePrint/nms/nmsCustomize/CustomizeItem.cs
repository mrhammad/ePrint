using System;

namespace nmsCustomize
{
	public class CustomizeItem
	{
		private int _customizeId;

		private int _companyID;

		private string _databaseFieldName = string.Empty;

		private string _labelName = string.Empty;

		private string _inputBoxID = string.Empty;

		private string _inputType = string.Empty;

		private string _dataType = string.Empty;

		private bool _isDisplayed;

		private bool _isDefault;

		private bool _isRequired;

		private bool _isReadOnly;

		private int _orderNumber;

		private string _dataBaseName = string.Empty;

		private string _optionValue = string.Empty;

		private int _maxLength;

		private string _fieldType = string.Empty;

		private int _decimalPlace;

		private string _optionType = string.Empty;

		private bool _isDelete;

		private bool _isNewRow;

		private string _screenName = string.Empty;

		private string _firstname = string.Empty;

		private string _lastname = string.Empty;

		public int CompanyID
		{
			get
			{
				return this._companyID;
			}
			set
			{
				this._companyID = value;
			}
		}

		public int CustomizeID
		{
			get
			{
				return this._customizeId;
			}
			set
			{
				this._customizeId = value;
			}
		}

		public string DatabaseFieldName
		{
			get
			{
				return this._databaseFieldName;
			}
			set
			{
				this._databaseFieldName = value;
			}
		}

		public string DataBaseName
		{
			get
			{
				return this._dataBaseName;
			}
			set
			{
				this._dataBaseName = value;
			}
		}

		public string DataType
		{
			get
			{
				return this._dataType;
			}
			set
			{
				this._dataType = value;
			}
		}

		public int DecimalPlace
		{
			get
			{
				return this._decimalPlace;
			}
			set
			{
				this._decimalPlace = value;
			}
		}

		public string FieldType
		{
			get
			{
				return this._fieldType;
			}
			set
			{
				this._fieldType = value;
			}
		}

		public string Firstname
		{
			get
			{
				return this._firstname;
			}
			set
			{
				this._firstname = value;
			}
		}

		public string InputBoxID
		{
			get
			{
				return this._inputBoxID;
			}
			set
			{
				this._inputBoxID = value;
			}
		}

		public string InputType
		{
			get
			{
				return this._inputBoxID;
			}
			set
			{
				this._inputBoxID = value;
			}
		}

		public bool IsDefault
		{
			get
			{
				return this._isDefault;
			}
			set
			{
				this._isDefault = value;
			}
		}

		public bool IsDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				this._isDelete = value;
			}
		}

		public bool IsDisplayed
		{
			get
			{
				return this._isDisplayed;
			}
			set
			{
				this._isDisplayed = value;
			}
		}

		public bool IsNewRow
		{
			get
			{
				return this._isNewRow;
			}
			set
			{
				this._isNewRow = value;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return this._isReadOnly;
			}
			set
			{
				this._isReadOnly = value;
			}
		}

		public bool IsRequired
		{
			get
			{
				return this._isRequired;
			}
			set
			{
				this._isRequired = value;
			}
		}

		public string LabelName
		{
			get
			{
				return this._labelName;
			}
			set
			{
				this._labelName = value;
			}
		}

		public string Lastname
		{
			get
			{
				return this._lastname;
			}
			set
			{
				this._lastname = value;
			}
		}

		public int MaxLength
		{
			get
			{
				return this._maxLength;
			}
			set
			{
				this._maxLength = value;
			}
		}

		public string OptionType
		{
			get
			{
				return this._optionType;
			}
			set
			{
				this._optionType = value;
			}
		}

		public string OptionValue
		{
			get
			{
				return this._optionValue;
			}
			set
			{
				this._optionValue = value;
			}
		}

		public int OrderNumber
		{
			get
			{
				return this._orderNumber;
			}
			set
			{
				this._orderNumber = value;
			}
		}

		public string ScreenName
		{
			get
			{
				return this._screenName;
			}
			set
			{
				this._screenName = value;
			}
		}

		public CustomizeItem()
		{
		}

		public CustomizeItem(int customizeID, int companyID, string databaseFieldName, string labelName, string inputType, string dataType, bool isDisplayed, bool isDefault, bool isRequired, bool isReadOnly, int orderNumber, string dataBaseName, string optionValue, int maxLength, string fieldType, bool isNewRow, string screenName)
		{
			this.CustomizeID = customizeID;
			this.CompanyID = companyID;
			this.DatabaseFieldName = databaseFieldName;
			this.LabelName = labelName;
			this.InputType = inputType;
			this.DataType = dataType;
			this.IsDisplayed = isDisplayed;
			this.IsDefault = isDefault;
			this.IsRequired = isRequired;
			this.IsReadOnly = isReadOnly;
			this.OrderNumber = orderNumber;
			this.DataBaseName = dataBaseName;
			this.OptionValue = optionValue;
			this.MaxLength = maxLength;
			this.FieldType = fieldType;
			this.IsNewRow = isNewRow;
			this.ScreenName = screenName;
		}
	}
}