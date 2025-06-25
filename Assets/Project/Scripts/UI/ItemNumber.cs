using UnityEngine;

namespace Project.Scripts.UI
{
    public class ItemNumber : MonoBehaviour
    {
        [SerializeField] private int id, number;
        
        public int Id { get => id; set => id = value; }
        public int Number { get => number; set => number = value; }
    }
}