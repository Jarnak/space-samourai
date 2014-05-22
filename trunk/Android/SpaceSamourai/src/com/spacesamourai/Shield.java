package com.spacesamourai;

import android.app.Activity;
import android.app.Dialog;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;

public class Shield extends Dialog implements android.view.View.OnClickListener {
	
	private Button a;
	public Activity c;

	public Shield(Activity a){
		super(a);
		this.c=a;
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.shield);
		a = (Button) findViewById(R.id.bshield);
		a.setOnClickListener(this);
	}
	
	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		if(v.getId()==R.id.bshield)
		{
			System.out.println("prout");
			SendTask.shield=true;
			System.out.println(SendTask.shield.toString());
			try {
				Thread.sleep(500);
				System.out.println(SendTask.shield.toString());
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			SendTask.shield=false;
			System.out.println(SendTask.shield.toString());
		}
	}
}
