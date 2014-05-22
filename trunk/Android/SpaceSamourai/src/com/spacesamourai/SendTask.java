package com.spacesamourai;

import java.io.*;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;





//import android.app.Activity;
import android.util.Xml;
import android.content.Context;
import android.os.AsyncTask;
//import android.os.Bundle;





import org.xmlpull.v1.XmlSerializer;

public class SendTask extends AsyncTask<Void, Void, Boolean> {

	private Socket socket;
	private int port;
	private String address;
	private SensorActivity msa;
	private Context mc;
	// private DATA oldD = new DATA();
	public boolean hc;
	public boolean boucleActive = true;
	public boolean sent = false;
	private boolean sending = false;
	public static Boolean isStart = false;
	public static Boolean shield=false;
	private InetAddress serverAddr;
	private PrintWriter mPW;

	// private boolean wait = true;

	public SendTask(String s, int p, Context c) {
		port = p;
		address = s;
		mc = c;
	}

	protected Boolean doInBackground(Void... voids) {
		// while (wait) {};
		// sendMessageXML(mdata);

		System.out.println("new thread!");
		new Thread(new ClientStart()).run();
		msa.start();
		try {
			socket = new Socket(serverAddr, port);
			socket.setTcpNoDelay(true);
			mPW = new PrintWriter(socket.getOutputStream());
		} catch (IOException e2) {
			// TODO Auto-generated catch block
			e2.printStackTrace();
		}
		
		new Listener(this);
		while (MainActivity.clientactif == true) {
			try {
				if (sending == false) {
					sendMessageXML(msa.d, mPW);
				}
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}

			// System.out.println("boucle while...");
			try {
				Thread.sleep(25);

			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

		return true;

	}

	/*
	 * @Override protected void onPostExecute(Boolean result) {
	 * super.onPostExecute(result); try { socket.close(); } catch (IOException
	 * e) { e.printStackTrace(); }
	 * 
	 * }
	 */

	class ClientStart implements Runnable {

		public void run() {

			try {
				serverAddr = InetAddress.getByName(address);
				
			} catch (UnknownHostException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			// System.out.println("Socket created");
			msa = new SensorActivity(mc);

			// System.out.println("New Sensor Activity");
			// oldD.setAll(0, 0, 0,0);
		}
	}

	/*
	 * public void sendMessage(String s) {
	 * 
	 * try { PrintWriter out = new PrintWriter(new BufferedWriter( new
	 * OutputStreamWriter(socket.getOutputStream())), true); out.println(s);
	 * 
	 * } catch (UnknownHostException e) { e.printStackTrace(); } catch
	 * (IOException e) { e.printStackTrace(); } catch (Exception e) {
	 * e.printStackTrace(); }
	 * 
	 * }
	 */

	public void sendMessageXML(DATA d, PrintWriter mPW) throws IOException {
		System.out.println("début de la procédure d'envoi");
		sending = true;
		//PrintWriter mPW = new PrintWriter(socket.getOutputStream());
		// BufferedWriter bw = new BufferedWriter(osw);
		// PrintWriter out = new PrintWriter(bw,true);
		// sent=false;
		XmlSerializer xs = Xml.newSerializer();
		StringWriter st = new StringWriter();
		try {

			System.out.println("début d'écriture du XML");
			xs.setOutput(st);
			xs.startDocument(null, null);
			xs.startTag(null, "DATA");
			xs.startTag(null, "x");
			xs.text(d.toStringX());
			xs.endTag(null, "x");
			xs.startTag(null, "y");
			xs.text(d.toStringY());
			xs.endTag(null, "y");
			xs.startTag(null, "z");
			xs.text(d.toStringZ());
			xs.endTag(null, "z");
			xs.startTag(null, "w");
			xs.text(d.toStringW());
			xs.endTag(null, "w");
			xs.startTag(null, "go");
			xs.text(isStart.toString());
			xs.endTag(null, "go");
			xs.startTag(null, "shield");
			xs.text(shield.toString());
			xs.endTag(null, "shield");
			xs.endTag(null, "DATA");
			xs.endDocument();
		
			// PrintWriter out = new PrintWriter(new BufferedWriter(
			// new OutputStreamWriter(socket.getOutputStream())),
			// true);
			mPW.write(st.toString());
			mPW.flush();
			xs.flush();
			st.flush();
			
		} catch (IllegalArgumentException e1) {
			//
			e1.printStackTrace();
		} catch (IllegalStateException e1) {
			//
			e1.printStackTrace();
		} catch (IOException e1) {
			//
			e1.printStackTrace();
		}

		// out.close();
		sending = false;

	}

	public boolean isSending() {
		return sending;
	}

	public Socket getSocket() {
		return socket;
	}
}