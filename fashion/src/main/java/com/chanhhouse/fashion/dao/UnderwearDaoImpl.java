package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.Underwear;

@Repository
public class UnderwearDaoImpl implements UnderwearDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveUnderwear(Underwear underwear) {
		getCurrentSession().save(underwear);
	}

	@Override
	public void updateUnderwear(Underwear underwear) {
		Underwear underwearToUpdate = getUnderwear(underwear.getCode());
		underwearToUpdate.setCategory(underwear.getCategory());
		getCurrentSession().update(underwearToUpdate);
	}

	@SuppressWarnings("rawtypes")
	@Override
	public Underwear getUnderwear(String code) {
		Criteria cr = getCurrentSession().createCriteria(Underwear.class);
		cr.add(Restrictions.eq("code", code));
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (Underwear) results.get(0);
	}

	@Override
	public void deleteUnderwear(String code) {
		Underwear underwear = getUnderwear(code);
		if (underwear != null)
			getCurrentSession().delete(underwear);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Underwear> getUnderwears() {
		return getCurrentSession().createCriteria(Underwear.class).list();
	}
}
