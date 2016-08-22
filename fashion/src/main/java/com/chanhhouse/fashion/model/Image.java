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
@Table(name = "image")
public class Image implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -1551655424913174588L;

	/**
	 * 
	 */

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID")
	@Expose
	private int id;

	@Column(name = "URL_IMAGE")
	@Expose
	private String urlImage;

	@Column(name = "ID_COLOR")
	@Expose
	private int idColor;

	public Image() {
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getUrlImage() {
		return urlImage;
	}

	public void setUrlImage(String urlImage) {
		this.urlImage = urlImage;
	}

	public int getIdColor() {
		return this.idColor;
	}

	public void setIdColor(int idColor) {
		this.idColor = idColor;
	}

}
