using Assets.Scripts.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.VisualScripting;

namespace Assets.Scripts.Infrastructure.States
{
    public class GameplayExitState : IState
    {
        private readonly SpawnerEnemy m_spawnerEnemy;

        public GameplayExitState(SpawnerEnemy spawnerEnemy)
        {
            m_spawnerEnemy = spawnerEnemy;
        }

        public void Enter()
        {
            var loading = ServiceLocator.Resolve<Loading>();
            m_spawnerEnemy.DespawnAll();

            loading.LoadScene(GlobalConstants.Scenes.Main);
        }

        public void Exit() { }
    }
}
