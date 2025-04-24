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
            private int[] _scores;
            public string Name { get { return _name; } }
            public int[] Scores 
            { 
                get 
                {
                    if (_scores == null) return null;
                    return _scores; 
                } 
            }
            public int TotalScore
            {
                get
                {
                    int s = 0;
                    foreach (int x in  _scores)
                    {
                        s += x;
                    }
                    return s;
                }
            }
            public Team (string name)
            {
                _name = name;
                _scores = new int[0];
            }
            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                int[] newscores = new int[_scores.Length + 1];
                newscores[newscores.Length - 1] = result;
                for(int i = 0; i  < _scores.Length; i++)
                {
                    newscores[i] = _scores[i];
                }
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
            private int indexer;
            public string Name { get { return _name; } }
            public Team[] Teams { get { return _teams; } }
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                indexer = 0;
            }
            public void Add(Team team)
            {
                if (_teams == null || _teams.Length == 0 || indexer >= _teams.Length) return;
                _teams[indexer] = team;
                indexer++;
            }
            public void Add(Team[] teams)
            {
                if (teams == null || teams.Length == 0 || _teams == null || _teams.Length == 0 || indexer >= _teams.Length) return;
                int i = 0;
                while (indexer < _teams.Length && i < teams.Length)
                {
                    _teams[indexer] = teams[i];
                    i++;
                    indexer++;
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
                Group group = new Group("Финалисты");
                int i = 0;
                int j = 0;
                while (i < size / 2 && j < size / 2)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        group.Add(group1.Teams[i++]);
                    }
                    else
                    {
                        group.Add(group2.Teams[j++]);
                    }
                }
                while (i < size / 2)
                {
                    group.Add(group1.Teams[i++]);
                }
                while (j < size / 2)
                {
                    group.Add(group2.Teams[j++]);
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
