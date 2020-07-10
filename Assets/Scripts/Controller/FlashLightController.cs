﻿namespace FirstShuter
{
    public sealed class FlashLightController : BaseController, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;

        public void Initialization()
        {
            UiInterface.LightUiText.SetActive(false);
        }

        public override void On(params BaseObjectScene[] flashLight)
        {
            if (IsActive) return;
            if (flashLight.Length > 0) _flashLightModel = flashLight[0] as FlashLightModel;
            if (_flashLightModel == null) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
            base.On(_flashLightModel);
            _flashLightModel.Switch(FlashLightActiveType.On);
            UiInterface.LightUiText.SetActive(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) _flashLightModel.BatteryRecharge();
            base.Off();
            _flashLightModel.Switch(FlashLightActiveType.Off);
            UiInterface.LightUiText.SetActive(false);
        }

        public void Execute()
        {
            if(!IsActive)
            {
                return;
            }
            if (_flashLightModel.EditBatteryCharge())
            {
                UiInterface.LightUiText.Text = _flashLightModel.BatteryChargeCurrent;
                _flashLightModel.Rotation();
            }
            //else if (!_flashLightModel.BatteryRecharge())
            //{
            //    Off();
            //}
            else
            {
                Off();
            }
        }
    }
}
