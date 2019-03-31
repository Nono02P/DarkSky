using Microsoft.Xna.Framework;

namespace DarkSky
{
    public class SceneManager
    {
        public static Scene CurrentScene { get; private set; }

        public static void ChangeScene(SceneType pSceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.UnLoad();
                CurrentScene = null;
            }
            switch (pSceneType)
            {
                case SceneType.Menu:
                    CurrentScene = new Menu();
                    break;
                case SceneType.Gameplay:
                    CurrentScene = new Gameplay();
                    break;
                case SceneType.Gameover:
                    CurrentScene = new Gameover();
                    break;
                case SceneType.Victory:
                    CurrentScene = new Victory();
                    break;
                case SceneType.HowToPlay:
                    CurrentScene = new HowToPlay();
                    break;
                default:
                    break;
            }
            MainGame.Camera.Enable = false;
            MainGame.Camera.Position = Vector3.Zero;
            CurrentScene.Load();
        }
    }
}