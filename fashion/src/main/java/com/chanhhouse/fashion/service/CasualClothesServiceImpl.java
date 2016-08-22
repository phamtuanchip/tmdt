package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.CasualClothesDao;
import com.chanhhouse.fashion.model.CasualClothes;

@Service
public class CasualClothesServiceImpl implements CasualClothesService {

	@Autowired
	CasualClothesDao casualClothesDao;

	@Override
	@Transactional
	public void saveCasualClothes(CasualClothes casualClothes) {
		casualClothesDao.saveCasualClothes(casualClothes);
	}

	@Override
	@Transactional
	public void deleteCasualClothes(String code) {
		casualClothesDao.deleteCasualClothes(code);
	}

	@Override
	@Transactional
	public CasualClothes getCasualClothes(String code) {
		return casualClothesDao.getCasualClothes(code);
	}

	@Override
	@Transactional
	public List<CasualClothes> getCasualClothess() {
		return casualClothesDao.getCasualClothess();
	}

	@Override
	@Transactional
	public void updateCasualClothes(CasualClothes casualClothes) {
		casualClothesDao.updateCasualClothes(casualClothes);
	}

	@Override
	@Transactional
	public void saveOrUpdate(CasualClothes casualClothes) {
		if (null == getCasualClothes(casualClothes.getCode())) {
			saveCasualClothes(casualClothes);
		} else {
			updateCasualClothes(casualClothes);
		}
	}

}