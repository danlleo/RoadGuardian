using Zenject;

namespace Content.Features.BulletModule.Scripts
{
    public class BulletPool : MonoMemoryPool<Bullet>
    {
        protected override void OnDespawned(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        protected override void OnSpawned(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }
    }
}