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
@Table(name = "size")
public class Size implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 6995443384811369052L;

	/**
	 * 
	 */

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Expose
	@Column(name = "ID")
	private int id;

	@Column(name = "SIZE_VALUE")
	@Expose
	private String sizeValue;

	@Column(name = "ID_COLOR")
	@Expose
	private int idColor;

	@Column(name = "STATUS")
	@Expose
	private String status;

	@Column(name = "QUANTITY")
	@Expose
	private int quantity;

	public Size() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public void setSizeValue(String sizeValue) {
		this.sizeValue = sizeValue;
	}

	public String getSizeValue() {
		return this.sizeValue;
	}

	public void setIdColor(int idColor) {
		this.idColor = idColor;
	}

	public int getIdColor() {
		return this.idColor;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}
}
