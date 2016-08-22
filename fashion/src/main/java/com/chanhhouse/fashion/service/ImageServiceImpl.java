package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.ImageDao;
import com.chanhhouse.fashion.model.Image;

@Service
public class ImageServiceImpl implements ImageService {

	@Autowired
	ImageDao imageDao;

	@Override
	@Transactional
	public void saveImage(Image image) {
		imageDao.saveImage(image);
	}

	@Override
	@Transactional
	public void deleteImage(int id) {
		imageDao.deleteImage(id);
	}

	@Override
	@Transactional
	public Image getImage(int id) {
		return imageDao.getImage(id);
	}

	@Override
	@Transactional
	public List<Image> getImages() {
		return imageDao.getImages();
	}

	@Override
	@Transactional
	public void updateImage(Image image) {
		imageDao.updateImage(image);
	}

	@Override
	@Transactional
	public void saveOrUpdate(Image image) {
		if (null == getImage(image.getId())) {
			saveImage(image);
		} else {
			updateImage(image);
		}
	}

}