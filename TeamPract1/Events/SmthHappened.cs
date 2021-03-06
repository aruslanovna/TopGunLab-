﻿
using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TeamPract1.Events
{
    public class SmthHappened
    {
        public const int maxScore = 3;
        public bool isActive = true;

        readonly TeamModule teamMod = new TeamModule();

     
        public delegate void ScoreHandler(object sender, GameEventArgs e);

        public event ScoreHandler ChangeScoreNotify;



        public void Whistle()
        {
            isActive = true;
            ChangeScoreNotify?.Invoke(this, new GameEventArgs(StringLiterals.Whistle));
        }


        public void Gol(int playerId, Game game)
        {
            try
            {
                var team = teamMod.GetList().Select(p => p).Where(p => p.players.Any(x => x.Id == playerId)).First();
                 if (isActive == true)
                            {
                                if (team?.result < game.MaxScore)
                                {
                                  //  team.result += 1;
                                    ChangeScoreNotify?.Invoke(this, new GameEventArgs("Goal!!!" + Environment.NewLine + $"Team {team.Name} scored a goal. Now they have {team.result} points"));
                                }
                                else
                                {
                    
                                    FinalResult();
                                }
                            }
            }
            catch
            {
                Console.WriteLine(StringLiterals.NoSuchPlayerInTeam);
            }
           

        }

        public void RefereePrefer(Referee referee)
        {
            if (isActive == true)
            {
                Team favTeam = referee.FavouriteTeam;
                favTeam.result += 3;
                ChangeScoreNotify?.Invoke(this, new GameEventArgs($" {referee.FavouriteTeam.Name} is lucky today.  Now they have {referee.FavouriteTeam.result}"));
                if (referee.FavouriteTeam.result >= maxScore)
                {

                    FinalResult();
                }
            }
        }

        public void CouchTime(Coach coach)
        {
            if (isActive == true)
            {
                Team team = coach.Team;
                if (coach.Experience >= 20)
                {
                    team.result += 3;
                }
                else if (coach.Experience >= 40)
                {
                    team.result += 4;
                }
                ChangeScoreNotify?.Invoke(this, new GameEventArgs($" {coach.Team} is getting bonus from couch"));
                if (team.result >= maxScore)
                {

                    FinalResult();
                }
            }

        }

       public  void FinalResult()
        {
            ChangeScoreNotify?.Invoke(this, new GameEventArgs(StringLiterals.Final));
            isActive = false;
        }
        
        public void ShowScore(Team team1,Team team2)
        {
            
                ChangeScoreNotify?.Invoke(this, new GameEventArgs($"{team1.Name} {team1.result} : {team2.Name} {team2.result}"));   
        }
    }
}
