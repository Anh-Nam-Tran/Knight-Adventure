using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponSwap : CoreComponent
    {
        public event Action<WeaponSwapChoiceRequest> OnChoiceRequested;
        public event Action<WeaponDataSO> OnWeaponDiscarded;

        private InteractableDetector interactableDetector;
        private WeaponInventory weaponInventory;

        private WeaponDataSO newWeaponData;

        private WeaponPickup weaponPickup;

        private void HandleTryInteract(IInteractable interactable)
        {
            //Kiểm tra Interactable có phải WeaponPickup không, nếu không thì return để tránh throw exception
            if (interactable is not WeaponPickup pickup)
                return;

            //Gán giá trị cho biến weaponPickup và gán giá trị Data vào cho newWeaponData
            weaponPickup = pickup;

            newWeaponData = weaponPickup.GetContext();

            //Check xem còn slot trống trong inventory không, nếu có thì đặt weapon vào đó qua TrySetWeapon, gọi tới hàm Interact() (Hàm này sẽ 
            //destroy gameObject interactable, tức là xóa gameObject weaponPickup đi), sau đó gán newWeaponData là null. 
            if (weaponInventory.TryGetEmptyIndex(out var index))
            {
                weaponInventory.TrySetWeapon(newWeaponData, index, out _);
                interactable.Interact();
                newWeaponData = null;
                return;
            }

            //Nếu Inventory không còn slot, thì gọi tới event OnChoiceRequested (nó sẽ hỏi người chơi muốn discard vũ khí nào trong inventory)
            //và khởi tạo object WeaponSwapChoiceRequest. Hàm GetWeaponSwapChoice() sẽ trả về danh sách lựa chọn các vũ khí muốn đổi
            OnChoiceRequested?.Invoke(new WeaponSwapChoiceRequest(
                HandleWeaponSwapChoice,
                weaponInventory.GetWeaponSwapChoices(),
                newWeaponData
            ));
        }


        //Hàm này sẽ thực hiện chức năng gán giá trị null cho biến newWeaponData và sau đó gọi tới event OnWeaponDiscarded (Gọi tới một hàm
        //HandleWeaponDiscarded có chức năng spawn ra một object weaponPickUp)
        private void HandleWeaponSwapChoice(WeaponSwapChoice choice)
        {
            if (!weaponInventory.TrySetWeapon(newWeaponData, choice.Index, out var oldData)) 
                return;
            
            newWeaponData = null;

            OnWeaponDiscarded?.Invoke(oldData);
                
            if (weaponPickup is null)
                return;

            weaponPickup.Interact(); 
        }

        protected override void Awake()
        {
            base.Awake();

            interactableDetector = core.GetCoreComponent<InteractableDetector>();
            weaponInventory = core.GetCoreComponent<WeaponInventory>();
        }

        private void OnEnable()
        {
            interactableDetector.OnTryInteract += HandleTryInteract;
        }


        private void OnDisable()
        {
            interactableDetector.OnTryInteract -= HandleTryInteract;
        }
    }
