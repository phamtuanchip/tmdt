package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.ColorDao;
import com.chanhhouse.fashion.model.Color;

@Service
public class ColorServiceImpl implements ColorService {

	@Autowired
	ColorDao colorDao;

	@Override
	@Transactional
	public void saveColor(Color color) {
		colorDao.saveColor(color);
	}

	@Override
	@Transactional
	public void deleteColor(int id) {
		colorDao.deleteColor(id);
	}

	@Override
	@Transactional
	public Color getColor(int id) {
		return colorDao.getColor(id);
	}

	@Override
	@Transactional
	public List<Color> getColors() {
		return colorDao.getColors();
	}

	@Override
	@Transactional
	public void updateColor(Color color) {
		colorDao.updateColor(color);
	}

	@Override
	@Transactional
	public void saveOrUpdate(Color color) {
		if (null == getColor(color.getId())) {
			saveColor(color);
		} else {
			updateColor(color);
		}
	}
}