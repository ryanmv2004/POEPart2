﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEPart1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green; //Sets the console text colour to green
            Operations ops = new Operations(); //Creates an object of the operations class, does this outside the loop so that any array created is saved to the memory and not wiped between runs.
            double scaleAmount = 0; //Keeps a record outside the loop if the recipie is scaled, if so also how big it was scaled.

            Boolean SENTINAL = true; // sentinal value that keeps track if the program must still be running.
            while (SENTINAL)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Welcome to the Recipie Storage App!");
                Console.WriteLine("------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Please make a Selection on which tool to use:");
                Console.WriteLine("1) Enter Recipe");
                Console.WriteLine("2) Display Recipes");
                Console.WriteLine("3) Search Recipes");
                Console.WriteLine("4) Scale Recipie");
                Console.WriteLine("5) Clear all Recipies");
                Console.WriteLine("6) Scale Recipies back to Original");
                Console.WriteLine("7) Exit");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Please make a choice by entering only the tool number:"); //Writes a gui to the console from which the user must make a choice on what tool to use.
                int choice = Int32.Parse(Console.ReadLine()); //saves this choice as an integer
                if (choice == 1) //If the user selects choice 1
                {
                    ops.enterRecipie(); //Calls the enter recipie method from the Operations class using the ops object.
                }
                if (choice == 2) //If the user selects choice 2
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    ops.displayRecipes(); //Calls the display recipes method from the Operations class using the ops object.
                }
                if (choice == 3) 
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the recipe to search:");
                    String search = Console.ReadLine();
                    Console.WriteLine();

                    ops.searchRecipe(search);
                }
                if (choice == 4) //If the user selects choice 3
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Please enter Recipe to be scaled: ");
                    String name = Console.ReadLine(); //Prompts the user to enter the name of the recipie they wish to scale and stores the response in a string variable.
                    Console.WriteLine("Please enter the scale which you want to multiply the recipie by:"); //Prompts the user to enter the value by which they want to scale the recipie
                    Console.WriteLine("This can either be 0.5, 2 or 3");
                    String scalePreCheck = Console.ReadLine(); //Saves the input in a string

                    Boolean check = false;
                    while(check == false) //Runs a loop to see if the user input matches the prompts. If it does then it breaks from the loop and allows the recipie to be scaled. If the string doesnt match the prompt then it asks the user again until the answer matches.
                    {
                        if (scalePreCheck.Equals("0.25") || scalePreCheck.Equals("2") || scalePreCheck.Equals("3")) //If statement that does the checking
                        {
                            check = true;
                            break;
                        }
                        Console.WriteLine("Your entry was invalid, please try again");
                        scalePreCheck = Console.ReadLine();
                    }

                    double scale = double.Parse(scalePreCheck); //Saves the string response in a double variable

                    ops.scaleRecipie(scale, name); //Uses this double variable and calls the scale recipie method in the operations class and uses the variable as an arguement

                    scaleAmount = scale; //Saves the amount the recipie was scaled in the scaleAmount variable outside the main while loop for scaling the recipie back to the original.
                }
                if (choice == 5) //If the choice is 4
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter Recipe to be Deleted: ");
                    String name = Console.ReadLine(); //Prompts the user to enter the name of the recipie they wish to delete and stores the response in a string variable.

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Type Y to confirm this choice and N to go back");
                    String deleteChoice = Console.ReadLine(); //Printing to the console if the user wishes to truely delete their recipie from memory and stores the answer.

                    if (deleteChoice.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If statement that verifies that they wanted to delete the recipie in any variation of the char 'Y'
                    {
                        ops.deleteRecipies(name); //Cals the ops object to make use of the deleteRecipies methos in the operations class.
                    }
                    else //Else statement that does nothing
                    {

                    }
                }
                if (choice == 6) //If the user chooses choice 5
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter Recipie to return to original values: ");
                    String name = Console.ReadLine();

                    ops.opsUnScale(scaleAmount, name); //Makes use of the scaleAmount variable to keep track of the amount the recipie was scaled and then uses this value as an arguement to divide the potions by that amount in the .
                    scaleAmount = 0; //Resets this variable
                }
                if (choice == 7)
                {
                    SENTINAL = false; //Makes the sentinal value false
                    break; //breaks from the loops
                }
            }
        }
    }
}
