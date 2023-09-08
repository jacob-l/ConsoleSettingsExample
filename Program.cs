
var keyName = "lastLaunchTime";

var lastLaunchTime = AppSettings.Instance.GetValue(keyName);
Console.WriteLine("Last Launch Time - " + lastLaunchTime);

AppSettings.Instance.SaveValue(keyName, System.DateTime.Now.ToString("o"));