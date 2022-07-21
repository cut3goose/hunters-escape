using System;
using System.Linq;
using UnityEngine;

public class LevelRatingCalculator : Singleton<LevelRatingCalculator>
{
    [SerializeField] private LevelRatingConfig ratingConfig;

    public int GetRatingStarsAmount()
    {
        var kills = LevelStatistics.Instance.EnemiesKilled;

        for (int i = 0; i < ratingConfig.Ratings.Count - 1; i++)
        {
            var current = ratingConfig.Ratings[i].KillsRequired;
            var next = ratingConfig.Ratings[i + 1].KillsRequired;

            if (kills >= current && kills < next)
            {
                return ratingConfig.Ratings[i].StarsGiven;
            }
        }

        return ratingConfig.Ratings.Last().StarsGiven;
    }

    public int GetMaxRequiredKills()
    {
        return ratingConfig.Ratings.First(r => r.StarsGiven == 3).KillsRequired;
    }
}
