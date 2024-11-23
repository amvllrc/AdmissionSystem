using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace entrypoint.PROCESSES.Admin
{
    // This class will represent the structure of the course object
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        // Method to execute the query and return a list of Course objects
        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT course_id, name FROM course";

            // Use two 'using' blocks for proper resource management
            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command and get the result as a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read through the result set
                        while (reader.Read())
                        {
                            // Create a new Course object and populate it with data
                            Course course = new Course
                            {
                                CourseId = reader.GetInt32(0),  // course_id
                                Name = reader.GetString(1)      // name
                            };

                            // Add the course to the list
                            courses.Add(course);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the error (optional)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            // Return the list of courses
            return courses;
        }
    }
}
