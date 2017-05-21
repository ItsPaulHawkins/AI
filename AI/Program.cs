using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFullLine("Alec: Hello! I'm Alec, your personal assistant.");
            while (true)
            {
                WriteFullLine("Please state a command");
                string input = Console.ReadLine();
                string[] splitInput = input.Split(' ');
                if(input == "quit")
                {
                    Environment.Exit(0);
                }
                bool foundImage = false;
                int Length = splitInput.Length;
                int placeImage = 0;
                if(input == "send a text" || input == "Send a text")
                {
                    WriteFullLine("Okay! What number would you like to send a text to?");
                    string number = Console.ReadLine();
                    WriteFullLine("What would you like to say?");
                    string message = Console.ReadLine();
                    const string accountSid = "AC7a919eb1e364cc44672b37ded7347405";
                    const string authToken = "8e687039f4f2f7006f918fccd0e1d775";
                    TwilioClient.Init(accountSid, authToken);
                    MessageResource.Create(
                    from: new PhoneNumber("323-614-0538"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber(number), // To number, if using Sandbox see note above
                    // Message content
                    body: $"" + message);
                    WriteFullLine("Message Sent!");
                    Console.WriteLine(" ");
                    Main(null);


                }
                {

                }
                while (foundImage == false)
                {
                    if (splitInput[placeImage] == "images" || splitInput[placeImage] == "image" || splitInput[placeImage] == "Image" || splitInput[placeImage] == "Images" || splitInput[placeImage] == "picture" || splitInput[placeImage] == "pictures" || splitInput[placeImage] == "Pictures" || splitInput[placeImage] == "picture")
                    {

                        string image = splitInput[placeImage + 2];
                        WriteFullLine("Showing images of " + image);
                        Sleep(1);
                        System.Diagnostics.Process.Start("https://www.google.com/search?site=imghp&tbm=isch&source=hp&biw=1680&bih=871&q=" + image);
                        foundImage = true;
                        Main(null);
                    }
                    else
                    {
                        if (placeImage < Length - 1)
                        {
                            placeImage++;
                        }
                        else
                        {
                            foundImage = true;
                        }

                    }
                }
                bool foundWiki = false;
                int placeWiki = 0;
                int searchInt;
                string wikiSearch = "";
                while (foundWiki == false)
                {
                    if (placeWiki < splitInput.Length)
                    {
                        if (splitInput[placeWiki] == "what" || splitInput[placeWiki] == "What")
                        {
                            searchInt = placeWiki + 3;
                            while (searchInt <= Length - 1)
                            {
                                wikiSearch += " " + splitInput[searchInt];
                                searchInt++;
                            }

                            wikipedia(wikiSearch);
                            foundWiki = true;
                        }
                    }
                    else
                    {
                        if (placeWiki < Length)
                        {
                            placeWiki++;
                        }
                        else
                        {
                            foundWiki = true;
                        }
                    }
                }

            }
        }
        public static void Sleep(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
        public static string wikipedia(string query)
        {
            var webclient = new WebClient();
            query = query.Replace(" ", "+");
            query = "http://en.wikipedia.com/w/api.php?format=xml&action=query&prop=extracts&titles=" + query + "&redirects=true";
            query = query.Remove(79, 1);
            var pageSourceCode = webclient.DownloadString(query);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(pageSourceCode);
            var fnode = doc.GetElementsByTagName("extract")[0];
                string ss = fnode.InnerText;
                Regex regex = new Regex("\\<[^\\>]*\\>");
                string.Format("Before:{0}", ss);
                ss = regex.Replace(ss, String.Empty);

            WriteFullLine(ss);
            Console.WriteLine();


            return query;
        }
        static void WriteFullLine(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
                                                                        //
                                                                        // Reset the color.
                                                                        //
            Console.ResetColor();
        }
    }
}
