using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{

    private void OnDestroy()
    {
        if (TorchItemUi.Instance == null) return;


        if (Random.value < 0.05f)
        {
            TorchItemUi.Instance.AddTorchItme(1);
        }
    }
}
