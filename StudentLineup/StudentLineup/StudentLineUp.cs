using System.Collections.Generic;
using System.Linq;

namespace StudentLineup
{
    /*
      Question: You are given an array A representing heights of students. All the students are asked to stand in rows.
      The students arrive by one, sequentially (as their heights appear in A). For the I-th student, if there is a row
      in which all the students are taller than A[i], the student will stand in one of such rows. If there is no such row,
      the student will create a new row. Your task is to find the minimum number of rows created.
   */
    public class StudentLineUp
    {

        public static int LineUp(int[] studentHeights)
        {
            var rows = new List<int>();
                
            foreach (var studentHeight in studentHeights)
            {
                var studentHigherIndex = rows.FindIndex(student => student > studentHeight);

                if (studentHigherIndex != -1)
                {
                    rows[studentHigherIndex] = studentHeight;
                }
                else
                {
                    rows.Add(studentHeight);
                }

            }

            return rows.Count;
        }

        private static void Main()
        {
        }
    }
}
