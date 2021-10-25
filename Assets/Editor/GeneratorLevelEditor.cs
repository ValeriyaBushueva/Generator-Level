using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerateLevelView))]
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
      if(GUI.Button(new Rect(10,0,100,50), "Generate"))
      {
         _generateLevelController.Awake();
      }
      GUILayout.Space(100);
   }
}
