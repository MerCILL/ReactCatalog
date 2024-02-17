import BrandModel from "./BrandModel";
import TypeModel from "./TypeModel";

export default interface ProductModel {
    id: number;
    title: string;
    pictureUrl: string;
    price: number;
    brand: BrandModel;
    type: TypeModel;
}

