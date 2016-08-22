package com.chanhhouse.fashion.dao;

import java.util.List;

import com.chanhhouse.fashion.model.Size;

public interface SizeDao {

	public void saveSize(Size size);

	public void updateSize(Size size);

	public Size getSize(int id);

	public void deleteSize(int id);

	public List<Size> getSizes();

	public List<Size> getSizesByColorId(int idColor);
}
