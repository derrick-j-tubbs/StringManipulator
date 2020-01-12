using System;
using System.Collections.Generic;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            StringManipulator stringManipulator = new StringManipulator();
            
            //the initial test cases I did to ensure my reverse, truncate, and concat functions were working properly.
            /*Console.WriteLine(stringManipulator.reverseString("Reversed."));
            Console.WriteLine(stringManipulator.truncateString("Truncated."));
            Console.WriteLine(stringManipulator.makeUppercase("UpPeRcase"));
            Console.WriteLine(stringManipulator.concatenateString("No follow-"));
            Console.WriteLine(stringManipulator.concatenateString("Follow-", "up"));*/

            List<string> stringList = new List<string>();
            stringList.Add("I am a bad string");
            stringList.Add("This string is reversed.");
            stringList.Add("String is cut off at 5...");
            stringList.Add("This string needs -");
            stringList.Add("an additional string.");
            stringList.Add("uPpERcase");
            stringList.Add("reversed and trimmed");
            stringList.Add("reversed and made cApPeD");
            stringList.Add("- dna tacnoc");
            stringList.Add("reverse");
            stringList.Add("This string will be reverse, concatted, and capped hopeFulLY");
            stringList.Add("this string will be.. reversed, truncated, and concaten-ated");
            stringList.Add("was it?");
            stringList.Add("ShOrTupper");
            stringList.Add("Conc-atenate me");
            stringList.Add(" I did");
            stringList.Add("CoNC-atenate me");
            stringList.Add(" I did");
            stringList.Add("ThIS string should be -");
            stringList.Add("all uppercase");
            stringList.Add("This string will subjected to reverse, concat, and trun-CaTE");
            stringList.Add(" See?");
            stringList.Add("This string shouldn't throw an error-");
            stringManipulator.ManipulateString(stringList);
            stringManipulator.stringReport();
        }
    }
}
