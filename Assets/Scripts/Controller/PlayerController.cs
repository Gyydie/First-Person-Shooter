namespace FirstShuter
{
    public sealed class PlayerController : BaseController, IExecute, IOnUpdate
    {
        private readonly IMotor _motor;

        public PlayerController(IMotor motor)
        {
            _motor = motor;
        }

        public void Execute()
        {
            if (!IsActive) return;
            _motor.Move();
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            _motor.Move();
        }
    }
}
