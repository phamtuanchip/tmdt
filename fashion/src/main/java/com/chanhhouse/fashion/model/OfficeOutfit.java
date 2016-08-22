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
@Table(name = "officeoutfit")
public class OfficeOutfit implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -380083161125665400L;

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

	public OfficeOutfit() {
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
}
