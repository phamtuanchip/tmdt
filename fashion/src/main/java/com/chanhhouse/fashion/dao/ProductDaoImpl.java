package com.chanhhouse.fashion.dao;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Order;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.chanhhouse.fashion.model.Product;

@Repository
public class ProductDaoImpl implements ProductDao {

	@Autowired
	private SessionFactory sessionFactory;

	private Session getCurrentSession() {
		return sessionFactory.getCurrentSession();
	}

	@Override
	public void saveProduct(Product product) {
		getCurrentSession().save(product);
	}

	@Override
	public void deleteProduct(String code) {
		Product product = getProduct(code);
		if (product != null)
			getCurrentSession().delete(product);
	}

	@SuppressWarnings("rawtypes")
	@Override
	public Product getProduct(String code) {
		Criteria cr = getCurrentSession().createCriteria(Product.class);
		cr.add(Restrictions.eq("code", code));
		List results = cr.list();
		if (results.isEmpty()) {
			return null;
		}
		return (Product) results.get(0);
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<Product> getProducts(String order) {
		Criteria criteria = getCurrentSession().createCriteria(Product.class);
		if ("new".equals(order)) {
			criteria.addOrder(Order.desc("impDate"));
		} else if ("bestSale".equals(order)) {
			criteria.addOrder(Order.desc("sold"));
		}
		return criteria.list();
	}

	@Override
	public void updateProduct(Product product) {
		Product productToUpdate = getProduct(product.getCode());
		productToUpdate.setDescription(product.getDescription());
		productToUpdate.setGender(product.getGender());
		productToUpdate.setName(product.getName());
		productToUpdate.setPrice(product.getPrice());
		productToUpdate.setSaleoffprice(product.getSaleoffprice());
		productToUpdate.setColors(product.getColors());
		productToUpdate.setCategory(product.getCategory());
		productToUpdate.setImpDate(product.getImpDate());
		productToUpdate.setSmallerCat(product.getSmallerCat());
		productToUpdate.setSmallestCat(product.getSmallestCat());
		productToUpdate.setMaterial(product.getMaterial());
		getCurrentSession().update(productToUpdate);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Product> getProducstByType(String type, String orderBy, String orderType, String gender) {
		Criteria criteria = getCurrentSession().createCriteria(Product.class);
		criteria.add(Restrictions.and(Restrictions.eq("TYPE", type), Restrictions.eq("GENDER", gender)));
		if ("desc".equals(orderType)) {
			criteria.addOrder(Order.desc(orderBy));
		} else if ("asc".equals(orderType)) {
			criteria.addOrder(Order.asc(orderBy));
		}
		return criteria.list();
	}

}
