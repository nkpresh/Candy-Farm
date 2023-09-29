using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSettings
{
    public enum AudioGroup
    {
        Sfx,
        BgMusic,
        Ambience
    }

    public struct AudioClipNames
    {
        public enum Sfx
        {
            ButtoClick,
            CandyCatch,
            MenuPopup,
            NftCatch,
            SlideInandOut,
            Winner,
            WrongCandy
        }
        public enum BgMusic
        {
            InGame1,
            InGame2,
            MenuMusic
        }
        public enum Ambience
        {
            Ambience
        }
    }
}
