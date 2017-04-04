using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToolColors
{
    Color GetBlockColor(char blockKey);
    Color GetBonusColor(char bonusKey);
}