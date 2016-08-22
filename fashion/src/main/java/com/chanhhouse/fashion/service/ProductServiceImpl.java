package com.chanhhouse.fashion.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.chanhhouse.fashion.dao.ColorDao;
import com.chanhhouse.fashion.dao.ImageDao;
import com.chanhhouse.fashion.dao.ProductDao;
import com.chanhhouse.fashion.dao.SizeDao;
import com.chanhhouse.fashion.model.Product;

@Service
public class ProductServiceImpl implements ProductService {

	@Autowired
	ProductDao productDao;

	@Autowired
	ColorDao colorDao;

	@Autowired
	ImageDao imageDao;

	@Autowired
	SizeDao sizeDao;

	@Override
	@Transactional
	public void saveProduct(Product product) {
		productDao.saveProduct(product);
	}

	@Override
	@Transactional
	public void deleteProduct(String code) {
		productDao.deleteProduct(code);
	}

	@Override
	@Transactional
	public Product getProduct(String code) {
		return productDao.getProduct(code);
	}

	@Override
	@Transactional
	public List<Product> getProducts() {
		return productDao.getProducts("new");
	}

	@Override
	@Transactional
	public void updateProduct(Product product) {
		productDao.updateProduct(product);
	}

	@Override
	@Transactional
	public void saveOrUpdate(Product product) {
		if (null == getProduct(product.getCode())) {
			saveProduct(product);
		} else {
			updateProduct(product);
		}
	}

	@Override
	@Transactional
	public List<Product> getNewProducts() {
		return productDao.getProducts("new");
	}

	@Override
	@Transactional
	public List<Product> getBestSaleProducts() {
		return productDao.getProducts("bestSale");
	}

	@Override
	@Transactional
	public List<Product> getProducstByType(String type, String orderBy, String orderType, String gender) {
		if ("date".equals(orderBy)) {
			orderBy = "ID";
		}
		return productDao.getProducstByType(type, orderBy, orderType, gender);
	}
}