using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int _jumpnum;
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] marks = new int[2, 5];
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            marks[i, j] = _marks[i, j];
                        }
                    }
                    return marks;
                }
            }
            public int TotalScore
            {

                get
                {
                    if (_marks == null) return 0;
                    int totalscore = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            totalscore += _marks[i, j];
                        }
                    }
                    return totalscore;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _jumpnum = 0;
            }
            public void Jump(int[] result)
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0 || result == null || result.Length == 0 || _jumpnum > 1) return;
                for (int i = 0; i < 5; i++)
                {
                    _marks[_jumpnum,i] = result[i];
                }
                _jumpnum++;
            }
            
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for(int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name}, {Surname}, {TotalScore}");
            }
        }
    }
}
