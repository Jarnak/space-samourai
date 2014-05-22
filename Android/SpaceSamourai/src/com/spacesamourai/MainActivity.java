package com.spacesamourai;

import android.os.Bundle;
import android.os.Vibrator;
//import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.WindowManager;
import android.widget.Toast;
import android.app.Activity;
//import android.app.AlertDialog;
//import android.app.Dialog;
//import android.content.DialogInterface;

public class MainActivity extends Activity {

	private static final int SERVERPORT = 3000;
	private static final String SERVER_IP = "192.168.1.137";
	// private SendTask st;
	// private SensorActivity sa;
	public static boolean clientactif = false;
	public static int cport = 0;
	public static String cip;
	public Vibrator v;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
		// sa = new SensorActivity(getApplicationContext());
		// sa = new SensorActivity(getApplicationContext(),st);
		// sa.execute();
		v = (Vibrator) this.getSystemService(VIBRATOR_SERVICE);
		SendTask.isStart=false;
	}

	protected void onResume() {
		super.onResume();

	}

	protected void onPause() {
		super.onPause();
		if (clientactif) {

			clientactif = false;
		}

	}

	protected void onStop() {
		super.onStop();
		if (clientactif) {
			// sa.unregister();
			// sa.close();
			clientactif = false;
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle item selection
		switch (item.getItemId()) {
		case R.id.connect:
			if (clientactif) {
				CharSequence text = "Déjà connecté!";
				
				Toast toast = Toast.makeText(getApplicationContext(), text,
						Toast.LENGTH_SHORT);
				toast.show();
				v.vibrate(500);

			} else {
				CharSequence text = "Connexion...";
				Toast toast = Toast.makeText(getApplicationContext(), text,
						Toast.LENGTH_SHORT);
				toast.show();
				if ((cip != null) && (cport != 0)) {
					new SendTask(cip, cport, getApplicationContext()).execute();
					clientactif = true;
				} else {
					new SendTask(SERVER_IP, SERVERPORT, getApplicationContext())
							.execute();
					clientactif = true;
				}
			}
			return true;
		case R.id.configure:
			CustomDialogClass cdd = new CustomDialogClass(MainActivity.this);
			cdd.show();
			return true;
		case R.id.exit: 
			this.finish();
			return true;
		case R.id.start:
			if(clientactif) {
			SendTask.isStart=true;
			System.out.println(SendTask.isStart.toString());
			Shield s = new Shield(MainActivity.this);
			System.out.println("test");
			s.show();
			System.out.println("test 2");
			return true;
			} else {
				CharSequence text = "vous n'êtes pas connecté";
				Toast toast = Toast.makeText(getApplicationContext(), text,
						Toast.LENGTH_SHORT);
				toast.show();
			}
		default:
			return super.onOptionsItemSelected(item);
		}
	}

}