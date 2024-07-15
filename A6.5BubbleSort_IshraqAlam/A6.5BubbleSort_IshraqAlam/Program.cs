//Name: Ishraq Alam
//Date: April 24, 2024
//Title: BubbleSortExercise3IA
//Purpose: To show the user information about grades for students and organize it to display through a menu. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortExercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable Declaration
            string strUser; //Yogurt Container 
            int intNumberOfStudents; //The number of students that the user wants to enter originally 
            string[] strOriginalLastName; //Unsorted last names array
            string[] strOriginalFirstName; //Unsorted first names array
            int[] intGrade; //Unsorted grades array 
            string[] strSortedLastName; //Sorted last names array 
            string[] strSortedFirstName; //Sorted first names array 
            int[] intSortedGrade; //Sorted grades array 
            string[] strTempDeletedFirstName; //Temporary first names for deleting 
            string[] strTempDeletedLastName; //Temporary last names for deleting 
            int[] intTempDeletedGrade; //Temporary grade for deleting 
            string[] strTempAddedFirstName; //Temporary first name array for adding 
            string[] strTempAddedLastName; //Temporary last name array for adding 
            int[] intTempAddedGrade; //Temporary grade array for adding 
            string strLastName; //Used whenever user enters a last name 
            string strFirstName; //Used whenever user enters a first name 
            int intEnteredGrade; //Used whenever user enters a grade 
            int intMenuOption; //The option from menu user chooses 
            string strTempFirstName; //Used when sorting 
            string strTempLastName; //Used when sorting 
            int intTempGrade; //Used when sorting 
            int intDeletedStudent; //Location of deleted student 
            int intSum = 0; //Used for average calc 
            double dblAverage = 0; //Used to calc average 
            int intMedianLocation; //Finds median average 
            double dblMedian; //If there are 2 medians 


            //Input
            while (true)
            {
                Console.WriteLine("How many students would you like to enter"); //User enters number of students they want to add 
                strUser = Console.ReadLine();
                intNumberOfStudents = Int32.Parse(strUser);





                //Process
                if (intNumberOfStudents > 0) //If user enters a number above 0
                {
                    //Sets size of array for all unsorted arrays 
                    strOriginalLastName = new string[intNumberOfStudents];
                    strOriginalFirstName = new string[intNumberOfStudents];
                    intGrade = new int[strOriginalFirstName.Length];


                    //User enters the first & last names, and grades of students 
                    for (int i = 0; i < strOriginalFirstName.Length; i++)
                    {
                        Console.WriteLine("Please enter the last name of student " + (i + 1) + ": "); //enters last name 
                        strUser = Console.ReadLine();
                        strLastName = strUser;

                        strOriginalLastName[i] = strLastName; //changes location value of array 


                        Console.WriteLine("Please enter the first name of student " + (i + 1) + ": "); //enters first name 
                        strUser = Console.ReadLine();
                        strFirstName = strUser;

                        strOriginalFirstName[i] = strFirstName; //changes location value of array 


                        Console.WriteLine("Please enter " + strFirstName + " " + strLastName + "'s grade: "); //enters grade
                        strUser = Console.ReadLine();
                        intEnteredGrade = Int32.Parse(strUser);

                        intGrade[i] = intEnteredGrade; //changes location value of array 


                    }



                    //Menu
                    while (true) //infinite loop until user exits menu 
                    {
                        //Menu options 
                        Console.Clear(); //cleaner output with clear 
                        Console.WriteLine("What would you like to do from the menu? Please enter the corresponding number.");
                        Console.WriteLine(" ");
                        Console.WriteLine("1. Show original unsorted list");
                        Console.WriteLine("2. Show sorted list by last name (A-Z)");
                        Console.WriteLine("3. Show sorted list by first name (A-Z)");
                        Console.WriteLine("4. Show sorted list by grades (High-Low)");
                        Console.WriteLine("5. Delete a student");
                        Console.WriteLine("6. Add a student");
                        Console.WriteLine("7. Student average for the class ");
                        Console.WriteLine("8. Student with Highest Grade");
                        Console.WriteLine("9. Student with Lowest Grade");
                        Console.WriteLine("10. Median student(s) Grade");
                        Console.WriteLine("11. Exit");

                        strUser = Console.ReadLine();
                        intMenuOption = Int32.Parse(strUser); //User enters what they want from the menu 


                        //Output 

                        if (intMenuOption == 1) //Show original unsorted list
                        {
                            Console.WriteLine("------------------------------------------"); //Top of the table where data is output 
                            Console.WriteLine("First Name    |    Last Name    |   Grade");
                            Console.WriteLine("------------------------------------------");
                            for (int i = 0; i < strOriginalFirstName.Length; i++) //Loop continues until all values in all 3 arrays are displayed 
                            {

                                Console.WriteLine(String.Format("{0, -12}  | {1, -12}    | {2, 5}", strOriginalFirstName[i], strOriginalLastName[i], intGrade[i])); //uses string.format to output cleanly 
                            }

                            Clearing();
                        }

                        else if (intMenuOption == 2) //Show sorted list by last name (A-Z)
                        {
                            //Sets size of sorted arrays 
                            strSortedFirstName = new string[strOriginalFirstName.Length];
                            strSortedLastName = new string[strOriginalFirstName.Length];
                            intSortedGrade = new int[strOriginalFirstName.Length];

                            //Copies information from unsorted arrays into sorted arrays through loop 
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                strSortedFirstName[i] = strOriginalFirstName[i];
                                strSortedLastName[i] = strOriginalLastName[i];
                                intSortedGrade[i] = intGrade[i];

                            }

                            //Applies bubble sort to rearrange array 
                            for (int i = 0; i < strOriginalFirstName.Length; i++) //Loop continues for all locations in array 
                            {
                                for (int j = 0; j < strOriginalFirstName.Length - 1; j++) //Loop continues for all locations in array except the last one 
                                {
                                    if (strSortedLastName[j].CompareTo(strSortedLastName[j + 1]) > 0) //Compares last names (string) usng .CompareTo. If it is greater than 0, then it will go after if the last names are different 
                                    {
                                        //Swaps array values if the next last name comes before the current one 
                                        strTempLastName = strSortedLastName[j];
                                        strSortedLastName[j] = strSortedLastName[j + 1];
                                        strSortedLastName[j + 1] = strTempLastName;

                                        //First name and grade swap with the last name to ensure names aren't mixed up 
                                        strTempFirstName = strSortedFirstName[j];
                                        strSortedFirstName[j] = strSortedFirstName[j + 1];
                                        strSortedFirstName[j + 1] = strTempFirstName;

                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;




                                    }

                                    //If the last names are the same
                                    else if (strSortedLastName[j].CompareTo(strSortedLastName[j + 1]) == 0)
                                    {
                                        if (strSortedFirstName[j].CompareTo(strSortedFirstName[j + 1]) > 0)
                                        {
                                            strTempLastName = strSortedLastName[j];
                                            strSortedLastName[j] = strSortedLastName[j + 1];
                                            strSortedLastName[j + 1] = strTempLastName;

                                            strTempFirstName = strSortedFirstName[j];
                                            strSortedFirstName[j] = strSortedFirstName[j + 1];
                                            strSortedFirstName[j + 1] = strTempFirstName;

                                            intTempGrade = intSortedGrade[j];
                                            intSortedGrade[j] = intSortedGrade[j + 1];
                                            intSortedGrade[j + 1] = intTempGrade;
                                        }

                                        else
                                        {
                                            strTempFirstName = strSortedFirstName[j + 1];
                                            strSortedFirstName[j + 1] = strSortedFirstName[j];
                                            strSortedFirstName[j] = strTempFirstName;

                                            intTempGrade = intSortedGrade[j + 1];
                                            intSortedGrade[j + 1] = intSortedGrade[j];
                                            intSortedGrade[j] = intTempGrade;

                                        }
                                    }

                                }


                            }

                            //Outputs sorted info into an organized table 
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("First Name    |    Last Name    |   Grade");
                            Console.WriteLine("------------------------------------------");
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {

                                Console.WriteLine(String.Format("{0, -12}  | {1, -12}    | {2, 5}", strSortedFirstName[i], strSortedLastName[i], intSortedGrade[i]));
                            }

                            Clearing();
                        }

                        else if (intMenuOption == 3) //Show sorted list by first name 
                        {
                            //Sets values for array size for sorted arrays 
                            strSortedFirstName = new string[strOriginalFirstName.Length];
                            strSortedLastName = new string[strOriginalFirstName.Length];
                            intSortedGrade = new int[strOriginalFirstName.Length];

                            //Copies values into sorted arrays for unsorted arrays 
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                strSortedFirstName[i] = strOriginalFirstName[i];
                                strSortedLastName[i] = strOriginalLastName[i];
                                intSortedGrade[i] = intGrade[i];

                            }

                            //Applies bubble sort to rearrange array 
                            for (int i = 0; i < strOriginalFirstName.Length; i++) //Loops until all values in array complete 
                            {
                                for (int j = 0; j < strOriginalFirstName.Length - 1; j++) //loops all except last array value 
                                {
                                    if (strSortedFirstName[j].CompareTo(strSortedFirstName[j + 1]) > 0) //If the first name values are different 
                                    {
                                        //Rearranges last name so that it follows first name 
                                        strTempLastName = strSortedLastName[j];
                                        strSortedLastName[j] = strSortedLastName[j + 1];
                                        strSortedLastName[j + 1] = strTempLastName;

                                        //Rearranges first name so that alphabetically it is sorted 
                                        strTempFirstName = strSortedFirstName[j];
                                        strSortedFirstName[j] = strSortedFirstName[j + 1];
                                        strSortedFirstName[j + 1] = strTempFirstName;

                                        //Rearranges grade so that it follows first name 
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;




                                    }
                                    //If first names are same
                                    else if (strSortedFirstName[j].CompareTo(strSortedFirstName[j + 1]) == 0)
                                    {
                                        if (strSortedLastName[j].CompareTo(strSortedLastName[j + 1]) < 0) //Compares last names to see which comes first, then rearranges accordingly 
                                        {
                                            strTempLastName = strSortedLastName[j];
                                            strSortedLastName[j] = strSortedLastName[j + 1];
                                            strSortedLastName[j + 1] = strTempLastName;
                                        }

                                        else
                                        {
                                            strTempLastName = strSortedLastName[j + 1];
                                            strSortedLastName[j + 1] = strSortedLastName[j];
                                            strSortedLastName[j] = strTempLastName;
                                        }
                                    }

                                }

                            }

                            //Outputs the sorted information into Formatted table 

                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("First Name    |    Last Name    |   Grade");
                            Console.WriteLine("------------------------------------------");
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {

                                Console.WriteLine(String.Format("{0, -12}  | {1, -12}    | {2, 5}", strSortedFirstName[i], strSortedLastName[i], intSortedGrade[i]));
                            }

                            Clearing();
                        }
                        else if (intMenuOption == 4) //Show sorted list by grade 
                        {

                            //Sets size of array for sorted arrays 
                            strSortedFirstName = new string[strOriginalFirstName.Length];
                            strSortedLastName = new string[strOriginalFirstName.Length];
                            intSortedGrade = new int[strOriginalFirstName.Length];

                            for (int i = 0; i < strOriginalFirstName.Length; i++) //Copies information into sorted arrays from unsorted arrays 
                            {
                                strSortedFirstName[i] = strOriginalFirstName[i];
                                strSortedLastName[i] = strOriginalLastName[i];
                                intSortedGrade[i] = intGrade[i];

                            }

                            //Applies bubble sort to rearrange by grade 
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                for (int j = 0; j < strOriginalFirstName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1]) //if the grade is smaller than the next grade, it changes the location 
                                    {
                                        //Changes location of grade 
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        //Changes last and first names following the grade 
                                        strTempLastName = strSortedLastName[j];
                                        strSortedLastName[j] = strSortedLastName[j + 1];
                                        strSortedLastName[j + 1] = strTempLastName;

                                        strTempFirstName = strSortedFirstName[j];
                                        strSortedFirstName[j] = strSortedFirstName[j + 1];
                                        strSortedFirstName[j + 1] = strTempFirstName;

                                    }
                                }
                            }

                            //Outputs the information into formatted table 
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("First Name    |    Last Name    |   Grade");
                            Console.WriteLine("------------------------------------------");
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {

                                Console.WriteLine(String.Format("{0, -12}  | {1, -12}    | {2, 5}", strSortedFirstName[i], strSortedLastName[i], intSortedGrade[i]));
                            }

                            Clearing();
                        }


                        else if (intMenuOption == 5) //Delete a student
                        {
                            while (true)
                            {
                                Console.WriteLine("Which student would you like to delete? Please enter the index number BESIDE their name: "); //Asks user to enter an index location of the student they want to delete 

                                Console.WriteLine("-------------------------------------------------------------"); //Outputs unsorted array and has an index number for user to enter 
                                Console.WriteLine("Index Number   |   First Name    |    Last Name    |   Grade");
                                Console.WriteLine("-------------------------------------------------------------");
                                for (int i = 0; i < strOriginalFirstName.Length; i++)
                                {

                                    Console.WriteLine(String.Format("{0, -12}   | {1, -12}    | {2, -15} | {3, 6}", i + 1, strOriginalFirstName[i], strOriginalLastName[i], intGrade[i])); //Outputs values into table format 
                                }

                                strUser = Console.ReadLine();
                                intDeletedStudent = Int32.Parse(strUser); //Takes the index number 

                                if (intDeletedStudent > 0 && intDeletedStudent < (strOriginalFirstName.Length + 1)) //If the user's input is greater than 0 and less than the size of the array 
                                {
                                    //Deleting First Name
                                    strTempDeletedFirstName = new string[strOriginalFirstName.Length - 1]; //Sets new size of temp array by deleting 1 from existing array 

                                    for (int i = 0; i < (intDeletedStudent - 1); i++) //Copies information into temp array until deleted location
                                    {
                                        strTempDeletedFirstName[i] = strOriginalFirstName[i];
                                    }

                                    for (int i = (intDeletedStudent - 1); i < strTempDeletedFirstName.Length; i++) //Copies information into temp array after deleted location
                                    {
                                        strTempDeletedFirstName[i] = strOriginalFirstName[i + 1];
                                    }

                                    strOriginalFirstName = new string[strTempDeletedFirstName.Length]; //Sets new size for array 


                                    for (int i = 0; i < strOriginalFirstName.Length; i++) //Copies information from temp array into original array 
                                    {
                                        strOriginalFirstName[i] = strTempDeletedFirstName[i];
                                    }

                                    //Deleting Last name
                                    strTempDeletedLastName = new string[strOriginalLastName.Length - 1]; //Sets new size of temp array by deleting 1 from existing array 

                                    for (int i = 0; i < (intDeletedStudent - 1); i++) //Copies information into temp array until deleted location
                                    {
                                        strTempDeletedLastName[i] = strOriginalLastName[i];
                                    }

                                    for (int i = (intDeletedStudent - 1); i < strTempDeletedLastName.Length; i++) //Copies information into temp array after deleted location
                                    {
                                        strTempDeletedLastName[i] = strOriginalLastName[i + 1];
                                    }

                                    strOriginalLastName = new string[strTempDeletedLastName.Length]; //Sets new size for array 


                                    for (int i = 0; i < strOriginalLastName.Length; i++) //Copies information from temp array into original array 
                                    {
                                        strOriginalLastName[i] = strTempDeletedLastName[i];
                                    }

                                    //Deleting Grade 
                                    intTempDeletedGrade = new int[intGrade.Length - 1]; //Sets new size of temp array by deleting 1 from existing array 

                                    for (int i = 0; i < (intDeletedStudent - 1); i++) //Copies information into temp array until deleted location
                                    {
                                        intTempDeletedGrade[i] = intGrade[i];
                                    }

                                    for (int i = (intDeletedStudent - 1); i < intTempDeletedGrade.Length; i++) //Copies information into temp array after deleted location
                                    {
                                        intTempDeletedGrade[i] = intGrade[i + 1];
                                    }

                                    intGrade = new int[intTempDeletedGrade.Length]; //Sets new size for array 


                                    for (int i = 0; i < intGrade.Length; i++) //Copies information from temp array into original array 
                                    {
                                        intGrade[i] = intTempDeletedGrade[i];
                                    }

                                    Console.WriteLine("Successfully deleted!");
                                    break; //Exits infinite loop 
                                }

                                else //If user enters invalid input 
                                {
                                    Console.WriteLine("Invalid entry or nothing to delete! Please choose another menu option.");
                                }

                            }


                            Clearing();
                        }
                        else if (intMenuOption == 6) //Adding a student
                        {

                            //Asks user for first name, last name, and grade of new added student 
                            Console.WriteLine("What is the first name of the student you would like to add?");
                            strUser = Console.ReadLine();
                            strFirstName = strUser;

                            Console.WriteLine("What is the last name of the student you would like to add?");
                            strUser = Console.ReadLine();
                            strLastName = strUser;

                            Console.WriteLine("What is the grade of the student you would like to add?");
                            strUser = Console.ReadLine();
                            intEnteredGrade = Int32.Parse(strUser);

                            //Adding First name
                            strTempAddedFirstName = new string[strOriginalFirstName.Length + 1]; //Set size of temp array to 1 more 

                            for (int i = 0; i < strTempAddedFirstName.Length - 1; i++) //Copies information into new array 
                            {
                                strTempAddedFirstName[i] = strOriginalFirstName[i];
                            }

                            strTempAddedFirstName[strTempAddedFirstName.Length - 1] = strFirstName; //The last value in temp array is set to the new first name the user enters 

                            strOriginalFirstName = new string[strTempAddedFirstName.Length]; //Resets size of original array

                            for (int i = 0; i < strOriginalFirstName.Length; i++) //Copies values from temp array into original resized array 
                            {
                                strOriginalFirstName[i] = strTempAddedFirstName[i];
                            }

                            //Adding Last name
                            strTempAddedLastName = new string[strOriginalLastName.Length + 1]; //Set size of temp array to 1 more 

                            for (int i = 0; i < strTempAddedLastName.Length - 1; i++) //Copies information into new array 

                            {
                                strTempAddedLastName[i] = strOriginalLastName[i];
                            }

                            strTempAddedLastName[strTempAddedLastName.Length - 1] = strLastName; //The last value in temp array is set to the new first name the user enters 

                            strOriginalLastName = new string[strTempAddedLastName.Length]; //Resets size of original array

                            for (int i = 0; i < strOriginalLastName.Length; i++) //Copies information into new array 
                            {
                                strOriginalLastName[i] = strTempAddedLastName[i];
                            }

                            //Adding Grade
                            intTempAddedGrade = new int[intGrade.Length + 1]; //Set size of temp array to 1 more 

                            for (int i = 0; i < intTempAddedGrade.Length - 1; i++) //Copies information into new array 

                            {
                                intTempAddedGrade[i] = intGrade[i];
                            }

                            intTempAddedGrade[strTempAddedFirstName.Length - 1] = intEnteredGrade; //The last value in temp array is set to the new first name the user enters 

                            intGrade = new int[intTempAddedGrade.Length]; //Resets size of original array

                            for (int i = 0; i < strOriginalFirstName.Length; i++) //Copies information into new array 
                            {
                                intGrade[i] = intTempAddedGrade[i];
                            }

                            Console.WriteLine("Successfully added!");


                            Clearing();
                        }
                        else if (intMenuOption == 7) //Student Average for the class
                        {
                            for (int i = 0; i < intGrade.Length; i++) //Adds all the grades together using intSum as a counter in a loop 
                            {
                                intSum = intSum + intGrade[i];
                            }

                            dblAverage = (double)intSum / (double)intGrade.Length; //Calculates the average, casting values as double temporarily 
                            dblAverage = Math.Round(dblAverage, 2); //Rounds average to 2 decimals 
                            intSum = 0; //Resets sum to 0 if user changes values and tries to find average again 

                            Console.WriteLine("The average of the grades is " + dblAverage); //Displays average 

                            Clearing();
                        }

                        else if (intMenuOption == 8) //Highest grade
                        {
                            //Sorts by grade from high-low in the same way as menu option 4
                            strSortedFirstName = new string[strOriginalFirstName.Length];
                            strSortedLastName = new string[strOriginalFirstName.Length];
                            intSortedGrade = new int[strOriginalFirstName.Length];

                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                strSortedFirstName[i] = strOriginalFirstName[i];
                                strSortedLastName[i] = strOriginalLastName[i];
                                intSortedGrade[i] = intGrade[i];

                            }
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                for (int j = 0; j < strOriginalFirstName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1])
                                    {
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        strTempLastName = strSortedLastName[j];
                                        strSortedLastName[j] = strSortedLastName[j + 1];
                                        strSortedLastName[j + 1] = strTempLastName;

                                        strTempFirstName = strSortedFirstName[j];
                                        strSortedFirstName[j] = strSortedFirstName[j + 1];
                                        strSortedFirstName[j + 1] = strTempFirstName;

                                    }
                                }
                            }

                            //The highest grade is the first value in the array (location 0), then displays the first and last names associated.
                            Console.WriteLine("The highest grade in the class is " + intSortedGrade[0] + " %");
                            Console.WriteLine("This grade belongs to " + strSortedFirstName[0] + " " + strSortedLastName[0]);

                            Clearing();
                        }

                        else if (intMenuOption == 9) //Lowest grade in the class
                        {
                            //Sorts by grade from high-low in the same way as menu option 4 and 8. 
                            strSortedFirstName = new string[strOriginalFirstName.Length];
                            strSortedLastName = new string[strOriginalFirstName.Length];
                            intSortedGrade = new int[strOriginalFirstName.Length];

                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                strSortedFirstName[i] = strOriginalFirstName[i];
                                strSortedLastName[i] = strOriginalLastName[i];
                                intSortedGrade[i] = intGrade[i];

                            }
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                for (int j = 0; j < strOriginalFirstName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1])
                                    {
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        strTempLastName = strSortedLastName[j];
                                        strSortedLastName[j] = strSortedLastName[j + 1];
                                        strSortedLastName[j + 1] = strTempLastName;

                                        strTempFirstName = strSortedFirstName[j];
                                        strSortedFirstName[j] = strSortedFirstName[j + 1];
                                        strSortedFirstName[j + 1] = strTempFirstName;

                                    }
                                }
                            }

                            //The lowest grade is the last value in the grade array, then displays the first and last names associated with the lowest grade. 
                            Console.WriteLine("The lowest grade in the class is " + intSortedGrade[intSortedGrade.Length - 1] + "%");
                            Console.WriteLine("This grade belongs to " + strSortedFirstName[intSortedGrade.Length - 1] + " " + strSortedLastName[intSortedGrade.Length - 1]);

                            Clearing();
                        }



                        else if (intMenuOption == 10) //Median Grade 
                        {
                            //Sorts by grade from high-low in the same way as menu option 4. 
                            strSortedFirstName = new string[strOriginalFirstName.Length];
                            strSortedLastName = new string[strOriginalFirstName.Length];
                            intSortedGrade = new int[strOriginalFirstName.Length];

                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                strSortedFirstName[i] = strOriginalFirstName[i];
                                strSortedLastName[i] = strOriginalLastName[i];
                                intSortedGrade[i] = intGrade[i];

                            }
                            for (int i = 0; i < strOriginalFirstName.Length; i++)
                            {
                                for (int j = 0; j < strOriginalFirstName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1])
                                    {
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        strTempLastName = strSortedLastName[j];
                                        strSortedLastName[j] = strSortedLastName[j + 1];
                                        strSortedLastName[j + 1] = strTempLastName;

                                        strTempFirstName = strSortedFirstName[j];
                                        strSortedFirstName[j] = strSortedFirstName[j + 1];
                                        strSortedFirstName[j + 1] = strTempFirstName;

                                    }
                                }
                            }


                            if (intSortedGrade.Length % 2 == 0) //If there are an even number of entries in the array
                            {
                                intMedianLocation = intSortedGrade.Length / 2; //The location of one of the median locations is the number of values divided by 2

                                dblMedian = (intSortedGrade[intMedianLocation - 1] + intSortedGrade[intMedianLocation]) / 2; //The other location is 1 less than that (since location count starts at 0)
                                dblMedian = Math.Round(dblMedian, 2); //Calculates median by adding 2 middle values and dividing by 2, then rounding to 2 decimals 

                                Console.WriteLine("The median grade is " + dblMedian + "%"); //Outputs median and the students who have them. 
                                Console.WriteLine("Since there are two students, the median is an average of the grades of " + strSortedFirstName[intMedianLocation - 1] + " " + strSortedLastName[intMedianLocation - 1] + " and " + strSortedFirstName[intMedianLocation] + " " + strSortedLastName[intMedianLocation]);

                            }

                            else //If there are an odd number of entries in the array 
                            {
                                intMedianLocation = (intSortedGrade.Length + 1) / 2; //The median location would be 1 less than 1 added to the length then divided by 2 (starts at location 0)

                                dblMedian = intSortedGrade[intMedianLocation - 1];

                                Console.WriteLine("The median grade is " + dblMedian + "%"); //Displays the median and the student who has it 
                                Console.WriteLine("This grade belongs to " + strSortedFirstName[intMedianLocation - 1] + " " + strSortedLastName[intMedianLocation - 1]);
                            }

                            Clearing();

                        }

                        else if (intMenuOption == 11) //Exit option in menu 
                        {
                            break; //Exits menu 
                        }

                        else //If the user enters an option not in the menu 
                        {
                            Console.WriteLine("That is not an option from the menu!");
                        }
                    }

                    break; //Exits program 

                }


                else  //If user enters invalid number of students 
                {
                    Console.WriteLine("You cannot enter less than 1 student! Please try again!");
                }



            }










            Console.ReadKey(); //Ends program 
        }

        public static void Clearing() //Method used after each menu option - asks user to enter anything to exit the menu option and return to main menu 
        {
            Console.WriteLine(" ");
            Console.WriteLine("Please type anything to go back to the menu.");
            Console.ReadKey();
        }
    }
}





