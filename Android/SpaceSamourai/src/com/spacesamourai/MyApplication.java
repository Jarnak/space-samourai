package com.spacesamourai;

import android.app.Application;

public class MyApplication extends Application {

	public static MyApplication instance = null;

	@Override
	public void onCreate() {
		// TODO Auto-generated method stub
		super.onCreate();
	}

	public static MyApplication getInstance() {
		if (instance == null) {
			instance = new MyApplication();
		}
		return instance;
	}

}