using UnityEngine;

public class Interface : MonoBehaviour
{
    public interface IVendingState
    {
        public void InsertCoin();
        void Cancel();
        void Order();
        void Maintenance();
    }
}
