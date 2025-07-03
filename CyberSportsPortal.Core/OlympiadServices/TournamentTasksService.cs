using CyberSportsPortal.Data.Entities;
using CyberSportsPortal.Data.Model.Constants;
using CyberSportsPortal.Data.Model.Enums;
using CyberSportsPortal.Data.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.OlympiadServices;

public class TournamentTasksService
{
    public string GetTournamentStatus(Tournament tournament)
    {

        DateTimeOffset currentDateTime = DateTimeOffset.UtcNow;

        if (currentDateTime < tournament.StartDate)
            return DatabaseDefaults.TOURNAMENT_DONT_START_MESSAGE;

        if (currentDateTime > tournament.EndDate)
            return DatabaseDefaults.TOURNAMENT_END_MESSAGE;

        return DatabaseDefaults.TOURNAMENT_IN_PROGRESS_MESSAGE;

    }

    public int GetPlayersFromCountryCount(List<Player> players, Country country)
    {
        return players.Count(player => player.Country == country);
    }

    public string GetTeamParticipantsNameString(List<Team> teams)
    {
        string result = string.Empty;
        for (int i = 0; i < teams.Count; i++)
        {
            result += teams[i].Name + ", ";
        }

        return result;
    }

    public int ComparePrizes(string prizeA, string prizeB)
    {
        if (prizeA == prizeB)
            return 0;
        if (prizeA[prizeA.Length - 1] > prizeB[prizeB.Length - 1])
            return 1;
        else
            return -1;
    }

    public Dictionary<int, decimal> GetTournamentVictoryProbabilities(List<TeamWithVictoryProbabilities> teams, Dictionary<int, int> standings)
    {
        return new Dictionary<int, decimal>();
    }
}