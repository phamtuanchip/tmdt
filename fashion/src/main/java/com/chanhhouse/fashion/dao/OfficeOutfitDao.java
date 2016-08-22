package com.chanhhouse.fashion.dao;

import java.util.List;

import com.chanhhouse.fashion.model.OfficeOutfit;

public interface OfficeOutfitDao {
  
    public void saveOfficeOutfit(OfficeOutfit officeOutfit);

    public void updateOfficeOutfit(OfficeOutfit officeOutfit);

    public OfficeOutfit getOfficeOutfit(String code);

    public void deleteOfficeOutfit(String code);

    public List<OfficeOutfit> getOfficeOutfits();
}
