package com.spacesamourai;

import android.app.Activity;
import android.app.Dialog;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;

public class CustomDialogClass extends Dialog implements
		android.view.View.OnClickListener {

	public Activity c;
	public Dialog d;
	public Button set, cancel;
	public EditText adip, port;

	public CustomDialogClass(Activity a) {
		super(a);
		// TODO Auto-generated constructor stub
		this.c = a;
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.ipaddresslayout);
		set = (Button) findViewById(R.id.bset);
		cancel = (Button) findViewById(R.id.bcancel);
		adip = (EditText) findViewById(R.id.ipaddress);
		port = (EditText) findViewById(R.id.port);
		set.setOnClickListener(this);
		cancel.setOnClickListener(this);

	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.bset:
			MainActivity.cip = adip.getText().toString();
			String tport;
			tport = port.getText().toString();
			MainActivity.cport = Integer.parseInt(tport);
			dismiss();
			break;
		case R.id.bcancel:
			dismiss();
			break;
		default:
			break;
		}
		dismiss();
	}
}