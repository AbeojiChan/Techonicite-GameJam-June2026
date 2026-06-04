using UnityEngine;

namespace Levels.Runtime
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private LevelData m_startLevel;

        private async void Start()
        {
            await LevelManager.Load(m_startLevel);
        }
    }

}