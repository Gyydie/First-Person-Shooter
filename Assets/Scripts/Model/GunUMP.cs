namespace FirstShuter
{
    public sealed class GunUMP : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.forward * _force);
            temAmmunition.transform.localScale = new UnityEngine.Vector3(0.3f, 0.3f, 0.3f);
            Clip.CountAmmunition--;
            _isReady = false;
            _timeRemaining.AddTimeRemaining();
        }
    }
}