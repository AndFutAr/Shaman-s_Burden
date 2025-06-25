using UnityEngine;

namespace Project.Scripts.Seasons
{
    public class Season : MonoBehaviour
    {
        public int[] needItems = {0, 0, 0};

        public void PutItem(int id, int item)
        {
            if(item == 0) return;
            needItems[id] = item;
        }
        public bool IsAllItems()
        {
            if (needItems[0] == 1 && needItems[1] == 1 && needItems[2] == 1) return true;
            else return false;
        }
    }
}