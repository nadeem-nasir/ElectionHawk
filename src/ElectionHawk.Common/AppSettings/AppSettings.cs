using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.AppSettings
{

    public interface IAppSettings
    {

    }
    public class AppSettings : IAppSettings
    {
        public BaseUrls BaseUrls { get; set; }
        public DataBaseSettings DataBaseSettings { get; set; }
        public AppClient AppClient { get; set; }
        public JWTSettings JWTSettings { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public PushNotification PushNotification { get; set; }
    }


    public class BaseUrls
    {
        public string Api { get; set; }
        public string Auth { get; set; }
        public string Web { get; set; }
    }

    public class DataBaseSettings
    {
        public string ConnectionString { get; set; }
        //public string TestConnectionString { get; set; }
        //public string ProductionConnectionString { get; set; }

    }

    public class AppClient
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }

    public class JWTSettings
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

        public TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(1);
        public string TokenType { get; } = "bearer";
    }

    public class EmailSettings
    {

        public String PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        public String SecondayDomain { get; set; }

        public int SecondaryPort { get; set; }

        public String UsernameEmail { get; set; }

        public String UsernamePassword { get; set; }

        public String FromEmail { get; set; }

        public String ToEmail { get; set; }

        public String CcEmail { get; set; }
    }

    public class PushNotification
    {
        public FirebaseCloudMessaging FirebaseCloudMessaging { get; set; }
    }

    public class FirebaseCloudMessaging
    {
        public string WebAPIKey { get; set; }
        public string ServerKey { get; set; }
        public string SenderID { get; set; }
    }
}

