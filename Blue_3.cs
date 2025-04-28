using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltypimes;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltypimes == null) return null;
                    int[] penaltypimes = new int[_penaltypimes.Length];
                    for (int i = 0; i < _penaltypimes.Length; i++)
                    {
                        penaltypimes[i] = _penaltypimes[i];
                    }
                    return penaltypimes;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltypimes == null || _penaltypimes.Length == 0) return 0;
                    int _totaltime = 0;
                    foreach (var i in _penaltypimes)
                    {
                        _totaltime += i;
                    }
                    return _totaltime;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    foreach (var i in _penaltypimes)
                    {
                        if (i == 10) return true;
                    }
                    return false;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltypimes = new int[0];
            }
            public void PlayMatch(int time)
            {
                if (_penaltypimes == null) return;
                int[] new_penalty = new int[_penaltypimes.Length + 1];
                for (int i = 0; i < new_penalty.Length - 1; i++)
                {
                    new_penalty[i] = _penaltypimes[i];
                }
                new_penalty[new_penalty.Length - 1] = time;
                _penaltypimes = new_penalty;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
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
                Console.WriteLine($"{_name},{_surname},{TotalTime},{IsExpelled}");
            }
        }
    }
}
