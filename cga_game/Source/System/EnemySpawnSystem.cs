﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended;

namespace Strategy
{
    class EnemySpawnSystem : EntityProcessingSystem
    {
        Scene scene;

        private ComponentMapper<EnemySpawner> enemySpawnerMapper;
        private ComponentMapper<Transform> transformMapper;

        public EnemySpawnSystem(Scene scene) : base(Aspect.All(typeof(EnemySpawner), typeof(Transform)))
        {
            this.scene = scene;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            enemySpawnerMapper = mapperService.GetMapper<EnemySpawner>();
            transformMapper = mapperService.GetMapper<Transform>();
        }

        public override void Process(GameTime gameTime, int entityId)
        {
            var enemySpawner = enemySpawnerMapper.Get(entityId);
            var transform = transformMapper.Get(entityId);

            enemySpawner.currentTimer += gameTime.GetElapsedSeconds();

            if (enemySpawner.currentTimer > enemySpawner.spawnMaxTime)
            {
                //get a random enemy from enemy data list
                int randomIndex = RandomUtils.Rand(0, EnemyTypeList.enemyTypeList.Count);
                var enemyType = EnemyTypeList.enemyTypeList[randomIndex];

                //spawn enemy
                var enemy = Globals.entityFactory.CreateEnemy(
                    new Transform() { gridPos = transform.gridPos, worldPos = transform.worldPos, scale = transform.scale }, 
                    enemyType);

                scene.EnemyManager.AddEnemyToLane(transform.gridPos.y);
                enemy.Get<BoxCollider2D>().OnCollisionEnter += scene.EnemyCollisionResponse;

                enemySpawner.currentTimer = 0;
                enemySpawner.spawnMaxTime = RandomUtils.Rand(10, 20);
            }
        }
    }
}
