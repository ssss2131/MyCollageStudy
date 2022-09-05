using Microsoft.Extensions.Configuration;
using Options;

var position = @"D:\.net\OptionMode\Options";
var configuration = new ConfigurationBuilder().SetBasePath(position).AddJsonFile("My.json");
var config = configuration.Build();
Console.WriteLine(config["Test"]);

optionsClass options = new optionsClass();
