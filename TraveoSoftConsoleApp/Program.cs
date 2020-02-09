using System;
using System.Collections.Generic;
using TraveoSoftConsoleApp.Interfaces;

namespace TraveoSoftConsoleApp
{
    /// <summary>
    /// Represents Program class
    /// </summary>
    public class Program
    {
        #region Variables

        /// <summary>
        /// The Generate query helper class. It reads the query and gets the query string
        /// </summary>
        public static GenerateQueryHelper generateQueryHelper = new GenerateQueryHelper();

        /// <summary>
        /// The IPersonRepository
        /// </summary>
        public static IPersonRepository personRepository = new PersonRepository(generateQueryHelper);

        #endregion

        #region public Methods

        #region Get dynamically professor and student list with the database changes considering all possible scenarios

        /// <summary>
        /// Method to Get All the professor associated with all the students with database changes
        /// </summary>
        public void GetStudentAndProfessor()
        {
            // Calling the repository class method
            var listOfStudentAndProfessor = personRepository.GetAllStudentUnderAllProfessor();

            //Making a local list of string to add data
            IList<string> professor = new List<string>();

            //Iterating through the list
            foreach (var result in listOfStudentAndProfessor)
            {
                //Logic
                if (!professor.Contains(result.ProfessorName))
                {
                    professor.Add(result.ProfessorName);
                    professor.Add(result.StudentName);
                }
                else
                {
                    var index = professor.IndexOf(result.ProfessorName);
                    professor.Insert(index + 1, result.StudentName);
                }
            }

            //Getting all the professor names by calling the repository method Get professor names
            var professorNames = personRepository.GetprofessorNames();
            
            //Getting the desired output
            for (int i = 0; i < professor.Count; i++)
            {
                if (professorNames.Contains(professor[i]))
                {
                    Console.WriteLine("\n");

                    //Calling repository method to get the course that teacher takes
                    var courseName = personRepository.GetCourseName(professor[i]);
                    Console.WriteLine(professor[i] +" (" +courseName[0] + " Professor)" );
                    Console.WriteLine("*****************");
                    
                    Console.WriteLine("Student under this professor\n------------------------");
                }
                else 
                {
                    //checking if the professor has no student. Since left join is used in query, so we will get studentName as null
                    if(professor[i]==null)
                    {
                        Console.WriteLine("Sorry no student is associated with this professor!!");
                    }
                    Console.WriteLine(professor[i]);
                }
            }
            Console.WriteLine("------------------------");
        }

        #endregion

        #region Main Methods

        /// <summary>
        /// The main method which is calling the other methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Creating instance of Program class
            Program p = new Program();

            //calling GetStudentAndProfessor method of program class
            p.GetStudentAndProfessor();
        }

        #endregion

        #endregion
    }
}
