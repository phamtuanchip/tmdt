package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.SizeDao;
import com.chanhhouse.fashion.model.Size;

@Service
public class SizeServiceImpl implements SizeService {

	@Autowired
	SizeDao sizeDao;

	@Override
	@Transactional
	public void saveSize(Size size) {
		sizeDao.saveSize(size);
	}

	@Override
	@Transactional
	public void deleteSize(int id) {
		sizeDao.deleteSize(id);
	}

	@Override
	@Transactional
	public Size getSize(int id) {
		return sizeDao.getSize(id);
	}

	@Override
	@Transactional
	public List<Size> getSizes() {
		return sizeDao.getSizes();
	}

	@Override
	@Transactional
	public void updateSize(Size size) {
		sizeDao.updateSize(size);
	}

	@Override
	@Transactional
	public void saveOrUpdate(Size size) {
		if (null == getSize(size.getId())) {
			saveSize(size);
		} else {
			updateSize(size);
		}
	}

}