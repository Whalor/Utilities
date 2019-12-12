using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour

//This is an example of how to break apart a sentence to figure out each word in the sentence it will print it out in the console word by word
//The first string is a simple sentence it can be anything
    string phrase = "The quick brown fox jumps over the lazy dog.";
//This string is an array named words that takes the previous sentence named phrase and uses the split command to add each word to the array by finding each
//string instane of the ' ' (space) in the sentence, thus splitting the sentence up at each space making a new string for each value.
//Note: additional instances of the ' ' (space) character will add more characters to the array, because it is only splitting based on where the spaces are
    string[] words = phrase.Split(' ');
//This is a foreach loop declares that it is going to run for each var word in the array words that was delcared earlier so it will run this next line of code for each 
//word that was in the original sentence
foreach (var word in words)
{
    //This simply writes the var word to the console each time the loop runs so it will eventually individually write each word in the sentence.
    System.Console.WriteLine($"<{word}>");
}

//Below is another example to break apart a string using something called delimiters
//You first declare a string naming it delimiterChars and make it an array of strings
char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
//Below is a string that uses a multitude of different things to seperate the words from eachother like spaces and colons and commas
//Note: any consecutive uses of a deliminator will produce an empty string.
string text = "one\ttwo three:four,five six seven";
System.Console.WriteLine($"Original text: '{text}'");
//This array named words is made up of the text string split at the delimiters of the array we just declared earlier in the code
string[] words = text.Split(delimiterChars);
//This console write takes the length of the array we created and writes it in the console to check and make sure it recgonizes the correct amount of words in the string
System.Console.WriteLine($"{words.Length} words in text:");
//This is a foreach loop declares that it is going to run for each var word in the array words that was delcared earlier so it will run this next line of code for each 
//word that was in the original sentence
foreach (var word in words)
{
    System.Console.WriteLine($"<{word}>");
}

//Below is another example of how to break apart strings this one uses the option of substrings
//We first create an array naming it and then chose full strings to add to the array not just simple characters the difference is between ' ' and " "
string[] separatingStrings = { "<<", "..." };
//Next we need a string to break apart as we can see there are multiple different strings in them, but also a character
string text = "one<<two......three<four";
//This simply writes the original text to the console
System.Console.WriteLine($"Original text: '{text}'");
//Next we create a new variable named words and break apart the text using the split command this line goes a little more in depth adding some parameters to the split
//command it choses to sperate strings and tells the system to remove all empty entries meaning we wont have to worry about the code thinking that two deliminators
//right next to each other are actually holding a word in between them if that space is empty
string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
//We then tell the system to write to the console the length of the words array
System.Console.WriteLine($"{words.Length} substrings in text:");
//This for each loop is the same as the ones above you it simply writes to the console each string variable named word in the array we created called words.
foreach (var word in words)
{
    System.Console.WriteLine(word);
}

using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        string[] values = { "1,304.16", "$1,456.78", "1,094", "152",
                          "123,45 €", "1 304,16", "Ae9f" };
        double number;
        CultureInfo culture = null;

        foreach (string value in values)
        {
            try
            {
                culture = CultureInfo.CreateSpecificCulture("en-US");
                number = Double.Parse(value, culture);
                Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0}: Unable to parse '{1}'.",
                                  culture.Name, value);
                culture = CultureInfo.CreateSpecificCulture("fr-FR");
                try
                {
                    number = Double.Parse(value, culture);
                    Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}: Unable to parse '{1}'.",
                                      culture.Name, value);
                }
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//    en-US: 1,304.16 --> 1304.16
//    
//    en-US: Unable to parse '$1,456.78'.
//    fr-FR: Unable to parse '$1,456.78'.
//    
//    en-US: 1,094 --> 1094
//    
//    en-US: 152 --> 152
//    
//    en-US: Unable to parse '123,45 €'.
//    fr-FR: Unable to parse '123,45 €'.
//    
//    en-US: Unable to parse '1 304,16'.
//    fr-FR: 1 304,16 --> 1304.16
//    
//    en-US: Unable to parse 'Ae9f'.
//    fr-FR: Unable to parse 'Ae9f'.

//This function is used to change the state of something when called I currently have it simply make different Gameobjects active or not based on what state you are in, but This could be used for a myraid of things
public void ChangeStates()
{
    if (high == false)
    {
        Debug.Log("High = " + high);

        //Set each gameobject that is in the array normalItems to false
        foreach (GameObject go in normalItems)
        {
            go.SetActive(false);
        }

        //Set each gameobject that is in the array highItems to true
        foreach (GameObject go in highItems)
        {
            go.SetActive(true);
        }

        high = true;
    }
    else if (high == true)
    {
        Debug.Log("High = " + high);

        //Set each gameobject that is in the array highItems to false
        foreach (GameObject go in highItems)
        {
            go.SetActive(false);
        }

        //Set each gameobject that is in the array normalItems to true
        foreach (GameObject go in normalItems)
        {
            go.SetActive(true);
        }

        high = false;
    }
}
