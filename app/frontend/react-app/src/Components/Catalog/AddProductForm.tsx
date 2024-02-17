import React, { Dispatch, SetStateAction, useState } from "react";
import ProductModelRequest from "./Interfaces/ProductModelRequest";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import './AddProductForm.css';

interface AddProductFormProps {
  fetchCatalogProducts: () => void;
  setIsAddingProduct: Dispatch<SetStateAction<boolean>>;
}

const AddProductForm = ({ fetchCatalogProducts, setIsAddingProduct }: AddProductFormProps) => {
    const [product, setProduct] = useState<ProductModelRequest>({
        title: '',
        pictureurl: '',
        price: 0,
        typeid: 0,
        brandid: 0,
    });

    const navigate = useNavigate();

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
            const result = await axios.post('http://localhost:5000/catalog/products', product, {
                headers: {Authorization: `Bearer ${accessToken}`},
            });
            console.log(result.data);
            navigate('/home');
            fetchCatalogProducts(); 
            setIsAddingProduct(false); 
        }
    }

    return (
        <form onSubmit={handleSubmit} className="add-product-form">
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
            <button type="submit" className="btn btn-primary">Добавить товар</button>
        </form>
    )
}

export default AddProductForm;