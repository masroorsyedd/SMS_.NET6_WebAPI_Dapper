using System.ComponentModel;

namespace TechSol.StudentManagementSystem.Utility.Common
{
    public enum HashType : short
    {
        [Description("SHA1CryptoServiceProvider")]
        SHA1 = 0,
        [Description("SHA256Managed")]
        SHA256 = 1,
        [Description("SHA384Managed")]
        SHA384 = 2,
        [Description("SHA512Managed")]
        SHA512 = 3,
        [Description("MD5CryptoServiceProvider")]
        MD5 = 4
    }
  

    public enum TimePeriodName : short
    {
        TODAY = 0,
        YESTERDAY = 1,
        THISWEEK = 2,
        LASTWEEK = 3,
        THISMONTH = 4,
        LASTMONTH = 5,
        THISYEAR = 6,
        LASTYEAR = 7,
        DAYS90 = 8
    }

    public enum UserTypes : short
    {
        SystemAdmin = 1,
        Client = 2,
        API = 3
    }

    public enum Package : short
    {
        Freemium=1,
        Basic = 2,
        Professional = 3
    }

    public enum ServicesAllowance : short
    {
        Freemium = 3,
        Basic = 6,
        Professional = 10
    }

    public enum ContactsAllowance : short
    {
        Freemium = 10,
        Basic = 500,
        Professional = 1000
    }

    public enum BookingsAllowance : short
    {
        Freemium = 10,
        Basic = 500,
        Professional = 1000
    }

    public enum MailchimpEmailTypes : short
    {
        Transactional = 1,
        Marketing = 2,
    }

    public enum UserRoles : short
    {
        Admin = 1,
        Staff = 2
    }

    public enum ProfileStatuses : short
    {
        Active = 1,
        InActive = 2,
        Pending = 3,
    }
   
    public enum DeliveryTypes : short
    {
        FTP = 1,
        SFTP = 2,
        API = 3,
    }


    public enum UIGridAggregationTypes
    {
        [Description("sum")]
        sum = 2,
        [Description("count")]
        count = 4,
        [Description("avg")]
        avg = 8,
        [Description("min")]
        min = 16,
        [Description("max")]
        max = 32
    }

    public enum UIGridTreeAggregationType
    {
        [Description("sum")]
        sum = 1,

        [Description("count")]
        count = 2,

        [Description("avg")]
        avg = 3,

        [Description("min")]
        min = 4,

        [Description("max")]
        max = 5

    }

    public enum PaymentMethodType
    {
        [Description("CreditCard")]
        CreditCard = 1,
        [Description("PaymentLink")]
        PaymentLink = 2,
        [Description("Invoice")]
        Invoice = 3,
    }

    public enum ContactSources { 
    
        Imported_Contact = 0,
        All_Sources = 1,
        Booking = 2,
        Engagement = 3,
        Messenger = 4,
        Website_Contact = 5,
        Direct = 6,
        Google = 7,
        Outlook = 8,
        Quickbooks = 9,
        Reviews = 10,
        Subscriber = 11,
        Thumbtack = 12,
        Payments = 13
    
    }

    public enum PaymentService { 
    
        Authorized_NET = 1,
        Stripe = 2
    
    }

}

