using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets
{
    public class GameManager
    {
        private static GameManager instance = null;

        public List<Item> itemList;
        public List<Quest> questList;

        private GameManager()
        {
            itemList = new List<Item>();
            questList = new List<Quest>();
        }

        public static GameManager GetInstance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
}


