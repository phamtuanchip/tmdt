package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.OfficeOutfit;

public interface OfficeOutfitService {

	public void saveOfficeOutfit(OfficeOutfit officeOutfit);

	public void updateOfficeOutfit(OfficeOutfit officeOutfit);

	public OfficeOutfit getOfficeOutfit(String code);

	public void deleteOfficeOutfit(String code);

	public List<OfficeOutfit> getOfficeOutfits();

	public void saveOrUpdate(OfficeOutfit officeOutfit);
}
