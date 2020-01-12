using System;
using System.Collections.Generic;


namespace StringManipulator
{
    class StringManipulator
    {
        // These are member variables for the String Manipulator class, used for collecting the total number of input and output 
        // characters, and for calculating the median value.
        private List<int> stringLengths = new List<int>();
        private int totalInputCharacters = 0;
        private int totalOutputCharacters = 0;
        private float medianCharacterCount = 0;
        

        // this is where all the logic happens to determine which function is called when. Using the Modulo operator you can determine
        // easily if something is a multiple of any number. I made the assumption that if something is a multiple of 20 it should be 
        // reversed first and then trimmed because that was the order the instructions were given in.

        // I wanted to make a recursive function to continually concatenate strings until they stopped ending with a '-' however I ran
        // out of time to complete that task within the hour.

        // I decided to put the converstion to uppercase after all other string manipulations, because if the first string was 
        // converted and then concatenated, the remaining characcters from the second string retained their casing and I thought this 
        // looked wrong.
        public void ManipulateString(List<string> strings) {
            
            for (int i = 0; i < strings.Count; i++) {
                var manipulatedString = strings[i];
                incrementInputCharacterCount(manipulatedString.Length);
                addCharacterCountToList(manipulatedString.Length);
                if (manipulatedString.Length != 0) {
                    if (manipulatedString.Length % 4 == 0) {
                        manipulatedString = reverseString(manipulatedString);
                    }
                    if (manipulatedString.Length % 5 == 0) {
                        manipulatedString = truncateString(manipulatedString);
                    }
                    if (manipulatedString[manipulatedString.Length - 1] == '-') {
                        manipulatedString = manipulatedString.Substring(0, manipulatedString.Length-1);
                        if (i + 1 > strings.Count - 1) {
                            manipulatedString = concatenateString(manipulatedString);
                        } else {
                            manipulatedString = concatenateString(manipulatedString, strings[i+1]);
                        }
                    }
                    manipulatedString = makeUppercase(manipulatedString);
                }
                incrementOutputCharacterCount(manipulatedString.Length);
                addCharacterCountToList(manipulatedString.Length);
                Console.WriteLine(manipulatedString);
            }
        }

        // Using a queue you can easily reverse a string with O(n) time and memory complexity. Since stacks work in a FILO manner, 
        // simply pushing the array of characters into the stack and popping them out of the stack reversed the order of the string.
        public string reverseString(string inputString) {
            int stringLength = inputString.Length;
            char[] charString = inputString.ToCharArray();
            Stack<char> charStack = new Stack<char>();
            for (int i = 0; i < charString.Length; i++) {
                charStack.Push(charString[i]);
            } 
            for (int i = 0; i < stringLength; i++) {
                charString[i] = charStack.Pop();
            }
            string reversedString = new string(charString);
            return reversedString;
        }

        // The easiest way I could think of to truncate a string was using substrings. Just start at index 0, and give it a length of 
        // 5, and it will return the first 5 characters of the string.
        public string truncateString(string inputString) {
            return inputString.Substring(0, 5);
        }

        public string makeUppercase(string inputString) {
            int upperCount = 0;
            if (inputString.Length < 5) {
                for (int i = 0; i < inputString.Length; i++) {
                    upperCount += checkUpper(inputString[i]);
                }
            } else {
                for (int i = 0; i < 5; i++) {
                    upperCount += checkUpper(inputString[i]);
                }
            }
            if (upperCount >= 3) {
                return inputString.ToUpper();
            }
            return inputString;
        }

        // I wanted to have this return an error message for strings that didn't have a follow up partner, but this was artificially 
        // inflating the number of output characters. The proper solution would be to throw/catch an error and return an error message // instead. I didn't have time to revisit this once I noticed this falw in the design. An example of the error message is 
        // included
        public string concatenateString(string inputString, string nextString = "") {
            if (nextString == "") {
                //return $"The string: \"{inputString}\" ended in a '-' but did not have a following string to concatenate";
                return inputString;
            }
            return $"{inputString}{nextString}";
        }

        // a function used to report statistics of the strings input and ouput from this manipulator.
        public void stringReport() {
            calculateMedian(stringLengths);
            Console.WriteLine($"Total number of input characters: {totalInputCharacters}");
            Console.WriteLine($"Total number of output characters: {totalOutputCharacters}");
            Console.WriteLine($"Median string character count: {medianCharacterCount}");
        }

        // These functions exist to make it more clear what is happening within the Manipulate String function and make that function 
        // easier to read. Since these are void functions that do a single task, there is very little overhead associated with them.
        private void incrementInputCharacterCount(int stringLength) {
            totalInputCharacters += stringLength;
        }
        private void incrementOutputCharacterCount(int stringLength) {
            totalOutputCharacters += stringLength;
        }

        private void addCharacterCountToList(int stringLength) {
            stringLengths.Add(stringLength);
        }

        // Moved this check out of makeUppercase() to reduce code duplication
        private int checkUpper(char character) {
            if (Char.IsUpper(character)) {
                return 1;
            }
            return 0;
        }
        // Since we are always measuring both input and output size of the array will always be 2n which is always even.
        // as a result, we don't need to check here to see if this array is even or odd for determining the median of the array.
        // If there is an error that causes only one portion of the strings size to be measured, this would not be an accurate median
        // however, those errors should be eliminated rather than making this function more robust, because they would have other 
        // trickle down effects on the program.
        public void calculateMedian (List<int> characterCounts) {
            characterCounts.Sort();
            medianCharacterCount = (characterCounts[(characterCounts.Count / 2) - 1] + characterCounts[(characterCounts.Count / 2)]) / 2f;
        }
    }
}