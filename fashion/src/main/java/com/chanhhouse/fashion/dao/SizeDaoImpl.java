package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.Size;

@Repository
public class SizeDaoImpl implements SizeDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveSize(Size size) {
		getCurrentSession().save(size);
	}

	@Override
	public void updateSize(Size size) {
		Size sizeToUpdate = getSize(size.getId());
		sizeToUpdate.setIdColor(size.getIdColor());
		sizeToUpdate.setQuantity(size.getQuantity());
		sizeToUpdate.setSizeValue(size.getSizeValue());
		sizeToUpdate.setStatus(size.getStatus());
		getCurrentSession().update(sizeToUpdate);
	}

	@Override
	public Size getSize(int id) {
		Criteria cr = getCurrentSession().createCriteria(Size.class);
		cr.add(Restrictions.eq("id", id));
		@SuppressWarnings("rawtypes")
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (Size) results.get(0);
	}

	@Override
	public void deleteSize(int id) {
		Size size = getSize(id);
		if (size != null) {
			getCurrentSession().delete(size);
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Size> getSizes() {
		return getCurrentSession().createCriteria(Size.class).list();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Size> getSizesByColorId(int idColor) {
		Criteria cr = getCurrentSession().createCriteria(Size.class);
		cr.add(Restrictions.eq("idColor", idColor));
		return cr.list();
	}

}
