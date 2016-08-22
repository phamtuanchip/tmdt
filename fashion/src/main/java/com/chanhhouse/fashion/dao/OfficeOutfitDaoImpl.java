package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.OfficeOutfit;

@Repository
public class OfficeOutfitDaoImpl implements OfficeOutfitDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveOfficeOutfit(OfficeOutfit officeOutfit) {
		getCurrentSession().save(officeOutfit);
	}

	@Override
	public void updateOfficeOutfit(OfficeOutfit officeOutfit) {
		OfficeOutfit officeOutfitToUpdate = getOfficeOutfit(officeOutfit.getCode());
		officeOutfitToUpdate.setCategory(officeOutfit.getCategory());
		getCurrentSession().update(officeOutfitToUpdate);
	}

	@SuppressWarnings("rawtypes")
	@Override
	public OfficeOutfit getOfficeOutfit(String code) {
		Criteria cr = getCurrentSession().createCriteria(OfficeOutfit.class);
		cr.add(Restrictions.eq("code", code));
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (OfficeOutfit) results.get(0);
	}

	@Override
	public void deleteOfficeOutfit(String code) {
		OfficeOutfit officeOutfit = getOfficeOutfit(code);
		if (officeOutfit != null)
			getCurrentSession().delete(officeOutfit);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<OfficeOutfit> getOfficeOutfits() {
		return getCurrentSession().createCriteria(OfficeOutfit.class).list();
	}
}
