import { RegistrarDTO } from './registrar.model';


export class GraveOwnerRegistrarsDTO {
    fullName: string;
    graveReferenceCode: string;
    graveSize: string;
    graveRow: number;
    graveDepth: number;
    registrars: Array<RegistrarDTO>;
    graveOwnerAddress: string;
    graveLocation: string;
}