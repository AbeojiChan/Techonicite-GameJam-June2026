using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Levels.Runtime
{
    public class LevelManager : MonoBehaviour

    {

        #region Main API

        public static async Task Load(LevelData level)
        {
            if (_level != null)
            {

                for (int i = 0; i < _level.m_scenes.Count; i++)
                {
                    var path = _level.m_scenes[i].ScenePath;
                    AsyncOperation unload = SceneManager.UnloadSceneAsync(path);
                    while (!unload.isDone) await Task.Yield();
                }
            }



            if (level == null) return;
            _level = level;
            if (level.m_scenes.Count == 0) return;
            List<SceneReference> scenes = level.m_scenes;
            for (int i = 0; i < scenes.Count; i++)
            {
                var path = scenes[i].ScenePath;
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(path, LoadSceneMode.Additive);
                while (!asyncOperation.isDone) await Task.Yield();
            }
        }

     

        #endregion


        #region Private and Protected

        private static LevelData _level;

        #endregion

    }
}
