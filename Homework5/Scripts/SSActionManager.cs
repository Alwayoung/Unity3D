using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SSActionManager : MonoBehaviour
{
	private Dictionary <int, SSAction> actions = new Dictionary<int, SSAction> ();
	private List<SSAction> waitingAdd = new List<SSAction> ();
	private List<int> waitingDelete = new List<int> ();

	protected FirstController sceneController;

	void Awake() {
		sceneController = Singleton<FirstController>.Instance;
	}

	protected void Update ()
	{
		if (sceneController.currentMoveMode == FirstController.MoveMode.CCMove) {
			if (sceneController.isPaused == false && sceneController.isStarted == true) {
				foreach (SSAction acc in waitingAdd)
					actions [acc.GetInstanceID ()] = acc;
				waitingAdd.Clear ();

				foreach (KeyValuePair <int, SSAction> kv in actions) {
					SSAction acc = kv.Value;
					if (acc.destory) {
						waitingDelete.Add (acc.GetInstanceID ());
					} else if (acc.enable) {
						acc.Update ();
					}
				}

				foreach (int key_ in waitingDelete) {
					SSAction acc = actions [key_];
					actions.Remove (key_);
					DestroyObject (acc);
					sceneController.diskComp++;
				}
				waitingDelete.Clear ();
			}
		}
	}

	protected void FixedUpdate() {
		if (sceneController.currentMoveMode == FirstController.MoveMode.PhysicsMove) {
			if (sceneController.isPaused == false && sceneController.isStarted == true) {
				foreach (SSAction acc in waitingAdd)
					actions [acc.GetInstanceID ()] = acc;
				waitingAdd.Clear ();

				foreach (KeyValuePair <int, SSAction> kv in actions) {
					SSAction acc = kv.Value;
					if (acc.destory) {
						waitingDelete.Add (acc.GetInstanceID ());
					} else if (acc.enable) {
						acc.FixedUpdate ();
					}
				}

				foreach (int key_ in waitingDelete) {
					SSAction acc = actions [key_];
					actions.Remove (key_);
					DestroyObject (acc);
					sceneController.diskComp++;
				}
				waitingDelete.Clear ();
			}
		}
	}

	public void ClearAction() {
		foreach (int key_ in waitingDelete) {
			SSAction acc = actions [key_];
			actions.Remove (key_);
			DestroyObject (acc);
		}
		waitingAdd.Clear ();
		waitingDelete.Clear ();
		actions.Clear ();
	}

	public void RunAction (GameObject gameObject, SSAction action, ISSActionCallback manager)
	{
		action.gameObject = gameObject;
		action.callback = manager;
		gameObject.GetComponent<DiskData> ().currentSSAction = action;
		waitingAdd.Add (action);
		action.Start ();
	}

}
