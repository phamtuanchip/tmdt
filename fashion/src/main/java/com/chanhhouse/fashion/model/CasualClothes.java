/**
 * 
 */
package com.chanhhouse.fashion.model;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.google.gson.annotations.Expose;

/**
 * @author ntnhat
 *
 */
@Entity
@Table(name = "casualclothes")
public class CasualClothes implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 4631028469866729481L;

	/**
	 * 
	 */

	@Id
	@Expose
	@Column(name = "ID")
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Column(name = "CODE")
	@Expose
	private String code;

	@Column(name = "CATEGORY")
	@Expose
	private String category;

	@Column(name = "FORM")
	@Expose
	private String form;

	public CasualClothes() {
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getCategory() {
		return category;
	}

	public void setCategory(String category) {
		this.category = category;
	}

	public String getForm() {
		return form;
	}

	public void setForm(String form) {
		this.form = form;
	}
	
}
