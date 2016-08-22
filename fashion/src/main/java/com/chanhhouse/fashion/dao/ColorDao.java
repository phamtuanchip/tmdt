package com.chanhhouse.fashion.dao;

import java.util.List;

import com.chanhhouse.fashion.model.Color;

public interface ColorDao {

	public void saveColor(Color color);

	public void updateColor(Color color);

	public Color getColor(int id);

	public void deleteColor(int id);
	
	public List<Color> getColorsByCode(String code);

	public List<Color> getColors();
}
