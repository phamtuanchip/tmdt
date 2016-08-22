package com.chanhhouse.fashion.dao;

import java.util.List;

import com.chanhhouse.fashion.model.Image;

public interface ImageDao {
  
    public void saveImage(Image image);

    public void updateImage(Image image);

    public Image getImage(int id);

    public void deleteImage(int id);

    public List<Image> getImagesByColorId(int idColor);
    
    public List<Image> getImages();
}
