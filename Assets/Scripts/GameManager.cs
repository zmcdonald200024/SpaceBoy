using UnityEngine;
using System.Collections;
using UnityEngine.UI; // include UI namespace so can reference UI elements
using UnityEngine.SceneManagement; // include so we can manipulate SceneManager

public class GameManager : MonoBehaviour {

	// static reference to game manager so can be called from other scripts directly (not just through gameobject component)
	public static GameManager gm;

	// levels to move to on victory and lose
	public string levelAfterVictory;
	public string levelAfterGameOver;
	public GameObject counter;

	// game performance


	public int livesCount = 6;

	// UI elements to control
	public Text lives;



	// private variables
	GameObject _player;
	Vector3 _spawnLocation;
	Scene _scene;

	// set things up here
	void Awake () {


		lives = counter.GetComponent<Text>();

		// setup reference to game manager
		if (gm == null)
			gm = this.GetComponent<GameManager>();

		// setup all the variables, the UI, and provide errors if things not setup properly.
		setupDefaults();
	}

	// game loop
	void Update() {
		// if ESC pressed then pause the game
	
	}

	// setup all the variables, the UI, and provide errors if things not setup properly.
	void setupDefaults() {
		// setup reference to player
		if (_player == null)
			_player = GameObject.FindGameObjectWithTag("Player");
		
		if (_player==null)
			Debug.LogError("Player not found in Game Manager");

		// get current scene
		_scene = SceneManager.GetActiveScene();

		// get initial _spawnLocation based on initial position of player
		_spawnLocation = _player.transform.position;

		// if levels not specified, default to current level
		if (levelAfterVictory=="") {
			Debug.LogWarning("levelAfterVictory not specified, defaulted to current level");
			levelAfterVictory = _scene.name;
		}
		
		if (levelAfterGameOver=="") {
			Debug.LogWarning("levelAfterGameOver not specified, defaulted to current level");
			levelAfterGameOver = _scene.name;
		}

		// friendly error messages
	
		
		
		
		// get stored player prefs
	

		// get the UI ready for the game
		refreshGUI();
	}

	// get stored Player Prefs if they exist, otherwise go with defaults set on gameObject
	

	// refresh all the GUI elements
	void refreshGUI() {
		// set the text elements of the UI
		lives.text = "Lives: "+livesCount.ToString();
		
		
		// turn on the appropriate number of life indicators in the UI based on the number of lives left
	
		}
	

	// public function to add points and update the gui and highscore player prefs accordingly
	
	

	// public function to subtract points and update the gui and highscore player prefs accordingly


	// public function to remove player life and reset game accordingly


	// public function for level complete
	public void LevelCompete() {
		// save the current player prefs before moving to the next level
		

		// use a coroutine to allow the player to get fanfare before moving to next level
		StartCoroutine(LoadNextLevel());
	}

	// load the nextLevel after delay
	IEnumerator LoadNextLevel() {
		yield return new WaitForSeconds(3.5f);
		SceneManager.LoadScene(levelAfterVictory);
	}
}
