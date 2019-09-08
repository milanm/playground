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
            var hightestAdded = 0;
            var result = 0;
            
            foreach (var t in studentHeights)
            {
                if (hightestAdded >= t) continue;
                hightestAdded = t;
                result++;
            }
            return result;
        }

        private static void Main()
        {
        }
    }
}
