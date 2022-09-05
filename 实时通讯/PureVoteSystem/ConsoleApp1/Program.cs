var time = DateTime.Now.AddDays(2);
var time2 = DateTime.Now;

var time3 = (int)(time - time2).TotalSeconds;
Console.WriteLine(time3);