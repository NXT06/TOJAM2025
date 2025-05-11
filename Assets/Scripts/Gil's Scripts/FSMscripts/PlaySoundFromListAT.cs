using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.Timeline;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions {

	public class PlaySoundFromListAT : ActionTask {

		public List<AudioClip> audioClips = new List<AudioClip>();
		public BBParameter<AudioSource> audio;
		private int chosenClip;

		protected override void OnExecute() {
			chosenClip = Random.Range(0, audioClips.Count);
			audio.value.clip = audioClips[chosenClip];
            audio.value.Play();
			EndAction(true);
		}

	}
}