using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;


            public string Name { get { return _name; } }
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    int[] newscores = new int[_scores.Length];
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        newscores[i] = _scores[i];
                    }
                    return newscores;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        sum += _scores[i];
                    }
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (_scores == null) return;

                int[] newscores = new int[_scores.Length + 1];
                for (int i = 0; i < newscores.Length - 1; i++)
                {
                    newscores[i] = _scores[i];
                }
                newscores[newscores.Length - 1] = result;
                _scores = newscores;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {TotalScore}");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _teamsCount;

            public string Name { get { return _name; } }
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _teamsCount = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null || _teamsCount >= _teams.Length) return;
                _teams[_teamsCount++] = team;
            }

            public void Add(Team[] teams)
            {

                if (teams == null || _teams == null || teams.Length == 0) return;

                int count = 0;
                while (_teamsCount < _teams.Length && count < teams.Length)
                {
                    _teams[_teamsCount++] = teams[count++];
                }
            }

            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;

                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            Team temp = _teams[j];
                            _teams[j] = _teams[j + 1];
                            _teams[j + 1] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");
                int halfSize = size / 2;
                int i = 0, j = 0;

                while (i < halfSize && j < halfSize)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        finalists.Add(group1.Teams[i]);
                        i++;
                    }
                    else
                    {
                        finalists.Add(group2.Teams[j]);
                        j++;
                    }
                }
                while (i < halfSize)
                {
                    finalists.Add(group1.Teams[i]);
                    i++;
                }
                while (j < halfSize)
                {
                    finalists.Add(group2.Teams[j]);
                    j++;
                }

                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}");
                for (int i = 0; i < _teamsCount; i++)
                {
                    _teams[i].Print();
                }
            }
        }
    }
}
