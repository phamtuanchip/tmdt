package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.Image;

public interface ImageService {

	public void saveImage(Image image);

	public void updateImage(Image image);

	public Image getImage(int id);

	public void deleteImage(int id);

	public List<Image> getImages();

	public void saveOrUpdate(Image image);
}
