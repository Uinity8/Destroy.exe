using _01_Scripts.UI.Scene;
using Managers;

namespace Framework
{
    public class MainMenuInitializer : SceneInitializer
    {
        public override void Initialize()
        {
            // 메인 메뉴 UI 표시
            UIManager.Instance.ShowUI<UITitleScene>();
        }
    }
}