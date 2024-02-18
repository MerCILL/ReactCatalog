export default interface DeleteProductFormProps {
    productId: number;
    fetchCatalogProducts: () => Promise<void>;
}