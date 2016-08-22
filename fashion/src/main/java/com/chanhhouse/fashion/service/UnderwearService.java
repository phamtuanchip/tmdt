package com.chanhhouse.fashion.service;

import java.util.List;

import com.chanhhouse.fashion.model.Underwear;

public interface UnderwearService {

	public void saveUnderwear(Underwear underwear);

	public void updateUnderwear(Underwear underwear);

	public Underwear getUnderwear(String code);

	public void deleteUnderwear(String code);

	public List<Underwear> getUnderwears();

	public void saveOrUpdate(Underwear underwear);
}
