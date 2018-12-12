using UnityEngine;
using UnityEngine.UI;

public class UIGameModesController : MonoBehaviour {

	public Text gamemodeTitle;
	public Text description;

	public void SwitchMode(int index) {
		switch(index) {
			case 1:
				gamemodeTitle.text = "Freestyle";
				description.text = "Find as much ice creams as you can. Just keep an eye for fuel tanks and you'll be ok.";
				break;
			case 2:
				gamemodeTitle.text = "Cursed";
				description.text = "You have unlimited fuel, but one ice cream cone is cursed.\nWhen you pick it... you'll see (-:";
				break;
			case 3:
				gamemodeTitle.text = "Three Minutes";
				description.text = "Find as much ice creams as you can in three minutes time limit.\nFuel consumption is slower.";
				break;
			case 4:
				gamemodeTitle.text = "Six Minutes";
				description.text = "Find as much ice creams as you can in six minutes time limit.\nFuel consumption is normal.";
				break;
			case 5:
				gamemodeTitle.text = "Twelve Minutes";
				description.text = "Find as much ice creams as you can in twelve minutes time limit.\nFuel consumption is faster.";
				break;
		}
	}

}
