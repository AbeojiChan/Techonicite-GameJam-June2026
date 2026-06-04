using System;
using UnityEditor;

namespace Levels.Runtime
{
    [Serializable]
    public class SceneReference
    {
        #region Publics

#if UNITY_EDITOR
        public SceneAsset m_sceneAsset;
#endif

        public string ScenePath => m_scenePath;
        public string SceneName => m_sceneName;

        #endregion


        #region Utils

        public void Sync()
        {
#if UNITY_EDITOR
            m_scenePath = m_sceneAsset ? AssetDatabase.GetAssetPath(m_sceneAsset) : string.Empty;
            m_sceneName = m_sceneAsset ? m_sceneAsset.name : string.Empty;
#endif
        }

        #endregion


        #region Private and Protected

        public string m_scenePath;
        public string m_sceneName;

        #endregion
    }
}