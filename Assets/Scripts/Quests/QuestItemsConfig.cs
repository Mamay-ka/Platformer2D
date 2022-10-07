using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestItemConfig", menuName = "Quest/QuestItemConfig")]

public class QuestItem : ScriptableObject
{
    [SerializeField]
    private int _questId;

    [SerializeField]
    private List<int> _questItemIdCollection;

    public int QuestId => _questId; 
    public List<int> QuestItemIdCollection => _questItemIdCollection; 
}
    

