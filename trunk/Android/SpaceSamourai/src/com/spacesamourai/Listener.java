package com.spacesamourai;

import java.io.IOException;
import java.io.InputStream;

import android.os.Vibrator;

public class Listener {

	private InputStream message;
	private SendTask sendTask;
	private Vibrator v;

	public Listener(SendTask st) {
		sendTask = st;
	}

	protected Boolean doInBackground(Void... voids) {

		while (MainActivity.clientactif == true) {
			System.out.println("boucle while 0_0");
			try {
				message = sendTask.getSocket().getInputStream();
				try {
					reactToMessage(message.toString());
					message.reset();
				} catch (IllegalArgumentException e1) {
					//
					e1.printStackTrace();
				}
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}

			try {
				Thread.sleep(50);

			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

		return true;

	}

	public void reactToMessage(String m) {
		switch (m) {
		case "Hit":
			v.vibrate(500);
			break;
		}
	}

		public String getMessage() {
		return message.toString();
	}
}
