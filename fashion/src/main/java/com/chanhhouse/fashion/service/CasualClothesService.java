package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.CasualClothes;

public interface CasualClothesService {

	public void saveCasualClothes(CasualClothes casualClothes);

	public void updateCasualClothes(CasualClothes casualClothes);

	public CasualClothes getCasualClothes(String code);

	public void deleteCasualClothes(String code);

	public List<CasualClothes> getCasualClothess();

	public void saveOrUpdate(CasualClothes casualClothes);
}
