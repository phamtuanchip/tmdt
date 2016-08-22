package com.chanhhouse.fashion.model;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.hibernate.annotations.Cascade;
import org.hibernate.annotations.CascadeType;
import org.hibernate.annotations.LazyCollection;
import org.hibernate.annotations.LazyCollectionOption;

import com.google.gson.annotations.Expose;

/**
 * @author ntnhat
 *
 */
@Entity
@Table(name = "product")
public class Product implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 8634993102014365580L;
	/**
	 * 
	 */

	@Id
	@Column(name = "ID")
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Column(name = "CODE")
	@Expose
	private String code;

	@Column(name = "NAME")
	@Expose
	private String name;

	@Column(name = "PRICE")
	@Expose
	private String price;

	@Column(name = "SALE_OFF_PRICE")
	@Expose
	private String saleoffprice;

	@Column(name = "DESCRIPTION")
	@Expose
	private String description;

	@Column(name = "GENDER")
	@Expose
	private String gender;

	@Column(name = "IMPORT_PRICE")
	@Expose
	private String importprice;

	@Column(name = "SOLD")
	@Expose
	private String sold;

	@Column(name = "CATEGORY")
	@Expose
	private String category;

	@Column(name = "IMP_DATE")
	@Expose
	private Date impDate;

	@Column(name = "SMALLER_CAT")
	@Expose
	private String smallerCat;

	@Column(name = "SMALLEST_CAT")
	@Expose
	private String smallestCat;

	@Column(name = "MATERIAL")
	@Expose
	private String material;

	@OneToMany(orphanRemoval=true)
	@JoinColumn(name = "CODE", referencedColumnName = "CODE")
	@Cascade({ CascadeType.SAVE_UPDATE })
	@LazyCollection(LazyCollectionOption.FALSE)
	@Expose
	private List<Color> colors = new ArrayList<Color>();

	public Product() {
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setPrice(String price) {
		this.price = price;
	}

	public String getPrice() {
		return this.price;
	}

	public void setSaleoffprice(String saleoffprice) {
		this.saleoffprice = saleoffprice;
	}

	public String getSaleoffprice() {
		return this.saleoffprice;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public List<Color> getColors() {
		return this.colors;
	}

	public void setColors(List<Color> colors) {
		this.colors = colors;
	}

	public String getImportprice() {
		return importprice;
	}

	public void setImportprice(String importprice) {
		this.importprice = importprice;
	}

	public String getSold() {
		return sold;
	}

	public void setSold(String sold) {
		this.sold = sold;
	}

	public String getCategory() {
		return category;
	}

	public void setCategory(String category) {
		this.category = category;
	}

	public Date getImpDate() {
		return impDate;
	}

	public void setImpDate(Date impDate) {
		this.impDate = impDate;
	}

	public String getSmallerCat() {
		return smallerCat;
	}

	public void setSmallerCat(String smallerCat) {
		this.smallerCat = smallerCat;
	}

	public String getSmallestCat() {
		return smallestCat;
	}

	public void setSmallestCat(String smallestCat) {
		this.smallestCat = smallestCat;
	}

	public String getMaterial() {
		return material;
	}

	public void setMaterial(String material) {
		this.material = material;
	}
}