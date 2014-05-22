package com.spacesamourai;

public class DATA {

	public Float w;
	public Float x;
	public Float y;
	public Float z;

	public String toString(Float v) {
		String s;
		s = v.toString();
		return s;
	}

	public void initZ(Float r) {

		z = r;
	}

	public void setAll(float s, float t, float u, float v) {
		w = s;
		x = t;
		y = u;
		z = v;
	}

	public void set(float t, float u, float v) {
		w = t;
		x = u;
		y = v;

	}

	public float getX() {
		return x;
	}

	public float getY() {
		return y;
	}

	public float getZ() {
		return z;
	}

	public String toStringX() {
		String s;
		s = x.toString();
		return s;
	}

	public String toStringY() {
		String s;
		s = y.toString();
		return s;
	}

	public String toStringZ() {
		String s;
		s = z.toString();
		return s;
	}

	public String toStringW() {
		String s;
		s = w.toString();
		return s;
	}

}
