using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guessframework
{
    [System.Serializable]
    public class Guess
    {
        public string _QuesAns;
        public Sprite img;
        public List<string> buzz;
        public List<string> Clue;
        public List<string> Facts;
        public Available availablity;
    }

    [System.Serializable]
    public class Available
    {
        public bool isAvailable;
        public enum Type { CITY, ANIMAL, BIRD }
        public Type type;
    }
}

