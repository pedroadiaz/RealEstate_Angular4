import { PropertyType } from './property-type.enum';

export class listing {
    houseid: number;
    propertyTypeId: PropertyType;
    mls: string;
    streetAddress: string;
    streetAddress2: string;
    city: string;
    state: string;
    zipCode: string;
    price: number;
    description: string;
    mainImage: string;
    bedrooms?: number;
    bathrooms?: number;
    agentId?: number;
    houseUrl: string;
    latitude?: number;
    longitude?: number;

}