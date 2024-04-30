using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SheepSpawner : MonoBehaviour
{

    public GameObject sheepPrefab;
    public float lambda_parameter = 6f; 
    private float time_for_next_spawn; 
    void Start()
    {
        time_for_next_spawn = Random.value * 2 + 3;

        /*

        //Check that the poisson distrivution is calculated properly

        int[] values = new int[30]; 
        for (int i = 0; i < 10000000; i++)
        {
            values[(int)Mathf.Clamp(get_next_time(), 0, values.Length - 1)] += 1; 
        }
        int total = 0;
        for (int i = 0; i < values.Length; i++)
        {
            total += values[i];
        }
        for (int i = 0; i < values.Length; i++)
        {
            print(string.Format("{0}: {1}\n", i, (float)values[i] / total));
        }*/

    }


    void Update()
    {
        
        time_for_next_spawn += -Time.deltaTime; 
        if(time_for_next_spawn < 0 )
        {
            time_for_next_spawn = get_next_time();
            Instantiate( sheepPrefab, transform.position, sheepPrefab.transform.rotation);
        }
    }

    float get_next_time()
    {
        //using poisson fistribution
        float lambda = lambda_parameter; 
        //use "inverse" method
        float rnd = Random.value;
        float cumulative_sum = 0f;
        float exp_lambda = Mathf.Exp(-lambda); 

        int k = 0; 
        while(cumulative_sum < rnd)
        {
            float probability = Mathf.Pow(lambda, k) * exp_lambda / factorial(k);
            cumulative_sum += probability;
            k++;
        }

        k--; 

        return (float)k; 
    }

    int factorial(int x)
    {
        if(x < 2) return 1;

        int ret = 1; 
        for (int i = 2; i <= x; i++) {
            ret *= i;
            if (ret < 0) return int.MaxValue; //handle overflow
        }
        return ret; 
    }

}
