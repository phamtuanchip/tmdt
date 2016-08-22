package com.chanhhouse.fashion.dao;

import java.util.List;

import com.chanhhouse.fashion.model.Product;

public interface ProductDao {

	public void saveProduct(Product product);

	public void updateProduct(Product product);

	public Product getProduct(String code);

	public void deleteProduct(String code);

	public List<Product> getProducts(String order);

	public List<Product> getProducstByType(String type, String orderBy, String orderType, String gender);
}