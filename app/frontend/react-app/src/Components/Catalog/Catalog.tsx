import { useCallback, useEffect, useState } from "react";
import ProductModel from "./Interfaces/ProductModel";
import axios from "axios";
import { Link } from "react-router-dom";
import AddProductForm from "./AddProductForm";
import DeleteProductForm from "./DeleteProductForm";
import UpdateProductForm from "./UpdateProductForm";

export default function Catalog() {
    const[products, setProducts] = useState<ProductModel[]>([]);
    const [isAdmin, setIsAdmin] = useState(false);
    const [isAddingProduct, setIsAddingProduct] = useState(false);
    const [updatingProductId, setUpdatingProductId] = useState<number | null>(null);

    useEffect(() => {
        const role = localStorage.getItem('role');
        setIsAdmin(role === 'Admin');
    }, []);

    const fetchCatalogProducts = useCallback(async () => {
        const accessToken = localStorage.getItem('accessToken');
        if (accessToken) {
            const result = await axios.get('http://localhost:5000/catalog/products', {
                headers: { Authorization: `Bearer ${accessToken}` },
            });
            setProducts(result.data);
        }
    }, []);

    useEffect(() => {
        fetchCatalogProducts();
    }, [fetchCatalogProducts]);

    return (
        <div className="container">
            {isAdmin && (
            <button className="btn btn-primary" onClick={() => setIsAddingProduct(true)}>+</button>
            )}
            {isAddingProduct && <AddProductForm fetchCatalogProducts={fetchCatalogProducts} setIsAddingProduct={setIsAddingProduct} />
            }
            <div className="row">
                {products.map((product) =>(
                    <div className="col-sm-4" key={product.id}>
                        <div className="card">
                            <img src={`/assets/images/${product.pictureUrl}`} className="card-img-top" alt={product.pictureUrl}/>
                            <div className="card-body">
                            {isAdmin && <h5 className="card-title">{product.id}</h5>}
                                <h5 className="card-title">{product.title}</h5>
                                <p className="card-text">Price: {product.price}</p>
                                <p className="card-text">Type: {product.type.title}</p>
                                <p className="card-text">Brand: {product.brand.title}</p>
                                {isAdmin && <DeleteProductForm productId={product.id} fetchCatalogProducts={fetchCatalogProducts} />} 
                                {isAdmin && ( <button className="btn btn-primary" onClick={() => setUpdatingProductId(product.id)}>Update</button> )}
                                {updatingProductId === product.id && <UpdateProductForm productId={product.id} fetchCatalogProducts={fetchCatalogProducts} setIsUpdatingProduct={setUpdatingProductId} />}
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}