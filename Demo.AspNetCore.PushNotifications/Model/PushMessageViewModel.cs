using Lib.Net.Http.WebPush;
using System.Collections.Generic;

namespace Demo.AspNetCore.PushNotifications.Model
{
    public class PushMessageViewModel
    {
        public string Notification { get; set; }
        public PushMessageUrgency Urgency { get; set; } = PushMessageUrgency.Normal;
        public string icon { get; set; }

        public string Title { get; set; }   

        public List<data> data { get; set; }
        public List<Action> action { get; set; }
    }
    public class data
    {
        public string url { get; set; }

        public string type { get; set; } = "openlink";   // 

    }
    public class Action
    {
        public string action { get; set; }
        public string title { get; set; }

    }


}
