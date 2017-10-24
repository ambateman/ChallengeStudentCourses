using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
  


        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            resultLabel.Text = ""; //clear the label
            List<Course> AllCourses = new List<Course>
            {
               new Course{CourseId=10, Name = "Anthropology 405 -- Our Human Cousins" }
              , new Course{CourseId=20, Name="Astronomy 101 -- Survey of the Solar System"}
              , new Course{CourseId=50,Name="Geology 300 -- Geology of the Cascasdes" }
              , new Course{CourseId=72,Name="Cartograpy 175 -- Map making of the 17th Century"}
            };

            Dictionary<int, Student> AllStudents = new Dictionary<int, Student>
            {
                {1,new Student{StudentId=1, Name= "Yun-Mi Huh"}}
                ,{2, new Student{ StudentId=2,Name="Da-Ha Ju"}}
                ,{3, new Student{StudentId=3, Name = "G Na"}}
                ,{4, new Student{StudentId=4,Name = "Soo-Nim Park"}}
            };
            Random StudentID = new Random();
  
            foreach (Course SpecificCourse in AllCourses)
            {

                Dictionary<int, Student> Duplicate = new Dictionary<int, Student>();
                foreach (var Dict  in AllStudents)
                {
                    Duplicate.Add(Dict.Key,Dict.Value);
                }
                //Remove one or two student from the list at random.
                Student s = null;
                for (int i = 0; i < 2; i++)
                {
                    int IntStudentID = StudentID.Next(0, 5);
                    if (Duplicate.TryGetValue(IntStudentID, out s))
                        Duplicate.Remove(IntStudentID);
                }

                //Now build a list of students from the duplicate dictionary
                List<Student> StudentRoll = new List<Student>();
                foreach (var Student in Duplicate)
                {
                    StudentRoll.Add(Student.Value);
                }
                SpecificCourse.Students = StudentRoll;
                //Now the 'FormatDetailsForDisplay() function doesn't show in intellisense
                //like it does for an object in the videos. I'll just have to do it the old fashioned way.
                resultLabel.Text += String.Format("<br/><br/>{0} -- {1} ", SpecificCourse.CourseId, SpecificCourse.Name);
                //Add the students separately.
                foreach (var item in SpecificCourse.Students)
                {
                    resultLabel.Text += "<br/>&nbsp;&nbsp" + item.Name;
                }

            }

        }


       

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */
            resultLabel.Text = ""; //clear the label

            Dictionary<int, Student> AllStudents = new Dictionary<int, Student>
            {
                {1,new Student{StudentId=1, Name= "Yun-Mi Huh"}}
                ,{2, new Student{ StudentId=2,Name="Da-Ha Ju"}}
                ,{3, new Student{StudentId=3, Name = "G Na"}}
                ,{4, new Student{StudentId=4,Name = "Soo-Nim Park"}}
            };

            List<Course> AllCourses = new List<Course>
            {
               new Course{CourseId=10, Name = "Anthropology 405 -- Our Human Cousins" }
              , new Course{CourseId=20, Name="Astronomy 101 -- Survey of the Solar System"}
              , new Course{CourseId=50,Name="Geology 300 -- Geology of the Cascasdes" }
              , new Course{CourseId=72,Name="Cartograpy 175 -- Map making of the 17th Century"}
            };

            Random CourseID = new Random();

            foreach (Student SpecificStudent in AllStudents.Values)
            {
                //Place the student in courses using random assignments
                //Just run random assignment twice to build a short class list
                List<Course> Courses = new List<Course>();
                Dictionary<int, int> DuplicateTest = new Dictionary<int, int>();  //use to filter out duplicates (a hashtable would work too.)

                for (int i = 0; i < 2; i++)
                {
                    int CourseIndex = CourseID.Next(0, 3);
                    Course ACourse = AllCourses[CourseIndex];
                    int x; //dummy integer
                    if (DuplicateTest.TryGetValue(CourseIndex, out x))
                        i--;
                    else
                    {
                        Courses.Add(ACourse);
                        DuplicateTest.Add(CourseIndex, i);
                    }
                }
                SpecificStudent.Courses = Courses;


                resultLabel.Text += String.Format("<br/>Student Name: {0} -- Student ID: {1} <br/>", SpecificStudent.Name, SpecificStudent.StudentId);
                foreach (var Course in SpecificStudent.Courses)
                {
                    resultLabel.Text += Course.Name + "<br/>";
                }

            }

        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */
            resultLabel.Text = ""; //clear the label
            Random CourseID = new Random();
            Random Grade = new Random();

            Dictionary<string, Course> AllDictCourses = new Dictionary<string, Course>
            {
                {"Anthro405",new Course{CourseId=10, Name = "Anthropology 405 -- Our Human Cousins" }}
                ,{"Astro101", new Course{CourseId=20, Name="Astronomy 101 -- Survey of the Solar System"}}
                ,{"Geo300", new Course{CourseId=50,Name="Geology 300 -- Geology of the Cascasdes" }}
                ,{"Cart175", new Course{CourseId=72,Name="Cartograpy 175 -- Map making of the 17th Century"}}
            };

            Dictionary<int, Student> AllStudents = new Dictionary<int, Student>
            {
                {1,new Student{StudentId=1, Name= "Yun-Mi Huh"}}
                ,{2, new Student{ StudentId=2,Name="Da-Ha Ju"}}
                ,{3, new Student{StudentId=3, Name = "G Na"}}
                ,{4, new Student{StudentId=4,Name = "Soo-Nim Park"}}
            };

            List<Student> Students = new List<Student>();
            Students = AllStudents.Values.ToList();

            List<string> CourseCodes = new List<string>();
            CourseCodes = AllDictCourses.Keys.ToList();


            StudentGrades sg = new StudentGrades();
            foreach (var Student  in Students)
            {
                //Build up a list of courses and grades for each student. 
                //Add resulting dictionary to courseGrade
                Dictionary<int,int> DuplicateTest = new Dictionary<int, int>();  //use to filter out duplicates (a hashtable would work too.)
                Dictionary<string, int> myGrades = new Dictionary<string, int>();
                //Now build up the course and grade dictionary to save in the coursegrade dictionary

                for (int i = 0; i < 2; i++) //just two courses per student and assign grade
                {
                    int CourseIndex = CourseID.Next(0, 3);

                    string CourseCode = CourseCodes[CourseIndex];
                    int x; //dummy integer
                    if (DuplicateTest.TryGetValue(CourseIndex, out x))
                        i--;
                    else
                    {
                        int grade = Grade.Next(75, 100); //Yes, I'm grading on a curve. Sort of.
                        myGrades.Add(CourseCode, grade);
                        DuplicateTest.Add(CourseIndex, i);
                    }
                }

                resultLabel.Text += String.Format("<br/>Student: {0} ",Student.Name) + "<br/>";
                foreach (var grade in myGrades.Keys)
                {
                    resultLabel.Text += String.Format( "Course: {0}  --- Grade Score: {1} <br/>", grade.ToString(), myGrades[grade.ToString()].ToString());
                }

            }
  


















        }
    }
}