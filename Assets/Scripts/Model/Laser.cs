using UnityEngine;

namespace FirstShuter
{
    public sealed class Laser : Ammunition
    {
        private void OnCollisionEnter(Collision collision) // todo своя обработка полета и получения урона
        {
            _curDamage = 100f;

            var setDamage = collision.gameObject.GetComponent<ICollision>();

            if (setDamage != null)
            {
                setDamage.CollisionEnter(new InfoCollision(_curDamage, Rigidbody.velocity));
            }

            DestroyAmmunition();
        }
    }
}
