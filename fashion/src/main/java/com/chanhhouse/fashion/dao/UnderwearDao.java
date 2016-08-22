package com.chanhhouse.fashion.dao;

import java.util.List;

import com.chanhhouse.fashion.model.Underwear;

public interface UnderwearDao {
  
    public void saveUnderwear(Underwear underwear);

    public void updateUnderwear(Underwear underwear);

    public Underwear getUnderwear(String code);

    public void deleteUnderwear(String code);

    public List<Underwear> getUnderwears();
}
