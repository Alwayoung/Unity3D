using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDirector : System.Object
{
	private static SSDirector _instancea;

	public ISceneController currentSceneController { get; set; }

	public bool running { get; set; }

	public static SSDirector getInstance ()
	{
		if (_instancea == null) {
			_instancea = new SSDirector ();
		}
		return _instancea;
	}

	public int getFPS ()
	{
		return Application.targetFrameRate;
	}

	public void setFPS (int fps)
	{
		Application.targetFrameRate = fps;
	}

	public void NextScene() {
		// next scene
	}
}
