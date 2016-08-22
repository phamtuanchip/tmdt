package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.Sleepwear;

public interface SleepwearService {

	public void saveSleepwear(Sleepwear sleepwear);

	public void updateSleepwear(Sleepwear sleepwear);

	public Sleepwear getSleepwear(String code);

	public void deleteSleepwear(String code);

	public List<Sleepwear> getSleepwears();

	public void saveOrUpdate(Sleepwear sleepwear);
}
