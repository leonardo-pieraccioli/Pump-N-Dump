using UnityEngine;
using UnityEngine.UI;

public class InvestorTrustSlider : MonoBehaviour
{
    public static InvestorTrustSlider Instance { get; private set; }
    [SerializeField] public GameStateManager gsm;
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    public Slider slider;
    [SerializeField] private Pointer pointer;
    private float initialAngle;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        initialAngle = pointer._angle;
    }

    void Update()
    {
        slider.value -= 3.5f * Time.deltaTime;
        pointer._angle = initialAngle - slider.value * .15f;
    }

    public void UpdateValue(float gain){
        slider.value += gain;
        pointer._angle += 1;
        pointer._speed += .1f;
        if (slider.value >= 100)
        {
            gsm.ActivateWin();
        }
    }
}
