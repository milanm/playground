using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private static readonly List<List<int>> ListOfStudentRows = new List<List<int>>();

        public static int LineUp(int[] studentHeights)
        {
            if (studentHeights == null || studentHeights.Length == 0)
            {
                return 0;
            }

            var numberOfRows = 1;
            ListOfStudentRows.Add(new List<int>());

            foreach (var studentHeight in studentHeights)
            {
                for (var i = 0; i < ListOfStudentRows.Count; i++)
                {
                    if (DoesStudentFitsToRow(ListOfStudentRows[i], studentHeight))
                    {
                        ListOfStudentRows[i].Add(studentHeight);
                    }
                    else
                    {
                        var newList = new List<int>
                        {
                            studentHeight
                        };
                        ListOfStudentRows.Add(newList);
            
                        numberOfRows++;
                        break;
                    }
                }
            }

            return numberOfRows;
        }

        private static bool DoesStudentFitsToRow(IReadOnlyCollection<int> row, int newStudentHeight)
        {
            return row.Count == 0 || row.Any(studentHeight => studentHeight >= newStudentHeight);
        }

        private static void Main()
        {
        }
    }
}
