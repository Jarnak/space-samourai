package com.spacesamourai;

//import android.app.Activity;
import android.annotation.TargetApi;
import android.content.Context;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
//import android.os.AsyncTask;
//import android.os.Bundle;
//import android.widget.TextView;
import android.os.Build;


@TargetApi(Build.VERSION_CODES.GINGERBREAD)
public class SensorActivity implements SensorEventListener {

	// private final float NOISE = (float) 0.0;
	// private float mLastX, mLastY, mLastZ;
	private boolean mInit;
	private SensorManager mSensorManager;
	private Sensor mAccelerometer;
	// private Sensor mGyro;
	// private boolean wait = true;
	public DATA d;
	private Context c;
	public boolean sensorOn = false;
	public float offsetX, offsetY, offsetZ, offsetW;
	//private SendTask mst;

	public SensorActivity(Context cont) {
		c = cont;
		// mst=st;
	}

	public void start() {
		d = new DATA();
		mInit = false;
		mSensorManager = (SensorManager) c
				.getSystemService(Context.SENSOR_SERVICE);
		// mGyro = mSensorManager.getDefaultSensor(Sensor.TYPE_GYROSCOPE);
		mAccelerometer = mSensorManager
				.getDefaultSensor(Sensor.TYPE_ROTATION_VECTOR);
		mSensorManager.registerListener(this, mAccelerometer,
				SensorManager.SENSOR_DELAY_GAME);
		sensorOn = true;
		d.setAll(0, 0, 0, 0);
		System.out.println("Sensor Activity started");

		// démarage du manager et du listener
	}

	public void register() {
		mSensorManager.registerListener(this, mAccelerometer,
				SensorManager.SENSOR_DELAY_GAME);
		sensorOn = true;
	}

	public void unregister() {
		mSensorManager.unregisterListener(this);
		sensorOn = false;
	}

	@Override
	public void onSensorChanged(SensorEvent event) {

		// System.out.println("Sensor changed");
		// TextView tvX= (TextView)findViewById(R.id.tv1);
		// TextView tvY= (TextView)findViewById(R.id.tv2);
		// TextView tvZ= (TextView)findViewById(R.id.tv3);
		if (event.sensor.getType() == Sensor.TYPE_ROTATION_VECTOR) {
			// if (isSending()==false) {

			float[] Q = new float[4];
			SensorManager.getQuaternionFromVector(Q, event.values);

			float w = Q[3];
			float x = Q[0];
			float y = Q[1];
			float z = Q[2];
			// on affecte à xyz les val de l'accelero

			if (!mInit) {

				offsetX = x;
				offsetY = y;
				offsetZ = z;
				offsetW = w;
				mInit = true;

				// si non init => initialisation

				// mLastX = x;
				// mLastY = y;
				// mLastZ = z;

				// tvX.setText("0.0");
				// tvY.setText("0.0");
				// tvZ.setText("0.0");
				// mInit = true;
				// System.out.println("Sensor initilized");

			}
			float x2 = (x - offsetX);
			float y2 = (y - offsetY);
			float z2 = (z - offsetZ);
			float w2 = 1 + (w - offsetW);
			d.setAll(w2, x2, y2, z2);
			// float deltaX = Math.signum(x)*Math.abs(mLastX - x);
			// float deltaY = Math.signum(y)*Math.abs(mLastY - y);
			// float deltaZ = Math.signum(z)*Math.abs(mLastZ - z);
			// calcul de la variation du sensor
			// if (Math.abs(deltaX)< NOISE) deltaX = (float)0.0;
			// if (Math.abs(deltaY) < NOISE) deltaY = (float)0.0;
			// if (Math.abs(deltaZ) < NOISE) deltaZ = (float)0.0;
			// variation annulée si trop faible
			// mLastX = x;
			// mLastY = y;
			// mLastZ = z;

			// System.out.println("Sensor data saved");
			// tvX.setText("X: "+Float.toString(deltaX));
			// tvY.setText("Y: "+Float.toString(deltaY));
			// tvZ.setText("Z: "+Float.toString(deltaZ));

			// impression des variations d'accélération

		}
		// }
	}

	@Override
	public void onAccuracyChanged(Sensor sensor, int accuracy) {

	}

	public void close() {
		mSensorManager.unregisterListener(this);
	}

}
