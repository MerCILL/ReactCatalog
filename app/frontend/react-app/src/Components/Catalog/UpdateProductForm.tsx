import React, { useState } from "react";
import axios from "axios";
import ProductModelRequest from "./Interfaces/ProductModelRequest";

interface UpdateProductFormProps {
    productId: number;
    fetchCatalogProducts: () => Promise<void>;
    setIsUpdatingProduct: React.Dispatch<React.SetStateAction<number | null>>;
}

const UpdateProductForm = ({ productId, fetchCatalogProducts, setIsUpdatingProduct }: UpdateProductFormProps) => {
    const [product, setProduct] = useState<ProductModelRequest>({
        title: '',
        pictureurl: '',
        price: 0,
        typeid: 0,
        brandid: 0,
    });

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setProduct({
            ...product,
            [event.target.name]: event.target.value,
        });
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const accessToken = localStorage.getItem('accessToken');
        if (accessToken) {
            const result = await axios.put(`http://localhost:5000/catalog/products/${productId}`, product, {
                headers: { Authorization: `Bearer ${accessToken}` },
            });
            console.log(result.data);
            fetchCatalogProducts(); 
        }
    }

    const handleClose = () => {
        setIsUpdatingProduct(null);
    }

    return (
        <form onSubmit={handleSubmit} className="update-product-form">
        <button type="button" onClick={handleClose}>X</button>
            <div className="form-group">
                <label>Title:</label>
                <input type="text" name="title" value={product.title} onChange={handleChange} className="form-control" />
            </div>
            <div className="form-group">
                <label>PictureFile:</label>
                <input type="text" name="pictureurl" value={product.pictureurl} onChange={handleChange} className="form-control" />
            </div>
            <div className="form-group">
                <label>Price:</label>
                <input type="number" name="price" value={product.price} onChange={handleChange} className="form-control" />
            </div>
            <div className="form-group">
                <label>TypeId:</label>
                <input type="number" name="typeid" value={product.typeid} onChange={handleChange} className="form-control" />
            </div>
            <div className="form-group">
                <label>BrandId:</label>
                <input type="number" name="brandid" value={product.brandid} onChange={handleChange} className="form-control" />
            </div>
            <button type="submit" className="btn btn-primary">Update</button>
        </form>
    )
}

export default UpdateProductForm;