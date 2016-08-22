package com.chanhhouse.fashion.controller;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;

import com.chanhhouse.fashion.model.Color;
import com.chanhhouse.fashion.model.Image;
import com.chanhhouse.fashion.model.JSPForm;
import com.chanhhouse.fashion.model.Product;
import com.chanhhouse.fashion.model.Size;
import com.chanhhouse.fashion.service.CasualClothesService;
import com.chanhhouse.fashion.service.ColorService;
import com.chanhhouse.fashion.service.ImageService;
import com.chanhhouse.fashion.service.OfficeOutfitService;
import com.chanhhouse.fashion.service.ProductService;
import com.chanhhouse.fashion.service.SizeService;
import com.chanhhouse.fashion.service.SleepwearService;
import com.chanhhouse.fashion.service.UnderwearService;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

/**
 * @author ntnhat
 *
 */
@Controller
public class AdminController {

	@Autowired
	ProductService productService;

	@Autowired
	UnderwearService underwearService;

	@Autowired
	CasualClothesService casualClothesService;

	@Autowired
	OfficeOutfitService officeOutfitService;

	@Autowired
	SleepwearService sleepwearService;

	@Autowired
	ColorService colorService;

	@Autowired
	ImageService imageService;

	@Autowired
	SizeService sizeService;

	@RequestMapping("/dataTables")
	public String showDatatables(ModelMap modelMap) {
		return "admin/dataTables";
	}

	@RequestMapping("/adminHome")
	public String showDashboard(ModelMap modelMap) {
		return "admin/index";
	}

	@RequestMapping("/newProduct")
	public String newProduct(ModelMap modelMap) {
		modelMap.addAttribute("command", new JSPForm());
		modelMap.addAttribute("jSPForm", new JSPForm());
		return "admin/newProduct";
	}
	@RequestMapping("/newPro")
	public String newPro(ModelMap modelMap) {
		modelMap.addAttribute("command", new JSPForm());
		modelMap.addAttribute("jSPForm", new JSPForm());
		return "admin/productEditor";
	}

	@RequestMapping(value = "/getProducts/{code}", produces = { "application/json; charset=UTF-8" })
	public @ResponseBody String getProducts(@PathVariable String code) {
		List<Product> products = null;
		Gson gson = new GsonBuilder().excludeFieldsWithoutExposeAnnotation().create();
		String out = "";
		if ("all".equals(code)) {
			products = productService.getProducts();
		} else {
			products = new ArrayList<Product>();
			products.add(productService.getProduct(code));
		}
		out = gson.toJson(products);
		return out;
	}

	@RequestMapping(value = "/getColors/{id}", produces = { "application/json; charset=UTF-8" })
	public @ResponseBody String getColors(@PathVariable String id) {
		List<Color> colors = null;
		Gson gson = new GsonBuilder().excludeFieldsWithoutExposeAnnotation().create();
		String out = "";
		if ("all".equals(id)) {
			colors = colorService.getColors();
		} else {
			colors = new ArrayList<Color>();
			colors.add(colorService.getColor(Integer.parseInt(id)));
		}
		out = gson.toJson(colors);
		return out;
	}

	@RequestMapping(value = "/getImages/{id}", produces = { "application/json; charset=UTF-8" })
	public @ResponseBody String getImages(@PathVariable String id) {
		List<Image> images = null;
		Gson gson = new GsonBuilder().excludeFieldsWithoutExposeAnnotation().create();
		String out = "";
		if ("all".equals(id)) {
			images = imageService.getImages();
		} else {
			images = new ArrayList<Image>();
			images.add(imageService.getImage(Integer.parseInt(id)));
		}
		out = gson.toJson(images);
		return out;
	}

	@RequestMapping(value = "/getSizes/{id}", produces = { "application/json; charset=UTF-8" })
	public @ResponseBody String getSizes(@PathVariable String id) {
		List<Size> sizes = null;
		Gson gson = new GsonBuilder().excludeFieldsWithoutExposeAnnotation().create();
		String out = "";
		if ("all".equals(id)) {
			sizes = sizeService.getSizes();
		} else {
			sizes = new ArrayList<Size>();
			sizes.add(sizeService.getSize(Integer.parseInt(id)));
		}
		out = gson.toJson(sizes);
		return out;
	}

	@RequestMapping(value = "/subP", method = RequestMethod.POST, produces = { "text/plain; charset=UTF-8" })
	public String saveProducts(@ModelAttribute("jSPForm") JSPForm jSPForm,
			@RequestParam("colorImgs") MultipartFile[] colorImgs,
			@RequestParam("imageImgs") MultipartFile[] imageImgs) {
		if (jSPForm == null) {
			System.out.println("fail");
		} else {
			//
			// Start File saving process
			//
			String rootPath = System.getProperty("catalina.home");
			//
			// Colors
			for (int i = 0; i < colorImgs.length; i++) {
				MultipartFile file = colorImgs[i];
				try {
					byte[] bytes = file.getBytes();

					// Creating the directory to store file
					File dir = new File(rootPath + File.separator + "colorImgs");
					if (!dir.exists()) {
						dir.mkdirs();
					}

					// Create the file on server
					File serverFile = new File(dir.getAbsolutePath() + File.separator + file.getOriginalFilename());
					BufferedOutputStream stream = new BufferedOutputStream(new FileOutputStream(serverFile));
					stream.write(bytes);
					stream.close();

				} catch (Exception e) {
					e.printStackTrace();
				}
			}
			//
			// Images
			for (int i = 0; i < imageImgs.length; i++) {
				MultipartFile file = imageImgs[i];
				try {
					byte[] bytes = file.getBytes();

					// Creating the directory to store file

					File dir = new File(rootPath + File.separator + "imageImgs");
					if (!dir.exists()) {
						dir.mkdirs();
					}

					// Create the file on server
					File serverFile = new File(dir.getAbsolutePath() + File.separator + file.getOriginalFilename());
					BufferedOutputStream stream = new BufferedOutputStream(new FileOutputStream(serverFile));
					stream.write(bytes);
					stream.close();

				} catch (Exception e) {
					e.printStackTrace();
				}
			}
			// End File saving process
			jSPForm.getProduct().setImpDate(new Date());
			productService.saveOrUpdate(jSPForm.getProduct());
		}
		return "admin/dataTables";
	}

	@RequestMapping(value = "/deleteProduct/{code}")
	public String deleteProduct(@PathVariable String code) {
		productService.deleteProduct(code);
		return "admin/dataTables";
	}

	@RequestMapping(value = "/deleteColor/{id}")
	public String deleteColor(@PathVariable int id) {
		colorService.deleteColor(id);
		return "admin/dataTables";
	}

	@RequestMapping(value = "/deleteImage/{id}")
	public String deleteImage(@PathVariable int id) {
		imageService.deleteImage(id);
		return "admin/dataTables";
	}

	@RequestMapping(value = "/deleteSize/{id}")
	public String deleteSize(@PathVariable int id) {
		sizeService.deleteSize(id);
		return "admin/dataTables";
	}

	@RequestMapping(value = "/deleteFiles")
	public String deleteFiles() {
		String rootPath = System.getProperty("catalina.home");
		File dir = new File(rootPath + File.separator + "colorImgs");
		if (dir.exists()) {
			dir.delete();
		}
		File dir2 = new File(rootPath + File.separator + "imageImgs");
		if (dir2.exists()) {
			dir2.delete();
		}
		return "admin/dataTables";
	}
}