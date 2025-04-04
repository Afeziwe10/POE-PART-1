//Here i'm Importing necessary libraries for various functionalities
using System;               //Importing system library for basic functionalities
using NAudio.Wave;               // Importing NAudio library for handling audio playback
using System.Text.RegularExpressions; //Importiung Regax for validating user input
using System.Collections.Generic;  // Enables dictionary and list usage
using System.Threading;  // It Allows adding delays for a typing effect
using System.Speech.Synthesis; // Provides text-to-speech functionality
class Program
{
    static void Main()
    {
        //This is a simple Cybersecurity Chatbot designed to provide basic cybersecurity knowledge to users

        // It helps users understand common cybersecurity topics like password security, phishing, firewalls, and more.

        // Define the file path for the audio
         string filePath = @"C:\Users\Afeziwe\Documents\PROG 6221 Assignment\POE PART 1\POE PART 1\audio\myAudio.wav";
        
        // Try-Catch Block is used for error handling:
        /*
         * The AudioFileReader loads the audio file
         * The WaveOutEvent initialize the audio player
         * outputDevice.play() plays the audio
         */
        try
        {
            //Create an audio file reader to read the audio file
            using (var audioFile = new AudioFileReader(filePath))                                                                                                     

            // Create Output device for playing audio
            using (var outputDevice = new WaveOutEvent())
            {
                //Initialize the audio output device with the audio file 
                outputDevice.Init(audioFile);
                //play the audio
                outputDevice.Play(); 

                // Set text color to be yellow and output display playing message
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Audio is playing... press any key to continue");
                Console.ReadKey();     // waits for user to press a key

            }

        }
        catch (Exception ex)          //Catch any exception that occur during the execution
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + ex.Message);  // Dispaly error message
            Console.ResetColor();  // Reset console color to default
        }

        //My Cybersecurity image by ASCII, the color is changed to DarkCyan
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(@"
    ______   ________  ________  ________         ______   __      __  _______   ________  _______  
 /      \ /        |/        |/        |       /      \ /  \    /  |/       \ /        |/       \ 
/$$$$$$  |$$$$$$$$/ $$$$$$$$/ $$$$$$$$/       /$$$$$$  |$$  \  /$$/ $$$$$$$  |$$$$$$$$/ $$$$$$$  |
$$ |__$$ |$$ |__    $$ |__        /$$/        $$ |  $$/  $$  \/$$/  $$ |__$$ |$$ |__    $$ |__$$ |
$$    $$ |$$    |   $$    |      /$$/         $$ |        $$  $$/   $$    $$< $$    |   $$    $$< 
$$$$$$$$ |$$$$$/    $$$$$/      /$$/          $$ |   __    $$$$/    $$$$$$$  |$$$$$/    $$$$$$$  |
$$ |  $$ |$$ |      $$ |_____  /$$/____       $$ \__/  |    $$ |    $$ |__$$ |$$ |_____ $$ |  $$ |
$$ |  $$ |$$ |      $$       |/$$      |      $$    $$/     $$ |    $$    $$/ $$       |$$ |  $$ |
$$/   $$/ $$/       $$$$$$$$/ $$$$$$$$/        $$$$$$/      $$/     $$$$$$$/  $$$$$$$$/ $$/   $$/");
        Console.ResetColor();

        //Slogan Message
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Be A Genius Online!!!!");
        Console.ResetColor();

        //declare username variable
        string username;
        bool allowingHyphenUser = false;

        // I'm asking the user if they have hyphen in their name, because some people have hyphen in their name, so that my program can take those people
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Does your name contain hyphen? '-': (yes/no)");
        Console.ResetColor();

        Console.ForegroundColor= ConsoleColor.Magenta;
        String responseForHyphen = Console.ReadLine().ToLower().ToLower();
        Console.ResetColor();
        if (responseForHyphen == "yes")
        {
            allowingHyphenUser |= true; 
        }

        do
        {
            //Ask the user to enter their name
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nEnter your name");
            username = Console.ReadLine();
            Console.ResetColor();

            //validate hyphen pattern based on user 
            String hayphenPattern = allowingHyphenUser ? @"^[a-zA-Z0-9\-]+$" : @"^[a-zA-Z0-9]+$";
            //Validate user input which cannot be empty or contain special characters
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, hayphenPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Name can not be empty or ensure that name does not include characters ");
                Console.ResetColor();
            }
            else if (allowingHyphenUser && !username.Contains('-'))
            {
                //if the user said yes but did not include one
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("ERROR: You said your name contain hyphen. Please enter your name again");
                Console.ResetColor();
            }
            else
            {
                break;
            }
        } while (true);

        //Display welcome message with the entered username
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome " + username + ": " + "let's Talk About Cybersecurity");
        Console.ResetColor();

        //Display my chatbot instruction by ASCII
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"
 /~______________________________________________________________________~\ 
 .----------------------------------------------------------------------. 
                      Welcome to the cybersecurity bot!
                     Ask me anything related in security
                See the topics by pressing 't' on your keyboard
                           Type 'exit' to leave 
 '-----------------------------------------------------------------------' 
 \_~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~_/ ");
          Console.ResetColor();

        //Defining new dictionary with predefined responses
        Dictionary<string, string> responses = new Dictionary<string, string>
        {
            {"password", "A strong password should have atleast 12 long, and also include symbols, numbers, upper case, and lower case. You may use a password manager to store them securely." },
            {"phishing", "phishing is a scam where attackers  trick you into providing sensitive information. Always verify links and sender details." },
            {"firewall", "A firewall  protect your network by blocking unauthorized access and filtering traffic." },
            {"vpn", "A VPN encrypts your internet traffic, keeping your data  safe and private from hackers." },
            {"ransomware", "Ransomware locks your files and demands payment. Always bach up your data and avoid suspicious emails." },
            {"social engineering", "Its when attackers manipulate people into revealing confiidential information, often using psychological tricks." },
            {"data breach", "It usually happens when sensitive information is exposed. Use strong password and enale two-factor authentication, know as (2FA)." },
            {"cybersecurity", "Cybersecurity is a practice of protecting systems, networks, and data from cyber threats and attacks." },
            {"dns", "(Domain Name System) translates website domain names into IP address, allowig users to access the website smoothly." },
            {"malware", "Malware spread through email attachments, malicious websites, USB drives, Software downloads, and phishing attacks." }

        };

        //List of default responses for unrecognized questiona
        List<string> defaultResponse = new List<string>
        {
            "Hmm.... I don't have an answer for that. Try asking something related to cybersecurity",
            "Good question! But I may need more details.",
            "That's a tricky one! Maybe try rephrasing it?",
            "Cybersecurity is a braod topic! Could you be more specific please"
        };

        Random random = new Random();

        SpeechSynthesizer mySynth = new SpeechSynthesizer();    //Voice object


        //Infinite loop for chatbot interaction
        while (true)
        {
            Console.WriteLine("\nYou: " + username);
            //Get user input for question
            Console.ForegroundColor= ConsoleColor.Magenta;
            string question = Console.ReadLine().ToLower().Trim();
            Console.ResetColor();
            /*Reason:
             * The chatbot  needs to keep running until the user decides to exit
             * Without this loop, the chatbot would end immediately after one response instead of allowing multiple questions.
             * The only way to exit is when the user types "exit", which ensures a smooth conversation
             */

            //Check if the user wants to exit the chatbot
            if (question == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Green;
              foreach(char c in "Goodbyee! Be Carefull online ")
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                mySynth.Speak("Goodbye! Be Carefull online");
                Console.ResetColor();
                break;
            }
            
            if (question == "t")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                foreach (char c in "Want to se my topics? Surely!!! My Topics Include: \nCybersecurity,  Phishing, dns, data breach, social engineering, vpn, ransomware, firewall, password, malware")
                {
                    Console.Write(c);
                    Thread.Sleep(50);   
                }
                Console.WriteLine();
                Console.ResetColor();
                continue;
            }
            //Default response if no relevant answer is found
            string response = defaultResponse[random.Next(defaultResponse.Count)];

            //Loop through predefined responses and find a match
            foreach(var key in responses.Keys)
            {
                if (question.Contains(key))
                {
                    response = responses[key];
                    break;  
                }
            }
            /*Reason:
             * This loop scans all the keywords in the predefined dictionary
             * If a user's input contain matching cybersecurity term, the bot selects the correct answer
             * This make the chatbot smarter instead of just giving random responses.
             */

            //Display chatbot response
            Console.ForegroundColor= ConsoleColor.Yellow;
            foreach(char c in response)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            /*Reason:
             * Instead of instantly printing the whole response, this loop prints character by character to simulate real chatbot typing
             * the Thread.Sleep(50) delay makes it look smoother and more interactive
             * It improves user experiance by making the bot feel more realistic and engaging.
             */
            Console.WriteLine();  
            Console.ResetColor();
        }
    }
}