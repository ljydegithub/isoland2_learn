using System.Collections.Generic;
using UnityEngine.UI;

public class GameSaveData 
{
    public int gameWeek;

    public string currentScene;

    public Dictionary<string, bool> miniGameStateDict;

    public Dictionary<ItemName, bool> itemAvailableDict;

    public Dictionary<InteractiveName, bool> interactiveStateDict;

    public List<ItemName> itemList;
}
