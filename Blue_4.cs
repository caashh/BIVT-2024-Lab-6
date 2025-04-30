using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            private int _scoresCount;
            
            public string Name { get { return _name; } }
            public int[] Scores 
            { 
                get 
                {
                    if (_scores == null) return new int[0];
                    int[] result = new int[_scoresCount];
                    Array.Copy(_scores, result, _scoresCount);
                    return result;
                } 
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null || _scoresCount == 0) return 0;
                    int sum = 0;
                    for (int i = 0; i < _scoresCount; i++)
                    {
                        sum += _scores[i];
                    }
                    return sum;
                }
            }
            
            public Team(string name)
            {
                _name = name;
                _scores = new int[10];
                _scoresCount = 0;
            }
            
            public void PlayMatch(int result)
            {
                if (_scores == null) _scores = new int[10];
                
                if (_scoresCount >= _scores.Length)
                {
                    int[] newScores = new int[_scores.Length * 2];
                    Array.Copy(_scores, newScores, _scoresCount);
                    _scores = newScores;
                }
                
                _scores[_scoresCount++] = result;
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
            public Team[] Teams 
            { 
                get 
                {
                    if (_teams == null) return new Team[0];
                    Team[] result = new Team[_teamsCount];
                    Array.Copy(_teams, result, _teamsCount);
                    return result;
                } 
            }
            
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _teamsCount = 0;
            }
            
            public void Add(Team team)
            {
                if (_teams == null) _teams = new Team[12];
                if (_teamsCount >= _teams.Length) return;
                
                _teams[_teamsCount++] = team;
            }
            
            public void Add(Team[] teams)
            {
                if (teams == null || _teams == null) return;
                
                foreach (var team in teams)
                {
                    if (_teamsCount >= _teams.Length) break;
                    _teams[_teamsCount++] = team;
                }
            }
            
            public void Sort()
            {
                if (_teams == null || _teamsCount <= 1) return;
                
                for (int i = 0; i < _teamsCount - 1; i++)
                {
                    for (int j = 0; j < _teamsCount - i - 1; j++)
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
                group1.Sort();
                group2.Sort();
                
                Group result = new Group("Финалисты");
                int i = 0, j = 0;
                int count = 0;
                
                while (count < size && i < group1._teamsCount && j < group2._teamsCount)
                {
                    if (group1._teams[i].TotalScore >= group2._teams[j].TotalScore)
                    {
                        result.Add(group1._teams[i++]);
                    }
                    else
                    {
                        result.Add(group2._teams[j++]);
                    }
                    count++;
                }
                
                while (count < size && i < group1._teamsCount)
                {
                    result.Add(group1._teams[i++]);
                    count++;
                }
                
                while (count < size && j < group2._teamsCount)
                {
                    result.Add(group2._teams[j++]);
                    count++;
                }
                
                return result;
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
