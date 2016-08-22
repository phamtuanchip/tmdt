package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.Product;

public interface ProductService {

	public void saveProduct(Product product);

	public void updateProduct(Product product);

	public Product getProduct(String code);

	public void deleteProduct(String code);

	public List<Product> getProducts();

	public List<Product> getNewProducts();

	public List<Product> getBestSaleProducts();

	public void saveOrUpdate(Product product);

	List<Product> getProducstByType(String type, String orderBy, String orderType, String gender);
}
