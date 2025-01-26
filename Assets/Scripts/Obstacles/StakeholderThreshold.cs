using UnityEngine;

public class StakeholderThreshold : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Pointer _pointer;
    [SerializeField] public float _increasingSpeed = 2.0f;
    [SerializeField] GameStateManager gsm;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
                    _pointer.transform.position.x, 
                    transform.position.y 
                        + (System.Math.Abs(_pointer._direction.y) // / 3.5f // base speed base on pointer upward speed
                        + (_pointer.transform.position.y - transform.position.y) / 5f // additional speed based on distance between pointer and stakeholder
                        + _increasingSpeed ) // increasing speed in time
                        * Time.deltaTime,                 
                    transform.position.z
                ); 
        if (_pointer.transform.position.y - _pointer.transform.localScale.x/2 <= transform.position.y )
        {
            gsm.ActivateGameOver();
            Destroy(gameObject);
        }
        else if (_pointer.transform.position.y >= transform.position.y + 50)
        {
            transform.position += new Vector3(0, 15, 0);
        }
        _increasingSpeed += 0.05f * Time.deltaTime;

        if (InvestorTrustSlider.Instance.slider.value >= InvestorTrustSlider.Instance.slider.maxValue)
        {
            Destroy(gameObject);
        }
    }
}
