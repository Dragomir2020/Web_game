using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNSetupTrain : MonoBehaviour {

	/*
	// Use this for initialization
	void Start () {

		//Capture Screenshot and save image
		ScreenCapture.CaptureScreenshot("Screenshot.png");
		//NEED TO GET IMAGE


		//hyperparameters
		int episode_number = 0;
		int batch_size = 10;
		float gamma = 0.99f; // discount factor for reward
		float decay_rate = 0.99f;
		int num_hidden_layer_neurons = 200;
		int input_dimensions = 80 * 80;
		float learning_rate = 0.0001f;

		int reward_sum = 0;
		string running_reward = null;
		string prev_processed_observations = null;
		Dictionary<string, List<float>> weights = new Dictionary<string, List<float>>();
		weights.Add ("1", np.random.randn (num_hidden_layer_neurons, input_dimensions) / np.sqrt (input_dimensions) new List<float>());
		weights.Add ("2", np.random.randn (num_hidden_layer_neurons) / np.sqrt (num_hidden_layer_neurons) new List<float>()); 
			
		Dictionary<string, float> expectation_g_squared = new Dictionary<string, List<float>>();
		Dictionary<string, float> g_dict = new Dictionary<string, List<float>>();

		foreach(string layer_name in weights.Keys){
			expectation_g_squared [layer_name] = ZerosList(weights [layer_name]);
			g_dict [layer_name] = ZerosList(weights [layer_name].Count);
		}

		List<float> episode_hidden_layer_values = new List<float>();
		List<float> episode_observations = new List<float>();
		List<float> episode_gradient_log_ps = new List<float>();
		List<float> episode_rewards = new List<float>();

		RunNN ();
		
	}

	//This is probabaly slow
	private List<float> ZerosList(int num)
	{
		List<float> f = new List<float> ();
		for(int i = 0; i < num; i++){
			f.Add (0f);
		}
		return f;
	}
			
	// Update is called once per frame
	void Update () {
		
	}

	private void RunNN(int input_dimensions){
		//Use Image as Observation
		List<float> observation = new List<float> ();
		List<float> prev_processed_observations = new List<float> ();
		//Declare and initialize
		Dictionary<string, float> observations = new Dictionary<float, float> ();
		observations.Add ("processed_observations", 0f);
		observations.Add ("prev_processed_observations", 0f);
		int count = 0;
		while (true){
			//Render Image
			// processed_observations, prev_processed_observations (Observations)
			observations = preprocess_observations(observation, prev_processed_observations, input_dimensions);
			count ++;
			if (count == 10) {
				break; //Break under certain conditions with algorithm
			}
		}
	}

	private Dictionary<string, float> preprocess_observations(){
		//convert the 210x160x3 uint8 frame into a 6400 float vector
		processed_observation = input_observation[35:195] # crop
			processed_observation = downsample(processed_observation)
			processed_observation = remove_color(processed_observation)
			processed_observation = remove_background(processed_observation)
			processed_observation[processed_observation != 0] = 1 # everything else (paddles, ball) just set to 1
				# Convert from 80 x 80 matrix to 1600 x 1 matrix
				processed_observation = processed_observation.astype(np.float).ravel()

				# subtract the previous frame from the current one so we are only processing on changes in the game
				if prev_processed_observation is not None:
					input_observation = processed_observation - prev_processed_observation
				else:
					input_observation = np.zeros(input_dimensions)
					# store the previous frame so we can subtract from it next time
					prev_processed_observations = processed_observation


		return new Dictionary<string, float> ();
	}*/
}
