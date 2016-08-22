package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.Size;

public interface SizeService {

	public void saveSize(Size size);

	public void updateSize(Size size);

	public Size getSize(int id);

	public void deleteSize(int id);

	public List<Size> getSizes();

	public void saveOrUpdate(Size size);
}
