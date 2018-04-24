using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsActionManager :  SSActionManager, IActionManager, ISSActionCallback {


	private DiskFactory diskFactory;

	// Use this for initialization
	void Awake () {
		this.sceneController = Singleton<FirstController>.Instance;
		diskFactory = Singleton<DiskFactory>.Instance;
	}
		
	protected new void FixedUpdate() {
		if (sceneController.isPaused == true || sceneController.isStarted == false)
			return;
		base.FixedUpdate ();
	}

	public PhysicsMoveToAction ApplyMoveToAction(GameObject objj, float speedd) {
		PhysicsMoveToAction tmpActionn = PhysicsMoveToAction.GetSSAction (speedd);
		base.RunAction (objj, tmpActionn, this);
		return tmpAction;
	}

	#region implementation of IActionManager
	public void playDisk() {
		GameObject diskObjj = diskFactory.GetDiskObject (diskFactory.GetDisk (sceneController.round));
		this.ApplyMoveToAction (diskObjj, sceneController.getSpeedByRound());
	}
	public void clearActions() {
		base.ClearAction ();
	}
	#endregion

	#region implementation of ISSActionCallback
	public void SSActionEvent (SSAction source, SSActionEventType events = SSActionEventType.Compeleted,
		int intParam = 0,
		string strParam = null,
		Object objectParam = null) {

		source.enable = false;
		source.destory = true;
		source.gameObject.transform.position = source.originPosition;
	}
	#endregion
}
