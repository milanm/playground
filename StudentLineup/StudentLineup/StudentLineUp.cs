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
        private static readonly List<List<int>> ListOfHeights = new List<List<int>>();

        public static int LineUp(int[] studentHeights)
        {
            var numberOfRows = 1;
            ListOfHeights.Add(new List<int>());

            foreach (var t in studentHeights)
            {
                for (var j = 0; j < ListOfHeights.Count; j++)
                {
                    if (StudentFitsToRow(ListOfHeights[j], t))
                    {
                        ListOfHeights[j].Add(t);
                    }
                    else
                    {
                        var newList = new List<int>
                        {
                            t
                        };
                        ListOfHeights.Add(newList);
            
                        numberOfRows++;
                        break;
                    }
                }
            }

            return numberOfRows;
        }

        private static bool StudentFitsToRow(IReadOnlyCollection<int> row, int newStudentHeight)
        {
            return row.Count == 0 || row.Any(studentHeight => studentHeight >= newStudentHeight);
        }

        private static void Main()
        {
        }
    }
}
