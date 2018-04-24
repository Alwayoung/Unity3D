using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, IActionManager, ISSActionCallback {

	private DiskFactory diskFactory;

	// Use this for initialization
	void Awake () {
		this.sceneController = Singleton<FirstController>.Instance;
		diskFactory = Singleton<DiskFactory>.Instance;
	}

	// Update is called once per frame
	protected new void Update () {
		base.Update ();
	}

	public CCMoveToAction ApplyMoveToAction(GameObject object, float speeds) {
		CCMoveToAction tmpAct = CCMoveToAction.GetSSAction (speeds);
		base.RunAction (object, tmpAct, this);
		return tmpAct;
	}

	#region implementation of IActionManager
	public void playDisk() {
		GameObject diskObje = diskFactory.GetDiskObject (diskFactory.GetDisk (sceneController.round));
		this.ApplyMoveToAction (diskObje, sceneController.getSpeedByRound());
	}

	public void clearActions() {
		base.ClearAction ();
	}
	#endregion

	#region implementation of ISSActionCallback
	public void SSActionEvent (SSAction sourc, SSActionEventType events = SSActionEventType.Compeleted,
		int intParam = 0,
		string strParam = null,
		Object objectParam = null) {

		sourc.enable = false;
		sourc.destory = true;
		sourc.gameObject.transform.position = sourc.originPosition;
	}
	#endregion
}
