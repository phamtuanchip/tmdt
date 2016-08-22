package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.Image;

@Repository
public class ImageDaoImpl implements ImageDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveImage(Image image) {
		getCurrentSession().save(image);
	}

	@Override
	public void updateImage(Image image) {
		Image imageToUpdate = getImage(image.getId());
		imageToUpdate.setIdColor(image.getIdColor());
		imageToUpdate.setUrlImage(image.getUrlImage());
		getCurrentSession().update(imageToUpdate);
	}

	@Override
	public Image getImage(int id) {
		Criteria cr = getCurrentSession().createCriteria(Image.class);
		cr.add(Restrictions.eq("id", id));
		@SuppressWarnings("rawtypes")
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (Image) results.get(0);
	}

	@Override
	public void deleteImage(int id) {
		Image image = getImage(id);
		if (image != null) {
			getCurrentSession().delete(image);
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Image> getImages() {
		return getCurrentSession().createCriteria(Image.class).list();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Image> getImagesByColorId(int idColor) {
		Criteria cr = getCurrentSession().createCriteria(Image.class);
		cr.add(Restrictions.eq("idColor", idColor));
		return cr.list();
	}
}
