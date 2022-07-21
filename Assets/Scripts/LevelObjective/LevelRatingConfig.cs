using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Rating/LevelRatingConfig")]
public class LevelRatingConfig : ScriptableObject
{
    public List<Rating> Ratings;
}