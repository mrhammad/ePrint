using Printcenter.BusinessAccessLayer;
using System;

namespace Printcenter.BusinessAccessLayer.ApprovalSystem
{
    public class ApprovalSystemItems : BaseItem
    {
        private long _StatusID;

        private long _approvalSystemID;

        private long _accountID;

        private string _approvalType;

        private bool _reapproval;

        private bool _requirePwd;

        private string _approverEmail = string.Empty;

        private bool _lastApproverDefault;

        private bool _newOrdersApprove;

        private bool _newUserApprove;

        private bool _editedUserApprove;

        private long _createdBy;

        private long _companyID;

        private int _isSelfReg = 1;

        private bool _isDeleted;

        private DateTime _createdOn;

        private int _approvalReqForOrder;

        private int _orderResendApproval;

        private int _orderAutoDelete;

        private int _orderAutoChangeStatus;

        private int _orderInformAdmin;

        private int _regResendApproval;

        private int _regAutoReject;

        private int _regInformAdmin;

        private long _ApprovalRegisterID;

        private string _userDeptType = string.Empty;

        private int _DepartmentID;

        private bool _AddNewDept;

        private int _PrefilAdded;

        private int _OverwriteAdded;

        private string _registerEmailAddress = string.Empty;

        private string _DeptScreenName = string.Empty;

        private string _approvedEmailAddress = string.Empty;

        private bool _SingleField;

        private long _ApprovalOrderID;

        private string _allow_order_behalf_users_app = string.Empty;

        private string _allow_order_behalf_users_dept = string.Empty;

        private string _allow_order_behalf_users_user = string.Empty;

        private string _allow_order_behalf_depts_app = string.Empty;

        private string _allow_order_behalf_depts_dept = string.Empty;

        private string _allow_order_behalf_depts_user = string.Empty;

        private string _allow_checkout_process_app = string.Empty;

        private string _allow_checkout_process_dept = string.Empty;

        private string _allow_checkout_process_user = string.Empty;

        private string _users_change_addresses_app = string.Empty;

        private string _users_change_addresses_dept = string.Empty;

        private string _users_change_addresses_user = string.Empty;

        private string _users_select_addresses_app = string.Empty;

        private string _users_select_addresses_dept = string.Empty;

        private string _users_select_addresses_user = string.Empty;

        private string _users_edit_addresses_app = string.Empty;

        private string _users_edit_addresses_dept = string.Empty;

        private string _users_edit_addresses_user = string.Empty;

        // save new address
        private string _users_new_add_addresses_app = string.Empty;

        private string _users_new_add_addresses_dept = string.Empty;

        private string _users_new_add_addresses_user = string.Empty;


        private string _users_add_addresses_app = string.Empty;

        private string _users_add_addresses_dept = string.Empty;

        private string _users_add_addresses_user = string.Empty;

        private bool _ShowCostCentre;

        private string _ShowStockReplenish = string.Empty;

        private bool _MarkalltheitemsasApproved;

        private string _users_select_Department_address_MainApp = string.Empty;

        private string _users_select_Department_address_DeptApp = string.Empty;

        private string _users_select_Department_address_AllUser = string.Empty;

        private string _users_addNew_addresses_NotSaved_MainApp = string.Empty;

        private string _users_addNew_addresses_NotSaved_DeptApp = string.Empty;

        private string _users_addNew_addresses_NotSaved_AllUser = string.Empty;

        private bool _attachConsignmentNumberToUrl = false;

        public long accountID
        {
            get
            {
                return this._accountID;
            }
            set
            {
                this._accountID = value;
            }
        }

        public bool AddNewDept
        {
            get
            {
                return this._AddNewDept;
            }
            set
            {
                this._AddNewDept = value;
            }
        }

        public string allow_checkout_process_app
        {
            get
            {
                return this._allow_checkout_process_app;
            }
            set
            {
                this._allow_checkout_process_app = value;
            }
        }

        public string allow_checkout_process_dept
        {
            get
            {
                return this._allow_checkout_process_dept;
            }
            set
            {
                this._allow_checkout_process_dept = value;
            }
        }

        public string allow_checkout_process_user
        {
            get
            {
                return this._allow_checkout_process_user;
            }
            set
            {
                this._allow_checkout_process_user = value;
            }
        }

        public string allow_order_behalf_depts_app
        {
            get
            {
                return this._allow_order_behalf_depts_app;
            }
            set
            {
                this._allow_order_behalf_depts_app = value;
            }
        }

        public string allow_order_behalf_depts_dept
        {
            get
            {
                return this._allow_order_behalf_depts_dept;
            }
            set
            {
                this._allow_order_behalf_depts_dept = value;
            }
        }

        public string allow_order_behalf_depts_user
        {
            get
            {
                return this._allow_order_behalf_depts_user;
            }
            set
            {
                this._allow_order_behalf_depts_user = value;
            }
        }

        public string allow_order_behalf_users_app
        {
            get
            {
                return this._allow_order_behalf_users_app;
            }
            set
            {
                this._allow_order_behalf_users_app = value;
            }
        }

        public string allow_order_behalf_users_dept
        {
            get
            {
                return this._allow_order_behalf_users_dept;
            }
            set
            {
                this._allow_order_behalf_users_dept = value;
            }
        }

        public string allow_order_behalf_users_user
        {
            get
            {
                return this._allow_order_behalf_users_user;
            }
            set
            {
                this._allow_order_behalf_users_user = value;
            }
        }

        public long ApprovalOrderID
        {
            get
            {
                return this._ApprovalOrderID;
            }
            set
            {
                this._ApprovalOrderID = value;
            }
        }

        public long ApprovalRegisterID
        {
            get
            {
                return this._ApprovalRegisterID;
            }
            set
            {
                this._ApprovalRegisterID = value;
            }
        }

        public int approvalReqForOrder
        {
            get
            {
                return this._approvalReqForOrder;
            }
            set
            {
                this._approvalReqForOrder = value;
            }
        }

        public long approvalSystemID
        {
            get
            {
                return this._approvalSystemID;
            }
            set
            {
                this._approvalSystemID = value;
            }
        }

        public string approvalType
        {
            get
            {
                return this._approvalType;
            }
            set
            {
                this._approvalType = value;
            }
        }

        public string approvedEmailAddress
        {
            get
            {
                return this._approvedEmailAddress;
            }
            set
            {
                this._approvedEmailAddress = value;
            }
        }

        public string approverEmail
        {
            get
            {
                return this._approverEmail;
            }
            set
            {
                this._approverEmail = value;
            }
        }

        public long companyID
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

        public long createdBy
        {
            get
            {
                return this._createdBy;
            }
            set
            {
                this._createdBy = value;
            }
        }

        public DateTime createdOn
        {
            get
            {
                return this._createdOn;
            }
            set
            {
                this._createdOn = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return this._DepartmentID;
            }
            set
            {
                this._DepartmentID = value;
            }
        }

        public string DeptScreenName
        {
            get
            {
                return this._DeptScreenName;
            }
            set
            {
                this._DeptScreenName = value;
            }
        }

        public bool editedUserApprove
        {
            get
            {
                return this._editedUserApprove;
            }
            set
            {
                this._editedUserApprove = value;
            }
        }

        public bool isDeleted
        {
            get
            {
                return this._isDeleted;
            }
            set
            {
                this._isDeleted = value;
            }
        }

        public int isSelfReg
        {
            get
            {
                return this._isSelfReg;
            }
            set
            {
                this._isSelfReg = value;
            }
        }

        public bool lastApproverDefault
        {
            get
            {
                return this._lastApproverDefault;
            }
            set
            {
                this._lastApproverDefault = value;
            }
        }

        public bool MarkalltheitemsasApproved
        {
            get
            {
                return this._MarkalltheitemsasApproved;
            }
            set
            {
                this._MarkalltheitemsasApproved = value;
            }
        }

        public bool newOrdersApprove
        {
            get
            {
                return this._newOrdersApprove;
            }
            set
            {
                this._newOrdersApprove = value;
            }
        }

        public bool newUserApprove
        {
            get
            {
                return this._newUserApprove;
            }
            set
            {
                this._newUserApprove = value;
            }
        }

        public int orderAutoChangeStatus
        {
            get
            {
                return this._orderAutoChangeStatus;
            }
            set
            {
                this._orderAutoChangeStatus = value;
            }
        }

        public int orderAutoDelete
        {
            get
            {
                return this._orderAutoDelete;
            }
            set
            {
                this._orderAutoDelete = value;
            }
        }

        public int orderInformAdmin
        {
            get
            {
                return this._orderInformAdmin;
            }
            set
            {
                this._orderInformAdmin = value;
            }
        }

        public int orderResendApproval
        {
            get
            {
                return this._orderResendApproval;
            }
            set
            {
                this._orderResendApproval = value;
            }
        }

        public int OverwriteAdded
        {
            get
            {
                return this._OverwriteAdded;
            }
            set
            {
                this._OverwriteAdded = value;
            }
        }

        public int PrefilAdded
        {
            get
            {
                return this._PrefilAdded;
            }
            set
            {
                this._PrefilAdded = value;
            }
        }

        public bool reapproval
        {
            get
            {
                return this._reapproval;
            }
            set
            {
                this._reapproval = value;
            }
        }

        public int regAutoReject
        {
            get
            {
                return this._regAutoReject;
            }
            set
            {
                this._regAutoReject = value;
            }
        }

        public int regInformAdmin
        {
            get
            {
                return this._regInformAdmin;
            }
            set
            {
                this._regInformAdmin = value;
            }
        }

        public string registerEmailAddress
        {
            get
            {
                return this._registerEmailAddress;
            }
            set
            {
                this._registerEmailAddress = value;
            }
        }

        public int regResendApproval
        {
            get
            {
                return this._regResendApproval;
            }
            set
            {
                this._regResendApproval = value;
            }
        }

        public bool requirePwd
        {
            get
            {
                return this._requirePwd;
            }
            set
            {
                this._requirePwd = value;
            }
        }

        public bool ShowCostCentre
        {
            get
            {
                return this._ShowCostCentre;
            }
            set
            {
                this._ShowCostCentre = value;
            }
        }

        public string ShowStockReplenish
        {
            get
            {
                return this._ShowStockReplenish;
            }
            set
            {
                this._ShowStockReplenish = value;
            }
        }

        public bool SingleField
        {
            get
            {
                return this._SingleField;
            }
            set
            {
                this._SingleField = value;
            }
        }

        public long StatusID
        {
            get
            {
                return this._StatusID;
            }
            set
            {
                this._StatusID = value;
            }
        }

        public string userDeptType
        {
            get
            {
                return this._userDeptType;
            }
            set
            {
                this._userDeptType = value;
            }
        }

        public string users_add_addresses_app
        {
            get
            {
                return this._users_add_addresses_app;
            }
            set
            {
                this._users_add_addresses_app = value;
            }
        }

        public string users_add_addresses_dept
        {
            get
            {
                return this._users_add_addresses_dept;
            }
            set
            {
                this._users_add_addresses_dept = value;
            }
        }

        public string users_add_addresses_user
        {
            get
            {
                return this._users_add_addresses_user;
            }
            set
            {
                this._users_add_addresses_user = value;
            }
        }

        public string users_addNew_addresses_NotSaved_AllUser
        {
            get
            {
                return this._users_addNew_addresses_NotSaved_AllUser;
            }
            set
            {
                this._users_addNew_addresses_NotSaved_AllUser = value;
            }
        }

        public string users_addNew_addresses_NotSaved_DeptApp
        {
            get
            {
                return this._users_addNew_addresses_NotSaved_DeptApp;
            }
            set
            {
                this._users_addNew_addresses_NotSaved_DeptApp = value;
            }
        }

        public string users_addNew_addresses_NotSaved_MainApp
        {
            get
            {
                return this._users_addNew_addresses_NotSaved_MainApp;
            }
            set
            {
                this._users_addNew_addresses_NotSaved_MainApp = value;
            }
        }

        public string users_change_addresses_app
        {
            get
            {
                return this._users_change_addresses_app;
            }
            set
            {
                this._users_change_addresses_app = value;
            }
        }

        public string users_change_addresses_dept
        {
            get
            {
                return this._users_change_addresses_dept;
            }
            set
            {
                this._users_change_addresses_dept = value;
            }
        }

        public string users_change_addresses_user
        {
            get
            {
                return this._users_change_addresses_user;
            }
            set
            {
                this._users_change_addresses_user = value;
            }
        }

        public string users_edit_addresses_app
        {
            get
            {
                return this._users_edit_addresses_app;
            }
            set
            {
                this._users_edit_addresses_app = value;
            }
        }

        public string users_edit_addresses_dept
        {
            get
            {
                return this._users_edit_addresses_dept;
            }
            set
            {
                this._users_edit_addresses_dept = value;
            }
        }

        public string users_edit_addresses_user
        {
            get
            {
                return this._users_edit_addresses_user;
            }
            set
            {
                this._users_edit_addresses_user = value;
            }
        }

        // save new address
        public string users_new_add_addresses_app
        {
            get
            {
                return this._users_new_add_addresses_app;
            }
            set
            {
                this._users_new_add_addresses_app = value;
            }
        }

        public string users_new_add_addresses_dept
        {
            get
            {
                return this._users_new_add_addresses_dept;
            }
            set
            {
                this._users_new_add_addresses_dept = value;
            }
        }

        public string users_new_add_addresses_user
        {
            get
            {
                return this._users_new_add_addresses_user;
            }
            set
            {
                this._users_new_add_addresses_user = value;
            }
        }

        public string users_select_addresses_app
        {
            get
            {
                return this._users_select_addresses_app;
            }
            set
            {
                this._users_select_addresses_app = value;
            }
        }

        public string users_select_addresses_dept
        {
            get
            {
                return this._users_select_addresses_dept;
            }
            set
            {
                this._users_select_addresses_dept = value;
            }
        }

        public string users_select_addresses_user
        {
            get
            {
                return this._users_select_addresses_user;
            }
            set
            {
                this._users_select_addresses_user = value;
            }
        }

        public string users_select_Department_address_AllUser
        {
            get
            {
                return this._users_select_Department_address_AllUser;
            }
            set
            {
                this._users_select_Department_address_AllUser = value;
            }
        }

        public string users_select_Department_address_DeptApp
        {
            get
            {
                return this._users_select_Department_address_DeptApp;
            }
            set
            {
                this._users_select_Department_address_DeptApp = value;
            }
        }

        public string users_select_Department_address_MainApp
        {
            get
            {
                return this._users_select_Department_address_MainApp;
            }
            set
            {
                this._users_select_Department_address_MainApp = value;
            }
        }

        public bool AttachConsignmentNumberToUrl
        {
            get
            {
                return this._attachConsignmentNumberToUrl;
            }
            set
            {
                this._attachConsignmentNumberToUrl = value;
            }
        }

        public ApprovalSystemItems()
        {
        }
    }
}