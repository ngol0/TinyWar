﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using Strategy.Grid;

namespace Strategy
{
    class SceneRenderSystem : EntityDrawSystem
    {
        SpriteBatch spriteBatch;
        private ComponentMapper<Transform> transformMapper;
        private ComponentMapper<Sprite> spriteMapper;

        public SceneRenderSystem(SpriteBatch spriteBatch) : base(Aspect.All(typeof(Sprite), typeof(Transform)).Exclude(typeof(GridItem)))
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            transformMapper = mapperService.GetMapper<Transform>();
            spriteMapper = mapperService.GetMapper<Sprite>();
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var entityId in ActiveEntities)
            {
                var transform = transformMapper.Get(entityId);
                var sprite = spriteMapper.Get(entityId);

                spriteBatch.Draw(
                    sprite.texture,
                    new Rectangle((int)transform.worldPos.X, (int)transform.worldPos.Y, transform.scale, transform.scale),
                    null,
                    sprite.color,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0f);
            }
        }
    }
}
