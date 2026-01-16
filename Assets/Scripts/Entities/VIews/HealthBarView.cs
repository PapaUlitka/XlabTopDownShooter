using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Entities.VIews
{
    public class HealthBarView : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
    }
}