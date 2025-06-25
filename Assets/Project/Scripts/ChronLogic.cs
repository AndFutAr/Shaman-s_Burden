using System.Collections;
using Project.Scripts.Seasons;
using Project.Scripts.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class ChronLogic : MonoBehaviour
    {
        //модуль квестов
        [SerializeField] private Image[] keysImage;
        [SerializeField] private bool[] isKey = { false, false, false, false };
        [SerializeField] private Season[] SeasonsQuest;
        private Season currentQuest;
        private int thisQuest;
        
        //модуль измерения
        [SerializeField] private int thisSeason = 0;
        [SerializeField] private GameObject[] Seasons;
        private GameObject currentSeason;
        
        [SerializeField] private GameObject player; 
        public int[] cell = {0, 0, 0};
        private int currentCell = 0;
        public void GetItem(int itemID, int itemNumber) => cell[itemID] = itemNumber;

        private void Start()
        {
            thisQuest = 0;
            currentQuest = SeasonsQuest[thisQuest];
            
            thisSeason = 0;
            currentSeason = Seasons[thisSeason];
            StartCoroutine(ChangeSeason());
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                RaycastHit HallHit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HallHit))
                {
                    if (HallHit.transform.gameObject.layer == LayerMask.NameToLayer("ItemTrigger"))
                    {
                        int id, num;
                        id = HallHit.transform.GetComponent<ItemNumber>().Id;
                        num = HallHit.transform.GetComponent<ItemNumber>().Number;
                        if (num == thisQuest + 1)
                        {
                            Destroy(HallHit.transform.gameObject);
                            GetItem(id, num);
                        }
                    }
                    else if (HallHit.transform.gameObject.layer == LayerMask.NameToLayer("SeasonTrigger"))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (cell[i] > 0)
                            {
                                HallHit.transform.GetComponent<Season>().PutItem(i, cell[currentCell]);
                                cell[i] = 0;
                            }
                        }
                    }
                }
            }

            if (currentQuest.IsAllItems())
            {
                keysImage[thisQuest].color = Color.white;
                isKey[thisQuest] = true;
            }
        }

        IEnumerator ChangeSeason()
        {
            while (true)
            {
                int timeToChange = Random.Range(4, 5);
                yield return new WaitForSeconds(timeToChange);
                thisSeason++;
                if(thisSeason > 3) thisSeason = 0;
                currentSeason = Seasons[thisSeason];
                player.transform.position = currentSeason.transform.GetChild(0).position;
            }
        }
    }
}