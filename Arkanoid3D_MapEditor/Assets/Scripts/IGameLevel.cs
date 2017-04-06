using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameLevel
{
    int GetKey();
    BlockType[] GetBlocksMap();
    BonusType[] GetBonusesMap();
}
