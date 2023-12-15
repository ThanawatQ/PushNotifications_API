using Lib.Net.Http.WebPush;

namespace Demo.AspNetCore.PushNotifications.Model
{
    public class PushMessageViewModel
    {
        public string Title { get; set; }   
        public string Topic { get; set; }
        public string Notification { get; set; }
        public string icon { get; set; }

        public PushMessageUrgency Urgency { get; set; } = PushMessageUrgency.Normal;
        public Action action { get; set; }
    }
    public class Action
    {   
        public string action { get; set; }
        public string title { get; set; }
        public string Url { get; set; }

    }


}
