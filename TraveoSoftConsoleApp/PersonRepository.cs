using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using TraveoSoftConsoleApp.Interfaces;

namespace TraveoSoftConsoleApp
{
    /// <summary>
    /// Represents person repository class
    /// </summary>
    public class PersonRepository : IPersonRepository, IDisposable
    {
        #region variables

        /// <summary>
        /// The variable disposed which is using in dispose method
        /// </summary>
        bool disposed;

        /// <summary>
        /// The IdbConnection which connects to the database
        /// </summary>
        private IDbConnection _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Traveosoftconnectionstring"].ConnectionString);

        /// <summary>
        /// The Generate query helper which makes the query string
        /// </summary>
        private GenerateQueryHelper _generateQuery;

        #endregion

        #region Constructor

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="generateQueryHelper"></param>
        public PersonRepository(GenerateQueryHelper generateQueryHelper)
        {
            _generateQuery = generateQueryHelper;
        }

        #endregion

        #region Public Methods

        #region Get All Students under all professor

        /// <summary>
        /// Method to Get All the professor associated with all the students
        /// </summary>
        /// <returns></returns>
        public IList<ProfessorStudentDetail> GetAllStudentUnderAllProfessor()
        {
            //calling SQL file which is present under SQL queries folder
            string query= string.Format(CultureInfo.CurrentCulture, _generateQuery.GetString("GetAllStudentsUnderAllProfessor.sql"));

            //Using dapper ORM concept to fetch data from the database.
            var result = _dbConnection.Query<ProfessorStudentDetail>(query).ToList();

            //returning the list of student and professor
            return result;
        }

        #endregion

        #region Get professor Names

        /// <summary>
        /// Method to get the list of professors name
        /// </summary>
        /// <returns></returns>
        public IList<string> GetprofessorNames()
        {
            //Fetching the query by passing the SQL file
            string query = string.Format(CultureInfo.CurrentCulture, _generateQuery.GetString("GetProfessorName.sql"));

            //Using dapper ORM concept to fetch data from the database.
            var result = _dbConnection.Query<string>(query).ToList();

            //returning the list of student and professor
            return result;
        }

        #endregion

        #region Get course name which is taught by a professor

        /// <summary>
        /// Method to represent course name that is taught by a professor
        /// </summary>
        /// <param name="professorName"></param>
        /// <returns></returns>
        public IList<string> GetCourseName(string professorName)
        {
            //Fetching the query by passing the SQL file
            string query = string.Format(CultureInfo.CurrentCulture, _generateQuery.GetString("GetCourseNameBypassingProfessorName.sql"),professorName);

            //Using dapper ORM concept to fetch data from the database.
            var result = _dbConnection.Query<string>(query).ToList();

            //returning the list of student and professor
            return result;
        }

        #endregion

        #region Delete student from database

        /// <summary>
        /// Represents method to delete student from database
        /// </summary>
        /// <param name="studentName"></param>
        public void DeleteStudentFromDatabase(string studentName)
        {
            string query = string.Format(CultureInfo.CurrentCulture, _generateQuery.GetString("DeleteStudentFromDatabaseBasedOnName.sql"), studentName);
            _dbConnection.Execute(query);
        }

        #endregion

        #region Delete professor from database

        /// <summary>
        /// Represents method to delete professor from database
        /// </summary>
        /// <param name="professorName"></param>
        public void DeleteProfessorFromDatabase(string professorName)
        {
            string query = string.Format(CultureInfo.CurrentCulture, _generateQuery.GetString("DeleteProfessorFromDatabaseBasedOnName.sql"), professorName);
            _dbConnection.Execute(query);
        }

        #endregion

        #endregion

        #region Dispose Methods

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            disposed = true;
        }

        #endregion
    }
}
