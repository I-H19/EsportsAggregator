using CyberSportsPortal.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.OlympiadServices;

public class TeamTasksService
{
    public int GetTeamIncomeForYear(Team team, int year)
    {
        int totalIncome = 0;

        foreach (TournamentParticipantInfo result in team.TeamTournamentResults)
        {
            Tournament tournament = result.Tournament;
            if (tournament == null || result.Place == null)
                continue;

            if (tournament.EndDate.Year != year)
                continue;

            TournamentPrize prize = tournament.TournamentPrizes
                ?.FirstOrDefault(p => p.Place == result.Place.Value);

            if (prize != null)
            {
                totalIncome += prize.Prize;
            }
        }

        return totalIncome;

    }


    public List<Rating> GetNewRatings(List<MatchHistory> matches, List<Rating> oldRatings)
    {
        return oldRatings;
    }
}