package com.chanhhouse.fashion.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.chanhhouse.fashion.model.CasualClothes;
import com.chanhhouse.fashion.model.JSPForm;
import com.chanhhouse.fashion.model.OfficeOutfit;
import com.chanhhouse.fashion.model.Product;
import com.chanhhouse.fashion.model.Sleepwear;
import com.chanhhouse.fashion.model.Underwear;

@Service
public class JSPFormServiceImpl implements JSPFormService {

	@Autowired
	private ProductService productService;
	
	@Autowired
	private UnderwearService underwearService;
	
	@Autowired
	private OfficeOutfitService officeOutfitService;
	
	@Autowired
	private CasualClothesService casualClothesService;
	
	@Autowired
	private SleepwearService sleepwearService;

	@Override
	public void saveOrUpdateJSPForm(JSPForm form) {
		productService.saveOrUpdate(form.getProduct());
		form.getUnderwear().setCode(form.getProduct().getCode());
		underwearService.saveOrUpdate(form.getUnderwear());
	}

	@Override
	public JSPForm getJSPForm(String code) {
		JSPForm form = new JSPForm();
		form.setProduct(productService.getProduct(code));
		form.setUnderwear(underwearService.getUnderwear(code));
		return form;
	}

	@Override
	public void deleteJSPForm(String code) {
		productService.deleteProduct(code);
		underwearService.deleteUnderwear(code);
	}

	@Override
	public List<JSPForm> getJSPForms() {
		List<Product> products = productService.getProducts();
		List<Underwear> underwears = underwearService.getUnderwears();
		List<OfficeOutfit> officeOutfits = officeOutfitService.getOfficeOutfits();
		List<CasualClothes> casualClothes = casualClothesService.getCasualClothess();
		List<Sleepwear> sleepwears = sleepwearService.getSleepwears();
		List<JSPForm> forms = new ArrayList<JSPForm>();
		for (int i = 0; i < products.size(); i++) {
			JSPForm form = new JSPForm();
			form.setProduct(products.get(i));
			//
			out: for (int j = 0; j < underwears.size(); j++) {
				if (products.get(i).getCode().equals(underwears.get(j).getCode())) {
					form.setUnderwear(underwears.get(j));
					break out;
				}
			}
			//
			out: for (int j = 0; j < officeOutfits.size(); j++) {
				if (products.get(i).getCode().equals(officeOutfits.get(j).getCode())) {
					form.setOfficeOutfit(officeOutfits.get(j));
					break out;
				}
			}
			//
			out: for (int j = 0; j < casualClothes.size(); j++) {
				if (products.get(i).getCode().equals(casualClothes.get(j).getCode())) {
					form.setCasualClothes(casualClothes.get(j));
					break out;
				}
			}
			//
			out: for (int j = 0; j < sleepwears.size(); j++) {
				if (products.get(i).getCode().equals(sleepwears.get(j).getCode())) {
					form.setSleepwear(sleepwears.get(j));
					break out;
				}
			}
		}
		return forms;
	}

}
