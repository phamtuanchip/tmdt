package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.UnderwearDao;
import com.chanhhouse.fashion.model.Underwear;

@Service
public class UnderwearServiceImpl implements UnderwearService {

	@Autowired
	UnderwearDao underwearDao;

	@Override
	@Transactional
	public void saveUnderwear(Underwear underwear) {
		underwearDao.saveUnderwear(underwear);
	}

	@Override
	@Transactional
	public void deleteUnderwear(String code) {
		underwearDao.deleteUnderwear(code);
	}

	@Override
	@Transactional
	public Underwear getUnderwear(String code) {
		return underwearDao.getUnderwear(code);
	}

	@Override
	@Transactional
	public List<Underwear> getUnderwears() {
		return underwearDao.getUnderwears();
	}

	@Override
	@Transactional
	public void updateUnderwear(Underwear underwear) {
		underwearDao.updateUnderwear(underwear);
	}

	@Override
	@Transactional
	public void saveOrUpdate(Underwear underwear) {
		if (null == getUnderwear(underwear.getCode())) {
			saveUnderwear(underwear);
		} else {
			updateUnderwear(underwear);
		}
	}

}