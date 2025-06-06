using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Place { get { return _place; } }
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (_place != 0) return;
                _place = place;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int indexer;

            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen => _sportsmen;
            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || indexer == 0) return 0;
                    int summaryscore = 0;
                    for (int i = 0; i < indexer; i++)
                    {
                        if (_sportsmen[i].Place > 0 && _sportsmen[i].Place <= 5)
                        {
                            summaryscore += (6 - _sportsmen[i].Place);
                        }
                    }
                    return summaryscore;
                }
            }
            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int topplace = int.MaxValue;
                    for (int i = 0; i < indexer; i++)
                    {
                        if (_sportsmen[i].Place > 0 && _sportsmen[i].Place < topplace)
                        {
                            topplace = _sportsmen[i].Place;
                        }
                    }
                    return topplace == int.MaxValue ? 18 : topplace;
                }
            }
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                indexer = 0;
            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;
                if (indexer < _sportsmen.Length)
                {
                    _sportsmen[indexer++] = sportsman;
                }
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null || _sportsmen.Length == 0) return;
                foreach (var sportsman in sportsmen)
                {
                    if (indexer < _sportsmen.Length)
                    {
                        _sportsmen[indexer++] = sportsman;
                    }
                }
            }
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                for (int i = 0; i < indexer; i++)
                {
                    _sportsmen[i].Print();
                }
            }
        }
    }
}
