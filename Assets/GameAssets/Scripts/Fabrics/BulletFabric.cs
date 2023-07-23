using GameAssets.Scripts.Main;
using GameAssets.Scripts.Player;
using UnityEngine;

namespace GameAssets.Scripts.Fabrics
{
    public class BulletFabric: GenericFabric<Bullet>
    {
        public override Bullet GetObject<TFabricConfig>(TFabricConfig config, Vector3 pos)
        {
            var bullet = Instantiate(prefab, pos, Quaternion.identity);
            bullet.Configurate(config);
            return bullet;
        }
    }

    public class BulletFabricConfig: FabricConfig
    {
        public Vector3 Direcion { get; private set; }
        public int Damage { get; private set; }
        public float Velocity { get; private set; }

        public BulletFabricConfig(GameConfig config, Vector3 direction)
        {
            Direcion = direction;
            Damage = config.PlayerDamage;
            Velocity = config.PlayerBulletSpeed;
        }
    }
}