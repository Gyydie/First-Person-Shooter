namespace FirstShuter
{
    public sealed class PlayerController : BaseController, IOnUpdate
    {
        private readonly IMotor _motor;

        public PlayerController(IMotor motor)
        {
            _motor = motor;
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            _motor.Move();
        }
    }
}
