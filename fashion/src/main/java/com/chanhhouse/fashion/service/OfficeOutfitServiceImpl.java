package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.OfficeOutfitDao;
import com.chanhhouse.fashion.model.OfficeOutfit;

@Service
public class OfficeOutfitServiceImpl implements OfficeOutfitService {

	@Autowired
	OfficeOutfitDao officeOutfitDao;

	@Override
	@Transactional
	public void saveOfficeOutfit(OfficeOutfit officeOutfit) {
		officeOutfitDao.saveOfficeOutfit(officeOutfit);
	}

	@Override
	@Transactional
	public void deleteOfficeOutfit(String code) {
		officeOutfitDao.deleteOfficeOutfit(code);
	}

	@Override
	@Transactional
	public OfficeOutfit getOfficeOutfit(String code) {
		return officeOutfitDao.getOfficeOutfit(code);
	}

	@Override
	@Transactional
	public List<OfficeOutfit> getOfficeOutfits() {
		return officeOutfitDao.getOfficeOutfits();
	}

	@Override
	@Transactional
	public void updateOfficeOutfit(OfficeOutfit officeOutfit) {
		officeOutfitDao.updateOfficeOutfit(officeOutfit);
	}

	@Override
	@Transactional
	public void saveOrUpdate(OfficeOutfit officeOutfit) {
		if (null == getOfficeOutfit(officeOutfit.getCode())) {
			saveOfficeOutfit(officeOutfit);
		} else {
			updateOfficeOutfit(officeOutfit);
		}
	}

}