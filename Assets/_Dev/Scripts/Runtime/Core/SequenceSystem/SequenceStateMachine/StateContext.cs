using System.Collections.Generic;
using UnityEngine;
using VozSoldat.StateMachine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.SequenceSystem
{

    public class StateContext : StateContext<StateEnum, StateContext>
    {
        public override Dictionary<StateEnum, AbstractState<StateContext>> StateMap => throw new System.NotImplementedException();
        private Dictionary<StateEnum, AbstractState<StateContext>> _stateMap = new Dictionary<StateEnum, AbstractState<StateContext>>()
        {
            
        };
    }
}