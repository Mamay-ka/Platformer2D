using UnityEngine;

[CreateAssetMenu(fileName = "QuestConfig", menuName = "Quest/QuestConfig")]
public class QuestConfig : ScriptableObject
{
    [SerializeField]
    private int _id;

    [SerializeField]
    private QuestType _questTypes;

    public int Id => _id; 
    public QuestType QuestTypes => _questTypes; 
}

public enum QuestType
{
    Switch//тип квеста - переключатель
}