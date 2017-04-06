using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameLevel
{
    int GetKey();
    List<BlockType> GetBlocksMap();
    List<BonusType> GetBonusesMap();
}
