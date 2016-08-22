package com.chanhhouse.fashion.dao;

import java.util.List;

import com.chanhhouse.fashion.model.Sleepwear;

public interface SleepwearDao {
  
    public void saveSleepwear(Sleepwear sleepwear);

    public void updateSleepwear(Sleepwear sleepwear);

    public Sleepwear getSleepwear(String code);

    public void deleteSleepwear(String code);

    public List<Sleepwear> getSleepwears();
}
