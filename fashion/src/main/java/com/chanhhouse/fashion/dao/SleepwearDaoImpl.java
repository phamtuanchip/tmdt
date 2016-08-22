package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.Sleepwear;

@Repository
public class SleepwearDaoImpl implements SleepwearDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveSleepwear(Sleepwear sleepwear) {
		getCurrentSession().save(sleepwear);
	}

	@Override
	public void updateSleepwear(Sleepwear sleepwear) {
		Sleepwear sleepwearToUpdate = getSleepwear(sleepwear.getCode());
		sleepwearToUpdate.setCategory(sleepwear.getCategory());
		getCurrentSession().update(sleepwearToUpdate);
	}

	@SuppressWarnings("rawtypes")
	@Override
	public Sleepwear getSleepwear(String code) {
		Criteria cr = getCurrentSession().createCriteria(Sleepwear.class);
		cr.add(Restrictions.eq("code", code));
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (Sleepwear) results.get(0);
	}

	@Override
	public void deleteSleepwear(String code) {
		Sleepwear sleepwear = getSleepwear(code);
		if (sleepwear != null)
			getCurrentSession().delete(sleepwear);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Sleepwear> getSleepwears() {
		return getCurrentSession().createCriteria(Sleepwear.class).list();
	}
}
