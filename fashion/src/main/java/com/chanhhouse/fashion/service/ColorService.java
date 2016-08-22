package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.Color;

public interface ColorService {

	public void saveColor(Color color);

	public void updateColor(Color color);

	public Color getColor(int id);

	public void deleteColor(int id);
	
	public List<Color> getColors();

	public void saveOrUpdate(Color color);
}
