using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "CandyFarm/Profile/Avatar")]
public class ProfilePictureDataSO : ScriptableObject
{
    [SerializeField]
    Sprite[] profileImages;

    public Sprite GetImage(int Index)
    {
        Sprite profileImage = null;
        if (Index < profileImages.Length && Index > -1)
        {
            profileImage = profileImages[Index];
        }
        return profileImage;
    }

    public Sprite[] GetAllProfileImages()
    {
        return profileImages;
    }
}