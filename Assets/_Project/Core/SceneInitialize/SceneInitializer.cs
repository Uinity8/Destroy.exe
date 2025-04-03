using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneInitializer : MonoBehaviour
{
    /// <summary>
    /// 씬별 초기화 로직
    /// </summary>
    public abstract void Initialize();
}