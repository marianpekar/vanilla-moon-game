using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider sfxVolume;
	public Slider musicVolume;

	private MusicManager musicManager;

	private SoundsController soundsController;
	private EngineSoundController engineSoundController;
	private TimerController timerController;

 	void Start() {
		musicManager = FindObjectOfType<MusicManager>();
 		musicVolume.value = PlayerPrefsManager.GetMusicVolume();
		soundsController = FindObjectOfType<SoundsController>();
		engineSoundController = FindObjectOfType<EngineSoundController>();
		timerController = FindObjectOfType<TimerController>();

		sfxVolume.value = PlayerPrefsManager.GetSfxVolume();
 	}

 	public void ChangeSfxVolume() {
 		PlayerPrefsManager.SetSfxVolume(sfxVolume.value);
		soundsController.ChangeSfxVolume();
		soundsController.ChangeLaughingVolume();
		engineSoundController.ChangeEngineSoundVolume();
		timerController.ChangeTickingSoundVolume();
 	}

	public void ChangeMusicVolume() {
 		PlayerPrefsManager.SetMusicVolume(musicVolume.value);
		musicManager.ChangeMusicVolume();
 	}

}
