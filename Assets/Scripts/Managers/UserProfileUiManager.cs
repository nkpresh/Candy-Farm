using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileUiManager : MonoBehaviour
{
    [SerializeField]
    GameObject PopupOverlay;
    void Start()
    {

    }

    void Update()
    {

    }

    public void onProfilePicClicked()
    {
        PopupOverlay.SetActive(true);
        foreach (Transform modal in PopupOverlay.transform)
        {
            if (modal.name == Popups.ProfilePictureModal.ToString())
            {
                modal.gameObject.SetActive(true);
            }
            else
            {
                modal.gameObject.SetActive(false);
            }
        }
    }
}

enum Popups
{
    ProfilePictureModal,
    HistoryPopupModal
}
