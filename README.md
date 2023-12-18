>#  Install
- Lib.AspNetCore.WebPush
- Lib.Net.Http.WebPush
- Microsoft.AspNetCore.Mvc.NewtonsoftJson Version 6
- Microsoft.EntityFrameworkCore Version 6
- Microsoft.EntityFrameworkCore.Sqlite Version 6

> # HTTPPOST
###  json [HttpPost("notifications")]
- icon สามารถใส่เป็น URL ได้
  

 ```ruby
 {
  "notification": "เนื้อหา",
  "urgency": "Normal",
  "icon":"/images/push-notification-icon.png",
  "Title": "หัวข้อ",
    "data":[
      {
      "url":"https://www.google.com",
      "type":"openlink"
      },
      {
      "url":"https://www.google.com",
      "type":"API"
      }
    ],
   "action":[
    {
      "title":"Open Now"
    },
    {
      "title":"Close Now"
    }
   ]
}
```
  


  
