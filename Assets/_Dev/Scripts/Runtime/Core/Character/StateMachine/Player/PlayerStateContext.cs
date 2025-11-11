using System.Collections.Generic;
using UnityEngine;
using VozSoldat.StateMachine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.Character.StateMachine
{

    public class PlayerStateContext : StateContext<PlayerStateEnum, PlayerStateContext>
    {
        public override Dictionary<PlayerStateEnum, AbstractState<PlayerStateContext>> StateMap => throw new System.NotImplementedException();
    }
}