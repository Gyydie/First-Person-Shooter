using UnityEngine;

namespace FirstShuter
{
    public sealed class InputController : BaseController, IExecute, IOnUpdate
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel     = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;

        private KeyCode _savePlayer = KeyCode.C;
        private KeyCode _loadPlayer = KeyCode.V;
        private KeyCode _screenshot = KeyCode.Q;

        private int _mouseButton = (int)MouseButton.LeftButton;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        public void OnUpdate()
        {
            if (!IsActive) return;

            if (Input.GetKeyDown(_savePlayer))
            {
                Main.Instance.SaveDataRepository.Save();
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                Main.Instance.SaveDataRepository.Load();
            }

            //if (Input.GetKeyDown(_screenshot))
            //{
            //    Main.Instance.PhotoController.SecondMethod();
            //}
        }


        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                //ServiceLocator.Resolve<FlashLightController>().Switch(ServiceLocator.Resolve<Inventory>().FlashLight);
            }

            float ChoiceOfWeapon = Input.GetAxis("Mouse ScrollWheel");

            if (ChoiceOfWeapon > 0)
            {
                SelectWeapon(0);
            }

            if (ChoiceOfWeapon < 0)
            {
                SelectWeapon(1);
            }

            if (Input.GetMouseButton(_mouseButton))
            {
                if (ServiceLocator.Resolve<WeaponController>().IsActive)
                {
                    ServiceLocator.Resolve<WeaponController>().Fire();
                }
            }

            if (Input.GetKeyDown(_cancel))
            {
                ServiceLocator.Resolve<WeaponController>().Off();
                ServiceLocator.Resolve<FlashLightController>().Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                if (ServiceLocator.Resolve<WeaponController>().IsActive)
                {
                    ServiceLocator.Resolve<WeaponController>().ReloadClip();
                }
            }
        }


        /// <summary>
        /// Выбор оружия
        /// </summary>
        /// <param name="i">Номер оружия</param>
        private void SelectWeapon(int i)
        {
            ServiceLocator.Resolve<WeaponController>().Off();
            var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; //todo инкапсулировать
            if (tempWeapon != null)
            {
                ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
            }
        }
    }
}
