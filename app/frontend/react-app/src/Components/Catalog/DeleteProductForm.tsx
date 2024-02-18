import React, { useState } from "react";
import axios from "axios";
import DeleteProductFormProps from "./Interfaces/DeleteProductRequest";

const DeleteProductForm = ({ productId, fetchCatalogProducts }: DeleteProductFormProps) => {
    const [isDeleting, setIsDeleting] = useState(false);

    const handleDelete = async () => {
        setIsDeleting(true);
        const accessToken = localStorage.getItem('accessToken');
        if (accessToken) {
            const result = await axios.delete(`http://localhost:5000/catalog/products/${productId}`, {
                headers: { Authorization: `Bearer ${accessToken}` },
            });
            console.log(result.data);
            setIsDeleting(false);
            fetchCatalogProducts(); 
        }
    }

    return (
        <button className="btn btn-primary" onClick={handleDelete} disabled={isDeleting}>
            {isDeleting ? "Deleting..." : "-"}
        </button>
    );
}

export default DeleteProductForm;