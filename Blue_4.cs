using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private List<int> _scores;
            public string Name { get { return _name; } }
            public int[] Scores 
            { 
                get 
                {
                    if (_scores == null) return new int[0];
                    return _scores.ToArray(); 
                } 
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    return _scores.Sum();
                }
            }
            public Team(string name)
            {
                _name = name;
                _scores = new List<int>();
            }
            public void PlayMatch(int result)
            {
                if (_scores == null) _scores = new List<int>();
                _scores.Add(result);
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
            private int indexer;
            public string Name { get { return _name; } }
            public Team[] Teams 
            { 
                get 
                {
                    if (_teams == null) return new Team[0];
                    return _teams.Take(indexer).ToArray();
                } 
            }
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                indexer = 0;
            }
            public void Add(Team team)
            {
                if (_teams == null || indexer >= _teams.Length) return;
                _teams[indexer++] = team;
            }
            public void Add(Team[] teams)
            {
                if (teams == null || teams.Length == 0 || _teams == null) return;
                foreach (var team in teams)
                {
                    if (indexer < _teams.Length)
                    {
                        _teams[indexer++] = team;
                    }
                }
            }
            public void Sort()
            {
                if (_teams == null || indexer == 0) return;
                for (int i = 0; i < indexer - 1; i++)
                {
                    for (int j = 0; j < indexer - i - 1; j++)
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
                Group group = new Group("Финалисты");
                int i = 0;
                int j = 0;
                int count = 0;
                
                // First sort both groups
                group1.Sort();
                group2.Sort();

                while (i < group1.indexer && j < group2.indexer && count < size)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        group.Add(group1.Teams[i++]);
                    }
                    else
                    {
                        group.Add(group2.Teams[j++]);
                    }
                    count++;
                }

                while (i < group1.indexer && count < size)
                {
                    group.Add(group1.Teams[i++]);
                    count++;
                }

                while (j < group2.indexer && count < size)
                {
                    group.Add(group2.Teams[j++]);
                    count++;
                }

                return group;
            }
            public void Print()
            {
                Console.WriteLine($"{Name}");
                for (int i = 0; i < indexer; i++)
                {
                    _teams[i].Print();
                }
            }
        }
    }
}
