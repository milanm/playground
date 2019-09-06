using System;
using System.Collections.Generic;
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
        private static readonly List<List<int>> listOfHeights = new List<List<int>>();

        public static int LineUp(int[] studentHeights)
        {
            int numberOfRows = 1;
            listOfHeights.Add(new List<int>());

            for (int i = 0; i < studentHeights.Length; i++)
            {
                for (int j = 0; j < listOfHeights.Count; j++)
                {
                    if (StudentFitsToRow(listOfHeights[j], studentHeights[i]))
                    {
                        listOfHeights[j].Add(studentHeights[i]);
                    }
                    else
                    {
                        var newList = new List<int>
                        {
                            studentHeights[i]
                        };
                        listOfHeights.Add(newList);
            
                        numberOfRows++;
                        break;
                    }
                }
            }

            return numberOfRows;
        }

        private static bool StudentFitsToRow(List<int> row, int newStudentHeight)
        {
            if (row.Count == 0)
            {
                return true;
            }
            else
            {
                foreach (var studentHeight in row)
                {
                    if (studentHeight >= newStudentHeight)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        static void Main()
        {
        }
    }
}
