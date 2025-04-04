using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class Helpers
{
    public static Guid CreateGuidFromString(string input)
    {
        return new Guid(MD5.Create().ComputeHash(Encoding.Default.GetBytes(input)));
    }

    public static Vector2 ClampToScreen(VisualElement element, Vector2 targetPosition)
    {
        float x = Mathf.Clamp(targetPosition.x, 0, Screen.width - element.layout.width);
        float y = Mathf.Clamp(targetPosition.y, 0, Screen.height - element.layout.height);

        return new Vector2(x, y);
    }


    public static WaitForSeconds GetWaitForSeconds(float seconds)
    {
        return WaitFor.Seconds(seconds);
    }

    /// <summary>
    /// Clears the console log in the Unity Editor.
    /// </summary
#if UNITY_EDITOR
    public static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method?.Invoke(new object(), null);
    }
#endif

}