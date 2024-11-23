using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace entrypoint.PROCESSES.Student_application
{
    public static class ProcessPeriods
    {
        // Static variables to hold StartDate and EndDate for each period (nullable DateTime)
        public static DateTime? ApplicationStartDate { get; private set; }
        public static DateTime? ApplicationEndDate { get; private set; }
        public static DateTime? ExaminationStartDate { get; private set; }
        public static DateTime? ExaminationEndDate { get; private set; }

      
        // Static constructor to initialize the periods when the class is first used
        static ProcessPeriods()
        {
            LoadProcessPeriods();
        }

        // Method to load the start and end dates from the database
        private static void LoadProcessPeriods()
        {
            // Queries for the application and examination periods
            string query1 = "SELECT StartDate, EndDate FROM process_period WHERE Name = 'Application Period'";
            string query2 = "SELECT StartDate, EndDate FROM process_period WHERE Name = 'Examination Period'";

            // Load the Application Period
            var applicationPeriod = ExecuteQuery(query1);
            ApplicationStartDate = applicationPeriod.Item1;
            ApplicationEndDate = applicationPeriod.Item2;

            // Load the Examination Period
            var examinationPeriod = ExecuteQuery(query2);
            ExaminationStartDate = examinationPeriod.Item1;
            ExaminationEndDate = examinationPeriod.Item2;
        }

        // Helper method to execute the query and get the start and end dates
        private static Tuple<DateTime?, DateTime?> ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime? startDate = reader.IsDBNull(0) ? (DateTime?)null : reader.GetDateTime(0);
                                DateTime? endDate = reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1);
                                return new Tuple<DateTime?, DateTime?>(startDate, endDate);
                            }
                            else
                            {
                                return new Tuple<DateTime?, DateTime?>(null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error executing query: {ex.Message}");
                return new Tuple<DateTime?, DateTime?>(null, null);
            }
        }
    }
}
