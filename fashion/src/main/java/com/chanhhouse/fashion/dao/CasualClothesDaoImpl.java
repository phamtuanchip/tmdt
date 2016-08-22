package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.CasualClothes;

@Repository
public class CasualClothesDaoImpl implements CasualClothesDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveCasualClothes(CasualClothes casualClothes) {
		getCurrentSession().save(casualClothes);
	}

	@Override
	public void updateCasualClothes(CasualClothes casualClothes) {
		CasualClothes casualClothesToUpdate = getCasualClothes(casualClothes.getCode());
		casualClothesToUpdate.setCategory(casualClothes.getCategory());
		casualClothesToUpdate.setForm(casualClothes.getForm());
		getCurrentSession().update(casualClothesToUpdate);
	}

	@SuppressWarnings("rawtypes")
	@Override
	public CasualClothes getCasualClothes(String code) {
		Criteria cr = getCurrentSession().createCriteria(CasualClothes.class);
		cr.add(Restrictions.eq("code", code));
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (CasualClothes) results.get(0);
	}

	@Override
	public void deleteCasualClothes(String code) {
		CasualClothes casualClothes = getCasualClothes(code);
		if (casualClothes != null)
			getCurrentSession().delete(casualClothes);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CasualClothes> getCasualClothess() {
		return getCurrentSession().createCriteria(CasualClothes.class).list();
	}
}
