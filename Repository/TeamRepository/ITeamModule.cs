﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public interface ITeamModule
    {
        List<Team> GetList();
        List<Team> ChooseTeamsForGame();
        // Team RandomTeam();
        // List<Team> ChooseTeams(List<Team> allTeams, List<Team> players);
         Team ChooseRandomTeam();
        Team GetTeamById(int Id);
        void AddToTeam(int IdPlayer, int IdTeam);
    }
}
