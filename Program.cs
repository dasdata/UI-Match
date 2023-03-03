using System;
using System.IO;

//The User Interface Recommendation Form is a console application that helps users identify the best interface for their needs based on their preferences and priorities.
//The application asks the user to rate the importance of various criteria (such as ease of use, speed, and customizability) and to rate different interfaces on a scale of 1-3 based on how well they meet those criteria.
//The application then calculates a weighted score for each interface and provides a recommendation based on the user's preferences.

namespace UISelector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   Criteria descriptions

            string[] criteriaTitles = new string[] {
                "Ease of use",
                "Accessibility",
                "Speed",
                "Customizability",
                "Aesthetics",
                "Functionality",
                "Consistency",
                "Feedback",
                "Automation"
            };

            string[] criteriaDescriptions = new string[] {
                "How easy it is for users to interact with the interface and perform tasks. A highly usable interface is intuitive and requires minimal training for users to understand and use effectively.",
                "How easily people with disabilities can use the interface. An accessible interface is designed to accommodate a range of physical and cognitive disabilities, such as visual impairments, hearing impairments, or mobility impairments.",
                "How quickly the interface can perform tasks and respond to user inputs. A fast interface is important for improving productivity and user satisfaction.",
                "The extent to which users can personalize the interface to their needs and preferences. A highly customizable interface allows users to adjust features and settings to suit their individual needs and work style.",
                "The visual appeal of the interface. An aesthetically pleasing interface can help to create a positive user experience and enhance user satisfaction.",
                "The range of tasks and activities that the interface can perform. A highly functional interface can accommodate a range of user needs and tasks.",
                "How consistently the interface performs tasks and displays information. A consistent interface helps users to predict how the interface will behave.",
                "How well the interface provides feedback to users on their actions and interactions. Good feedback helps users to understand how the interface works and guides their actions.",
                "The extent to which the interface can automate tasks and processes. High automation can improve efficiency and reduce user workload."
            };
             
            // start here

            Console.WriteLine("Interface Matchmaker ");
            Console.WriteLine("Helps users identify the best interface for their needs based on their preferences and priorities.");
            Console.ReadLine();

            int[] ratings = new int[criteriaDescriptions.Length];

            for (int i = 0; i < criteriaDescriptions.Length; i++)
            {
                Console.Clear();
                TypeTextWithCursor(criteriaDescriptions[i]);
                Console.WriteLine($"How Important " + criteriaTitles[i] + " is for you? \n(High = 3, Medium = 2, Low = 1):");
                string importance = Console.ReadLine();

                int importanceMultiplier = 0;

                if (int.TryParse(importance, out int number))
                {
                    if (number >= 1 && number <= 3)
                    {
                        importanceMultiplier = number;
                    }
                    else
                    {
                        Console.WriteLine("Invalid importance level.");
                        return;
                    }
                }
                else
                {
                    switch (importance.ToLower())
                    {
                        case "high":
                            importanceMultiplier = 3;
                            break;
                        case "medium":
                            importanceMultiplier = 2;
                            break;
                        case "low":
                            importanceMultiplier = 1;
                            break;
                        default:
                            Console.WriteLine("Invalid importance level.");
                            return;
                    }
                }

               // Console.WriteLine($"{criteriaDescriptions[i]}");
                Console.WriteLine("Please rate " + criteriaTitles[i] + " from 1-3 based on how well your interface meets your needs and preferences. (1-3):");
                int rating = int.Parse(Console.ReadLine());

                ratings[i] = rating * importanceMultiplier;
            }

            int sumRatings = 0;
            foreach (int rating in ratings)
            {
                sumRatings += rating;
            }

            double avgRating = (double)sumRatings / (3 * criteriaDescriptions.Length);

            string recommendation = "";
            if (avgRating >= 2.33)
            {
                recommendation = "Desktop Interface";
            }
            else if (avgRating >= 1.66)
            {
                recommendation = "Web Interface";
            }
            else if (avgRating >= 1)
            {
                recommendation = "Mobile Interface";
            }
            else
            {
                recommendation = "Speech Interface";
            }

            if (ratings[8] >= 6)
            {
                recommendation += " with Automation";
            }

            // sum up
            string results = $"Recommendation: {recommendation}, Average Rating: {avgRating:F2}";
            File.WriteAllText("results.txt", results);

            Console.WriteLine($"Based on the above factors, a {recommendation} is recommended with an average rating of {avgRating:F2}.");

            Console.ReadLine();

        }


        public static void TypeTextWithCursor(string text)
        {  // Scroll to the bottom of the console window
           // Console.SetCursorPosition(0, Console.WindowHeight - 1);
            int delay = 2;
            int width = Console.WindowWidth;
            int mid = width / 2;
            int column = 0;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);

                // Wrap the text at the specified column
                column++;
                if (column >= mid && c == ' ')
                {
                    Console.WriteLine();
                    column = 0;
                }

                // Print the cursor symbol
                Console.Write(column >= mid ? '_' : ' ');
                Thread.Sleep(5);

                // Delete the cursor symbol
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }

            // Print the final cursor symbol
            Console.WriteLine();
        }
    }
    }
 
