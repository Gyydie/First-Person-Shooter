using System;
using UnityEngine;


namespace FirstShuter
{
    public sealed class Aim : MonoBehaviour, ICollision, ISelectObj
    {
        public event Action OnPointChange = delegate { };

        public float Hp = 100;
        private bool _isDead;
        private float _timeToDestroy = 10.0f;
        [SerializeField] private float _minAbsorbedDamage = 0.5f;
        [SerializeField] private float _maxAbsorbedDamage = 10f;
        private float _absorbedDamage;

        public void CollisionEnter(InfoCollision info)
        {
            if (_isDead) return;
            _absorbedDamage = UnityEngine.Random.Range(_minAbsorbedDamage, _maxAbsorbedDamage);
            if (Hp > 0)
            {
                Hp -=(info.Damage - _absorbedDamage);
            }

            if (Hp <= 0)
            {
                if (!TryGetComponent<Rigidbody>(out _))
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                Destroy(gameObject, _timeToDestroy);

                OnPointChange.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return $"{gameObject.name} - {Hp}";
        }
    }
}
