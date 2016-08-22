package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.SleepwearDao;
import com.chanhhouse.fashion.model.Sleepwear;

@Service
public class SleepwearServiceImpl implements SleepwearService {

	@Autowired
	SleepwearDao sleepwearDao;

	@Override
	@Transactional
	public void saveSleepwear(Sleepwear sleepwear) {
		sleepwearDao.saveSleepwear(sleepwear);
	}

	@Override
	@Transactional
	public void deleteSleepwear(String code) {
		sleepwearDao.deleteSleepwear(code);
	}

	@Override
	@Transactional
	public Sleepwear getSleepwear(String code) {
		return sleepwearDao.getSleepwear(code);
	}

	@Override
	@Transactional
	public List<Sleepwear> getSleepwears() {
		return sleepwearDao.getSleepwears();
	}

	@Override
	@Transactional
	public void updateSleepwear(Sleepwear sleepwear) {
		sleepwearDao.updateSleepwear(sleepwear);
	}

	@Override
	@Transactional
	public void saveOrUpdate(Sleepwear sleepwear) {
		if (null == getSleepwear(sleepwear.getCode())) {
			saveSleepwear(sleepwear);
		} else {
			updateSleepwear(sleepwear);
		}
	}

}