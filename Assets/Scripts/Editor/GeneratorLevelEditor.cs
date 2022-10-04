using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerateLevelView))]//связали компонент с данным классом
public class GeneratorLevelEditor : Editor
{
    private GenerateLevelController _generateLevelController;

    private void OnEnable()
    {
        var generatorLevelView = (GenerateLevelView)target;
        _generateLevelController = new GenerateLevelController(generatorLevelView);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if(GUI.Button (new Rect(10, 0, 60, 50), "Generate"))
            _generateLevelController.Awake();

        if (GUI.Button(new Rect(10, 55, 60, 50), "Clear"))
            _generateLevelController.ClearTileMap();

        GUILayout.Space(100);


        serializedObject.ApplyModifiedProperties();
    }
}
