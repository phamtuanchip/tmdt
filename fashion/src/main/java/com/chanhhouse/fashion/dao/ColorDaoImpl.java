package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.Color;

@Repository
public class ColorDaoImpl implements ColorDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveColor(Color color) {
		getCurrentSession().save(color);
	}

	@Override
	public void updateColor(Color color) {
		Color colorToUpdate = getColor(color.getId());
		colorToUpdate.setCode(color.getCode());
		colorToUpdate.setImages(color.getImages());
		colorToUpdate.setSizes(color.getSizes());
		colorToUpdate.setUrlColor(color.getUrlColor());
		getCurrentSession().update(colorToUpdate);
	}

	@Override
	public Color getColor(int id) {
		Criteria cr = getCurrentSession().createCriteria(Color.class);
		cr.add(Restrictions.eq("id", id));
		@SuppressWarnings("rawtypes")
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (Color) results.get(0);
	}

	@Override
	public void deleteColor(int id) {
		Color color = getColor(id);
		if (color != null) {
			getCurrentSession().delete(color);
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Color> getColors() {
		return getCurrentSession().createCriteria(Color.class).list();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Color> getColorsByCode(String code) {
		Criteria cr = getCurrentSession().createCriteria(Color.class);
		cr.add(Restrictions.eq("code", code));
		return cr.list();
	}
}
