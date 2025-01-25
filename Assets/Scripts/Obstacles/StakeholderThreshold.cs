using UnityEngine;

public class StakeholderThreshold : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Pointer _pointer;
    [SerializeField] public float _speed = 2.0f;
    [SerializeField] GameStateManager gsm;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_pointer.transform.position.x, transform.position.y + System.Math.Abs(_pointer._direction.y) / 2 * Time.deltaTime, transform.position.z); 
        if (_pointer.transform.position.y - _pointer.transform.localScale.x/2 <= transform.position.y )
        {
            gsm.ActivateGameOver();
            Destroy(gameObject);
        }
    }
}
