using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guessframework
{
    [CreateAssetMenu(fileName = "Guess", menuName = "GuessGame/City")]

    public class GuessAns : ScriptableObject
    {
        public List<Guess> guess;
    }
    
}
