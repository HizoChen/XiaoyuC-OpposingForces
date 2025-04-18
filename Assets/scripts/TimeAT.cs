using UnityEngine;
using NodeCanvas.Framework;
using System.Collections;

public class TimeSystem : ActionTask
{
    public BBParameter<float> timePeriod;
    public BBParameter<float> hungryValue;
    public BBParameter<float> thirstyValue;
    public BBParameter<bool> isNight;
    public BBParameter<bool> Hungry;
    public BBParameter<bool> Thirsty;

    private const float dayLength = 60f;
    private const float nightStart = 40f;

    protected override void OnExecute()
    {
      
        hungryValue.value = Random.Range(1, 101);
        thirstyValue.value = Random.Range(1, 101);


        StartCoroutine(TimeLoop());
    }


    private IEnumerator TimeLoop()
    {
        while (true)
        {
            timePeriod.value += 1;
            if (timePeriod.value >= dayLength)
            {
                timePeriod.value = 0;
            }

            if (timePeriod.value < nightStart)
            {
                if (isNight.value)
                {
                    Debug.Log("It's daytime");
                    isNight.value = false;
                }
            }
            else
            {
                if (!isNight.value)
                {
                    Debug.Log("It's nighttime");
                    isNight.value = true;
                }
            }

            hungryValue.value += Random.Range(1, 4);
            thirstyValue.value += Random.Range(1, 4);

            if (hungryValue.value >= 100)
            {
                Hungry.value = true;
            }
            if (thirstyValue.value >= 100)
            {
                Thirsty.value = true;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
