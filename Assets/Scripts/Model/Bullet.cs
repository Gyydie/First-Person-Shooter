using UnityEngine;

namespace FirstShuter
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision) // todo своя обработка полета и получения урона
        {
            if (Type == AmmunitionType.Laser)
            {
                _curDamage = 100f;
            }

            // дописать доп урон
            var setDamage = collision.gameObject.GetComponent<ICollision>();

            if (setDamage != null)
            {
                setDamage.OnCollision(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
                    Rigidbody.velocity));
            }

            DestroyAmmunition();
        }
    }
}
