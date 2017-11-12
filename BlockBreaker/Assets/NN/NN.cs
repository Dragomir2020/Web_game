using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NN : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void update_weights(Dictionary<string, float> weights, Dictionary<string, float> expectation_g_squared, Dictionary<string, float> g_dict, float decay_rate, float learning_rate){
		float epsilon = 0.00001f;
		foreach (string layer_name in weights.Keys) {
			float g = g_dict [layer_name];
			expectation_g_squared [layer_name] = (decay_rate * expectation_g_squared [layer_name] + (1 - decay_rate) * g) * (decay_rate * expectation_g_squared [layer_name] + (1 - decay_rate) * g);
			//weights [layer_name] += (learning_rate * g) / (np.sqrt (expectation_g_squared [layer_name] + epsilon));
			//g_dict [layer_name] = np.zeros_like (weights [layer_name]);
		}
	}
}
