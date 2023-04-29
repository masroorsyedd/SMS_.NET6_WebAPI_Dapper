using Microsoft.Extensions.Configuration;
using TechSol.StudentManagementSystem.Utility.Exceptions;


namespace TechSol.StudentManagementSystem.Utility.Configuration
{
    public class AppSettings
    {
        private static IConfiguration Configuration;
        public static void IntializeConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static string ConnectionString
        {
            get
            {
                if (Configuration["ConnectionStrings:SQLConnection"] == null || string.IsNullOrWhiteSpace(Configuration["ConnectionStrings:SQLConnection"]))
                    throw new AppException("SQL Connectionstring is not valid in AppSettings file");

                return Configuration["ConnectionStrings:SQLConnection"];
            }
        }

        public static string SentryKey
        {
            get
            {
                if (Configuration["SentryConfig:Key"] == null || string.IsNullOrWhiteSpace(Configuration["SentryConfig:Key"]))
                    throw new AppException("Sentry Config Key is not valid in AppSettings file");

                return Configuration["SentryConfig:Key"];
            }
        }

        public static string SerilogSeqURL
        {
            get
            {
                if (Configuration["Serilog:SeqServerUrl"] == null || string.IsNullOrWhiteSpace(Configuration["Serilog:SeqServerUrl"]))
                    throw new AppException("Serilog Seq Server URL is not valid in AppSettings file");

                return Configuration["Serilog:SeqServerUrl"];
            }
        }

        public static String GoogleClientId
        {
            get
            {

                return Configuration["GoogleAPI:ClientId"];

            }

        }

        public static String GoogleAppName
        {
            get
            {

                return Configuration["GoogleAPI: AppName"];

            }

        }

        public static String TwilioAccountId
        {
            get {

                return Configuration["Twilio:AccountSid"];
            
            }
        
        }

        public static String TwilioAuthToken
        {
            get {

                return Configuration["Twilio:authToken"];
            
            }
        
        }

        public static String GoogleClientSecret
        {
            get
            {

                return Configuration["GoogleAPI:ClientSecret"];

            }

        }

        public static string[] GoogleScopes
        {
            get
            {

                if (Configuration["GoogleAPI:Scopes"] == null)
                    throw new Exception("Google Scopes are not present in configurtaion");

                String[] values = Configuration["GoogleAPI:Scopes"].Split(',');
                for (int i = 0; i < values.Length; i++)
                {

                    values[i] = values[i].Trim(new char[] { '[', ']' });

                }

                return values;

            }


        }
        public static string LoggingFilePath
        {
            get
            {
                if (Configuration["Serilog:FilePath"] == null || string.IsNullOrWhiteSpace(Configuration["Serilog:FilePath"]))
                    throw new AppException("Serilog Logging File Path is not valid in AppSettings file");

                return Configuration["Serilog:FilePath"];
            }
        }

        public static DateTime TokenExpirationInSeconds
        {
            get
            {
                double tokenExpiryInSeconds = 0;
                if (Configuration["ApplicationSettings:TokenExpiry"] == null || !double.TryParse(Configuration["ApplicationSettings:TokenExpiry"], out tokenExpiryInSeconds))
                    throw new AppException("Token Expiry is not valid in AppSettings file");

                return DateTime.UtcNow.AddMinutes(tokenExpiryInSeconds);
            }
        }

        public static string MailchimpMarketingApiKey
        {
            get
            {
                if (Configuration["MailchimpSettings:MarketingApiKey"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:MarketingApiKey"]))
                    throw new AppException("Mailchimp Marketing API Key is not valid in AppSettings file");

                return Configuration["MailchimpSettings:MarketingApiKey"];
            }
        }

        public static string MailchimpTransactionalApiKey
        {
            get
            {
                if (Configuration["MailchimpSettings:TransactionalApiKey"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:TransactionalApiKey"]))
                    throw new AppException("Mailchimp Transactional API Key is not valid in AppSettings file");

                return Configuration["MailchimpSettings:TransactionalApiKey"];
            }
        }

        public static string MailchimpDefaultEmail
        {
            get
            {
                if (Configuration["MailchimpSettings:DefaultEmail"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:DefaultEmail"]))
                    throw new AppException("Mailchimp Default Email is not valid in AppSettings file");

                return Configuration["MailchimpSettings:DefaultEmail"];
            }
        }

        public static string MailchimpSenderDisplayName
        {
            get
            {
                if (Configuration["MailchimpSettings:SenderDisplayName"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:SenderDisplayName"]))
                    throw new AppException("Mailchimp Sender's Display Name is not valid in AppSettings file");

                return Configuration["MailchimpSettings:SenderDisplayName"];
            }
        }

        public static string TransactionalApiBaseUrl
        {
            get
            {
                if (Configuration["MailchimpSettings:TransactionalApiBaseUrl"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:TransactionalApiBaseUrl"]))
                    throw new AppException("Transactional API BaseUrl is not valid in AppSettings file");

                return Configuration["MailchimpSettings:TransactionalApiBaseUrl"];
            }
        }

        public static string ADotNetApiLoginID
        {
            get
            {
                if (Configuration["ADotNetSettings:ApiLoginID"] == null || string.IsNullOrWhiteSpace(Configuration["ADotNetSettings:ApiLoginID"]))
                    throw new AppException("Authorize.NET API Login ID is not valid in AppSettings file");

                return Configuration["ADotNetSettings:ApiLoginID"];
            }
        }

        public static string ADotNetTransactionKey
        {
            get
            {
                if (Configuration["ADotNetSettings:TransactionKey"] == null || string.IsNullOrWhiteSpace(Configuration["ADotNetSettings:TransactionKey"]))
                    throw new AppException("Authorize.NET API Transaction Key is not valid in AppSettings file");

                return Configuration["ADotNetSettings:TransactionKey"];
            }
        }


    }

}
