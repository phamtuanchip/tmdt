package com.chanhhouse.fashion.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import com.chanhhouse.fashion.service.ProductService;

@Controller
public class PageController {
	@Autowired
	ProductService productService;

	@RequestMapping("/")
	public String showHomePage(ModelMap modelMap) {

		int end = productService.getNewProducts().size();
		end = end > 10 ? 10 : end;
		modelMap.addAttribute("newProducts", productService.getNewProducts());
		modelMap.addAttribute("bestSaleProducts", productService.getBestSaleProducts());
		modelMap.addAttribute("end", end);
		return "web/index";
	}

	@RequestMapping(value = "/single/{code}", method = RequestMethod.GET)
	public String showSinglePage(@PathVariable String code, ModelMap modelMap) {

		modelMap.addAttribute("product", productService.getProduct(code));
		return "web/single";
	}

	@RequestMapping(value = "/mproducts/{type}/{orderType}/{orderBy}", method = RequestMethod.GET)
	public String showMProductsPage(@PathVariable("type") String type, @PathVariable("orderType") String orderType,
			@PathVariable("orderBy") String orderBy, ModelMap modelMap) {

		modelMap.addAttribute("product", productService.getProducstByType(type, orderBy, orderType, "1"));
		return "web/products";
	}

	@RequestMapping(value = "/wproducts/{type}/{orderType}/{orderBy}", method = RequestMethod.GET)
	public String showWProductsPage(@PathVariable("type") String type, @PathVariable("orderType") String orderType,
			@PathVariable("orderBy") String orderBy, ModelMap modelMap) {

		modelMap.addAttribute("product", productService.getProducstByType(type, orderBy, orderType, "0"));
		return "web/products";
	}
}
