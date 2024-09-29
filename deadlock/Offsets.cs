using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deadlock
{
    internal static class Offsets
    {
        internal static IntPtr dwEntityList = 0x1f4a2e8;
        internal static IntPtr ViewMatrix = 0x2108e70;
        internal static IntPtr LocalPlayerController = 0x20f7168;
        internal static IntPtr CCitadelCameraManager = 0x1f6bbf0;

        internal static IntPtr m_boneArray = 0x80;
        //use https://a2x.github.io/cs2-analyzer/# for offsets
        //C_CitadelBaseAbility
        //CitadelHeroData_t
        //C_BaseModelEntity
        //C_BasePlayerWeapon
        //CCollisionProperty
        //CCitadelPlayer_ObserverServices
    }
}


