using AriverseStudio.Singletons;
using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.SequenceSystem
{

    public class SequenceManager : Singleton<SequenceManager>
    {
        private int _currentSequenceIndex = 0;
        public int CurrentSequenceIndex => _currentSequenceIndex;

        public void ProgressSequence()
        {
            _currentSequenceIndex++;
            Debug.Log("Progress Sequence: " + _currentSequenceIndex);
        }


    }
}