package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.JSPForm;

public interface JSPFormService {
	public void saveOrUpdateJSPForm(JSPForm product);

	public JSPForm getJSPForm(String code);

	public void deleteJSPForm(String code);

	public List<JSPForm> getJSPForms();
}
