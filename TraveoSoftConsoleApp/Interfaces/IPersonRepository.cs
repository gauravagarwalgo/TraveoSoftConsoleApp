using System.Collections.Generic;

namespace TraveoSoftConsoleApp.Interfaces
{
    /// <summary>
    /// Represents interface IPersonRepository
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Method to Get All the professor associated with all the students
        /// </summary>
        /// <returns></returns>
        IList<ProfessorStudentDetail> GetAllStudentUnderAllProfessor();

        /// <summary>
        /// Method to get the list of professors name
        /// </summary>
        /// <returns></returns>
        IList<string> GetprofessorNames();

        /// <summary>
        /// Method to represent course name that is taught by a professor
        /// </summary>
        /// <param name="professorName"></param>
        /// <returns></returns>
        IList<string> GetCourseName(string professorName);

        /// <summary>
        /// Represents method to delete student from database
        /// </summary>
        /// <param name="studentName"></param>
        void DeleteStudentFromDatabase(string studentName);

        /// <summary>
        /// Method to represent delete professor from database
        /// </summary>
        /// <param name="professorName"></param>
        void DeleteProfessorFromDatabase(string professorName);
    }
}
