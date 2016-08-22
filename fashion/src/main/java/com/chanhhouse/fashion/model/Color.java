/**
 * 
 */
package com.chanhhouse.fashion.model;

import java.io.Serializable;
import java.util.ArrayList;
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
@Table(name = "color")
public class Color implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 3863067506224318645L;

	/**
	 * 
	 */

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Expose
	@Column(name = "ID")
	private int id;

	@Column(name = "CODE")
	@Expose
	private String code;

	@Column(name = "URL_COLOR")
	@Expose
	private String urlColor;

	@OneToMany(orphanRemoval=true)
	@JoinColumn(name = "ID_COLOR", referencedColumnName = "ID")
	@Cascade({ CascadeType.SAVE_UPDATE })
	@LazyCollection(LazyCollectionOption.FALSE)
	@Expose
	private List<Image> images = new ArrayList<Image>();

	@OneToMany(orphanRemoval=true)
	@JoinColumn(name = "ID_COLOR", referencedColumnName = "ID")
	@Cascade({ CascadeType.SAVE_UPDATE })
	@LazyCollection(LazyCollectionOption.FALSE)
	@Expose
	private List<Size> sizes = new ArrayList<Size>();

	public Color() {
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

	public String getUrlColor() {
		return urlColor;
	}

	public void setUrlColor(String urlColor) {
		this.urlColor = urlColor;
	}

	public List<Image> getImages() {
		return images;
	}

	public void setImages(List<Image> images) {
		this.images = images;
	}

	public List<Size> getSizes() {
		return sizes;
	}

	public void setSizes(List<Size> sizes) {
		this.sizes = sizes;
	}
}
