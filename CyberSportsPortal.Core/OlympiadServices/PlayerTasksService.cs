using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.OlympiadServices;

public class PlayerTasksService
{
    public List<PlayerView> FilterPlayers(List<PlayerView> players, string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return players;

        string lowerFilter = filter.ToLower();

        return players
            .Where(player =>
                (player.NickName != null && player.NickName.ToLower().Contains(lowerFilter)) ||
                (player.CombinedName != null && player.CombinedName.ToLower().Contains(lowerFilter))
            )
            .ToList();
    }
}